using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DirectoryServices
{
    public interface IDirectoryRepository
    {
        void Add(DirectoryModel departmentModel);
        void Update(DirectoryModel departmentModel);
        void Delete(DirectoryModel departmentModel);
        DirectoryModel Get();
    }
}
