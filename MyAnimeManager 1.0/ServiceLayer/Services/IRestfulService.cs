using System;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IRestfulService
    {
        Task<dynamic> LoginUser(string authorizationCode);
        Task<dynamic> GetAnimeDetails(String title);
        Task<dynamic> GetAnimeStatisticsUsingToken();
    }
}