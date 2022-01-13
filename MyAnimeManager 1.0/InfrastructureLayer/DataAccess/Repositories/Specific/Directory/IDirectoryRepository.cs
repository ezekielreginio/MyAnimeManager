using DomainLayer.Models;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Directory
{
    public interface IDirectoryRepository
    {
        void Add(DirectoryModel directoryModel);
        void Delete(DirectoryModel directoryModel);
        DirectoryModel Get();
        void Update(DirectoryModel directoryModel);
    }
}