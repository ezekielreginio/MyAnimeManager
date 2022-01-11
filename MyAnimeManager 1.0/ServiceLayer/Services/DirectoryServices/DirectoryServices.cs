using DomainLayer.Models;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DirectoryServices
{
    public class DirectoryServices: IDirectoryServices, IDirectoryRepository
    {
        IDirectoryRepository _directoryRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DirectoryServices(IDirectoryRepository directoryRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _directoryRepository = directoryRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public void Add(DirectoryModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(DirectoryModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public DirectoryModel Get()
        {
            throw new NotImplementedException();
        }

        public void Update(DirectoryModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(DirectoryModel directoryModel)
        {
            _modelDataAnnotationCheck.ValidateModel(directoryModel);
        }
    }
}
