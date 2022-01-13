using CommonComponents;
using CommonComponents.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public class RestfulRepository : IRestfulRepository
    {
        private string _connectionString;
        public enum TypeOfExistenceCheck
        {
            DoesExistInDB,
            DoesNotExistInDB
        }
        public enum RequestType
        {
            Add,
            Delete,
            Update,
            Read,
            ConfirmAdd,
            ConfirmDelete
        }

        public RestfulRepository()
        {

        }

        public RestfulRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        //Directory Repository Interface
        public bool AddAccessToken(String jsonData)
        {
            
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sQLiteConnection.Open();
                }
                catch (SQLiteException e)
                {
                    //Could not open a database connection
                    dataAccessStatus.setValues(status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Unable to Add Directory. Could not open a database connection",
                        helpLink: "",
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                
                string sql = "INSERT INTO " +
                    "" + MalProfileConstants.MAL_PROFILE + " (" + MalProfileConstants.MAL_PROFILE_ID + ", " + MalProfileConstants.MAL_PROFILE_JSON + ") " +
                    "VALUES (@id, @Json)";
                
                using (SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection))
                {
                    
                    try
                    {
                        RecordExistCheck(cmd, MalProfileConstants.MAL_PROFILE_ACCESS_TOKEN, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                        
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.CustomMessage = "MAL Profile Record Already Exists in the Database";
                        e.DataAccessStatusInfo.ExceptionMessage = String.Copy(e.Message);
                        e.DataAccessStatusInfo.StackTrace = String.Copy(e.StackTrace);
                        throw e;
                    }
                    cmd.CommandText = sql;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@Json", jsonData);
                    cmd.Parameters.AddWithValue("@id", MalProfileConstants.MAL_PROFILE_ACCESS_TOKEN);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Insert Failed: "+e.Message);

                    }
                    cmd.Dispose();
                    
                }
                sQLiteConnection.Close();
            }
            return true;
        }

        public bool AddProfileData(String profileData)
        {
            Console.WriteLine("Addprofile Executed");
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sQLiteConnection.Open();
                }
                catch (SQLiteException e)
                {
                    //Could not open a database connection
                    dataAccessStatus.setValues(status: "Error",
                        operationSucceeded: false,
                        exceptionMessage: e.Message,
                        customMessage: "Unable to Add Directory. Could not open a database connection",
                        helpLink: "",
                        errorCode: e.ErrorCode,
                        stackTrace: e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                string sql = "INSERT INTO " +
                    "" + MalProfileConstants.MAL_PROFILE + " (" + MalProfileConstants.MAL_PROFILE_ID + ", " + MalProfileConstants.MAL_PROFILE_JSON + ") " +
                    "VALUES (@UserProfile, @Json)";
                Console.WriteLine("SQL: "+sql);
                using (SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection))
                {
                    try
                    {
                        RecordExistCheck(cmd, MalProfileConstants.MAL_PROFILE_USER, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
                    }
                    catch (DataAccessException e)
                    {
                        e.DataAccessStatusInfo.CustomMessage = "Directory Record Already Exists in the Database";
                        e.DataAccessStatusInfo.ExceptionMessage = String.Copy(e.Message);
                        e.DataAccessStatusInfo.StackTrace = String.Copy(e.StackTrace);
                        throw e;
                    }
                    cmd.CommandText = sql;
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@UserProfile", MalProfileConstants.MAL_PROFILE_USER);
                    cmd.Parameters.AddWithValue("@Json", profileData);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Profile Error: "+e.Message);
                    }
                    cmd.Dispose();

                }

                sQLiteConnection.Close();
            }
                return true;
        }

        public String GetAccessToken()
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MachingRecordFound = false;
            String accessToken = null;
            string sql = "SELECT * FROM " + MalProfileConstants.MAL_PROFILE + " WHERE " + MalProfileConstants.MAL_PROFILE_ID + " = 'access_token'";
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sQLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sQLiteConnection))
                    {
                        cmd.CommandText = sql;

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            MachingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                dynamic jsonAccessToken = JsonConvert.DeserializeObject(reader[MalProfileConstants.MAL_PROFILE_JSON].ToString());
                                accessToken = jsonAccessToken[MalProfileConstants.MAL_PROFILE_ACCESS_TOKEN];
                            }
                        }
                        cmd.Dispose();
                        sQLiteConnection.Close();
                    }
                }
                catch (Exception e)
                {

                }
            }
            return accessToken;
        }

        private bool RecordExistCheck(SQLiteCommand cmd, String id, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();
            if ((requestType == RequestType.Add) || (requestType == RequestType.Update))
            {
                cmd.CommandText = "SELECT count(*) FROM " + MalProfileConstants.MAL_PROFILE + "" +
                    " WHERE " + MalProfileConstants.MAL_PROFILE_ID + "='"+ id + "'";
            }

            try
            {
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SQLiteException e)
            {
                string msg = e.Message;
                throw;
            }

            if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && (countOfRecsFound > 0))
            {
                dataAccessStatus.Status = "Error";
                dataAccessStatus.CustomMessage = "Directory Already Exists";
                dataAccessStatus.ErrorCode = 0;
                RecordExistsCheckPassed = false;
                throw new DataAccessException(dataAccessStatus);
            }
            else if ((typeOfExistenceCheck == TypeOfExistenceCheck.DoesExistInDB) && (countOfRecsFound == 0))
            {
                dataAccessStatus.Status = "Error";
                dataAccessStatus.CustomMessage = "Directory Record Does Not Exist";
                dataAccessStatus.ErrorCode = 0;
                RecordExistsCheckPassed = false;
                throw new DataAccessException(dataAccessStatus);
            }
            return RecordExistsCheckPassed;
        }
    }
}
