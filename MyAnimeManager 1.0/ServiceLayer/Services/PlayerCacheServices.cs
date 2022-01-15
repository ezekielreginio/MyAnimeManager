using DomainLayer.Models;
using InfrastructureLayer.DataAccess.Repositories;
using InfrastructureLayer.DataAccess.Repositories.Specific.Directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class PlayerCacheServices : IPlayerCacheServices
    {
        IPlayerCacheRepository _playerCacheRepository;
        public PlayerCacheServices()
        {
            //Empty Constructor   
        }
        public PlayerCacheServices(IPlayerCacheRepository playerCacheRepository)
        {
            _playerCacheRepository = playerCacheRepository;
        }
        public PlayerCacheModel GetPlayerCache(int animeID)
        {
            try
            {
                return _playerCacheRepository.GetPlayerCache(animeID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void UpdatePlayerCache(PlayerCacheModel model)
        {
            try
            {
                _playerCacheRepository.SavePlayerCache(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Player Cache Saving Failed: " + ex.Message);
            }
        }
    }
}
