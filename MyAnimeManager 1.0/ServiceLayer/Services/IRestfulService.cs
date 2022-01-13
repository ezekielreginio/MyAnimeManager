using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public interface IRestfulService
    {
        Task<int> LoginUser(string authorizationCode);
    }
}