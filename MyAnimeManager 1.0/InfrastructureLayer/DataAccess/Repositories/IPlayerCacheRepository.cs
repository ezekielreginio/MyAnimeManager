using DomainLayer.Models;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public interface IPlayerCacheRepository
    {
        bool CheckIfAnimeExist(SQLiteCommand cmd, int animeID);
        PlayerCacheModel GetPlayerCache(int animeID);
        void SavePlayerCache(PlayerCacheModel model);
    }
}