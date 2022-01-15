using CommonComponents;
using CommonComponents.Constants;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public class PlayerCacheRepository : IPlayerCacheRepository
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

        public PlayerCacheRepository()
        {
            //Empty Constructor
        }

        public PlayerCacheRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public void SavePlayerCache(PlayerCacheModel model)
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
                using (SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection))
                {
                    bool animeExist = CheckIfAnimeExist(cmd, model.animeID);
                    string sql = "";
                    if (!animeExist)
                    {
                        sql = "INSERT INTO " +
                        "" + PlayerCacheConstants.PLAYER_CACHE_TABLE + " (" + PlayerCacheConstants.PLAYER_CACHE_ANIME_ID + ", " + PlayerCacheConstants.PLAYER_CACHE_EPISODE + ", " + PlayerCacheConstants.PLAYER_CACHE_DURATION + ") " +
                        "VALUES (@AnimeID, @Episode, @Duration)";
                    }
                    else
                    {
                        sql = "UPDATE " + PlayerCacheConstants.PLAYER_CACHE_TABLE + " " +
                        "SET " + PlayerCacheConstants.PLAYER_CACHE_EPISODE + " = @Episode" + ", " +
                        PlayerCacheConstants.PLAYER_CACHE_DURATION + " = @Duration" + " " +
                        "WHERE " + PlayerCacheConstants.PLAYER_CACHE_ANIME_ID + "=@AnimeID";
                    }
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("AnimeID", model.animeID);
                    cmd.Parameters.AddWithValue("Episode", model.episode);
                    cmd.Parameters.AddWithValue("Duration", model.duration);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
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
                    cmd.Dispose();
                }
                sQLiteConnection.Close();
            }
        }

        public PlayerCacheModel GetPlayerCache(int animeID)
        {
            PlayerCacheModel model = new PlayerCacheModel();
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            string sql = "SELECT * FROM " + PlayerCacheConstants.PLAYER_CACHE_TABLE + " WHERE " + PlayerCacheConstants.PLAYER_CACHE_ANIME_ID + " = @animeID";
            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    sqLiteConnection.Open();

                }
                catch (SQLiteException e)
                {
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                using (SQLiteCommand cmd = new SQLiteCommand(sqLiteConnection))
                {
                    bool animeExist = CheckIfAnimeExist(cmd, animeID);
                    if (animeExist)
                    {
                        cmd.CommandText = sql;
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@animeID", animeID);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.episode = Int32.Parse(reader[PlayerCacheConstants.PLAYER_CACHE_EPISODE].ToString());
                                model.duration = reader[PlayerCacheConstants.PLAYER_CACHE_DURATION].ToString();
                            }
                            reader.Close();
                        }
                        cmd.Dispose();
                        sqLiteConnection.Close();
                        return model;
                    }
                    else
                    {
                        cmd.Dispose();
                        sqLiteConnection.Close();
                        return null;
                    }
                }
            }
            return null;
        }

        public bool CheckIfAnimeExist(SQLiteCommand cmd, int animeID)
        {
            DataAccessStatus dataAccessStatus = new DataAccessStatus();
            Int32 countOfRecsFound = 0;
            cmd.Prepare();
            cmd.CommandText = "SELECT count(*) FROM " + PlayerCacheConstants.PLAYER_CACHE_TABLE + "" +
                    " WHERE " + PlayerCacheConstants.PLAYER_CACHE_ANIME_ID + "=@AnimeID";
            cmd.Parameters.AddWithValue("AnimeID", animeID);
            try
            {
                countOfRecsFound = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SQLiteException e)
            {
                string msg = e.Message;
                throw;
            }
            if (countOfRecsFound > 0)
                return true;
            else
                return false;
        }
    }
}
