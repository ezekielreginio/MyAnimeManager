using System;

namespace InfrastructureLayer.DataAccess.Repositories
{
    public interface IRestfulRepository
    {
        bool AddAccessToken(string jsonData);
        bool AddProfileData(String profileData);
        String GetAccessToken();
    }
}