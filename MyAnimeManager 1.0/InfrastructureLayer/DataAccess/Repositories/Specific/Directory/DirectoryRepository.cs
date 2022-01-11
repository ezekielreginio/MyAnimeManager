using CommonComponents;
using CommonComponents.Constants;
using DomainLayer.Models;
using ServiceLayer.Services.DirectoryServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Directory
{
    public class DirectoryRepository : IDirectoryRepository
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
        //Constructors
        public DirectoryRepository()
        {
            
        }
        public DirectoryRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        //Directory Repository Interface
        public void Add(DirectoryModel directoryModel)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            using(SQLiteConnection sQLiteConnection = new SQLiteConnection())
            {
                //Try to Open a SQL Connection
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
                    ""+AnimeDirectoryConstants.ANIME_DIRECTORY+" ("+AnimeDirectoryConstants.ANIME_DIRECTORY_ID+ ", " + AnimeDirectoryConstants.ANIME_DIRECTORY_PATH + ") " +
                    "VALUES (0, @DirectoryPath)";
                using(SQLiteCommand cmd = new SQLiteCommand())
                {
                    //Check if Directory Record Exist
                    try
                    {
                        RecordExistCheck(cmd, directoryModel, TypeOfExistenceCheck.DoesNotExistInDB, RequestType.Add);
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
                    cmd.Parameters.AddWithValue("@DirectoryPath", directoryModel.DirectoryPath);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(SQLiteException e)
                    {
                        dataAccessStatus.setValues(status: "Error",
                            operationSucceeded: false, 
                            exceptionMessage: e.Message,
                            customMessage: "Unable to add Directory",
                            helpLink: e.HelpLink,
                            errorCode: e.ErrorCode,
                            stackTrace: e.StackTrace);

                        throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                    }
                }

            }
        }

        public void Delete(DirectoryModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public DirectoryModel Get()
        {
            DirectoryModel directoryModel = new DirectoryModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            bool MachingRecordFound = false;
            string sql = "SELECT * FROM "+AnimeDirectoryConstants.ANIME_DIRECTORY+" WHERE "+AnimeDirectoryConstants.ANIME_DIRECTORY_ID+" = 0";
            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqLiteConnection.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqLiteConnection))
                    {
                        cmd.CommandText = sql;

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            MachingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {
                                directoryModel.DirectoryPath = reader[AnimeDirectoryConstants.ANIME_DIRECTORY_PATH].ToString();
                            }
                        }
                        sqLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }

                if (!MachingRecordFound)
                {
                    dataAccessStatus.setValues(status: "Error", operationSucceeded: false, exceptionMessage: "", customMessage: "Directory Not Found", helpLink: "", errorCode: 0, stackTrace: "");
                    throw new DataAccessException(dataAccessStatus);
                }
            }
            return directoryModel;
        }

        public void Update(DirectoryModel departmentModel)
        {
            int result = -1;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
        }

        //Private Methods
        private bool RecordExistCheck(SQLiteCommand cmd, DirectoryModel directoryModel, TypeOfExistenceCheck typeOfExistenceCheck, RequestType requestType)
        {
            Int32 countOfRecsFound = 0;
            bool RecordExistsCheckPassed = true;
            DataAccessStatus dataAccessStatus = new DataAccessStatus();

            cmd.Prepare();

            if((requestType == RequestType.Add) || (requestType == RequestType.ConfirmAdd))
            {
                cmd.CommandText = "SELECT count(*) FROM "+AnimeDirectoryConstants.ANIME_DIRECTORY+"" +
                    "WHERE "+AnimeDirectoryConstants.ANIME_DIRECTORY_ID+"=0";
            }

            try
            {
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(SQLiteException e)
            {
                string msg = e.Message;
                throw;
            }

            if((typeOfExistenceCheck == TypeOfExistenceCheck.DoesNotExistInDB) && (countOfRecsFound > 0))
            {
                dataAccessStatus.Status = "Error";
                dataAccessStatus.CustomMessage = "Directory Already Exists";
                dataAccessStatus.ErrorCode = 0;
                RecordExistsCheckPassed = false;
                throw new DataAccessException(dataAccessStatus);
            }

            return RecordExistsCheckPassed;
        }
    }
}
