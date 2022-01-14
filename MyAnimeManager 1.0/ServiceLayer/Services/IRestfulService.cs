using DomainLayer.Models;
using System;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IRestfulService
    {
        Task<dynamic> LoginUser(string authorizationCode);
        Task<dynamic> GetAnimeDetails(String title);
        Task<dynamic> GetAnimeDetailsByID(int animeID);
        Task<dynamic> GetAnimeStatisticsUsingToken();
        Task<dynamic> UpdateAnimeStatus(AnimeStatus animeStatus);
        Task<int> deleteAnime(int animeID);
    }
}