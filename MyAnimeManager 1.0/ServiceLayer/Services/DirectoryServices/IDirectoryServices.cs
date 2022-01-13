using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DirectoryServices
{
    public interface IDirectoryServices
    {
        void ValidateModel(DirectoryModel directoryModel);
        DirectoryModel Add(String directory);
        DirectoryModel Get();
    }
}
