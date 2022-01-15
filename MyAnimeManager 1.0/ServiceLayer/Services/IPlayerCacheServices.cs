using DomainLayer.Models;

namespace ServiceLayer.Services
{
    public interface IPlayerCacheServices
    {
        PlayerCacheModel GetPlayerCache(int animeID);
        void UpdatePlayerCache(PlayerCacheModel model);
    }
}