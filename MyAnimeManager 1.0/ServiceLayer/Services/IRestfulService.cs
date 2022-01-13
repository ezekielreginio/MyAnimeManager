using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IRestfulService
    {
        Task<dynamic> LoginUser(string authorizationCode);

        Task<dynamic> GetAnimeStatisticsUsingToken();
    }
}