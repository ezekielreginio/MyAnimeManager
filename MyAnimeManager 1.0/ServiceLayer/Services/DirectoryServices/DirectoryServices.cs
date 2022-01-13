using CommonComponents;
using DomainLayer.Models;
using InfrastructureLayer.DataAccess.Repositories.Specific.Directory;
using ServiceLayer.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DirectoryServices
{
    public class DirectoryServices: IDirectoryServices
    {
        IDirectoryRepository _directoryRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DirectoryServices(IDirectoryRepository directoryRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _directoryRepository = directoryRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public DirectoryModel Add(String directory)
        {
            DirectoryModel model = new DirectoryModel();   
            model.DirectoryPath = directory;
            _directoryRepository.Add(model);

            return model;
        }

        public void Delete(DirectoryModel departmentModel)
        {
            throw new NotImplementedException();
        }

        public DirectoryModel Get()
        {
            try
            {
                DirectoryModel model = _directoryRepository.Get();
                Console.WriteLine("Current Directory: " +model.DirectoryPath);
                return model;
            }
            catch(DataAccessException e)
            {
                Console.WriteLine("Directory Not Found");
                return null;
            }
             
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
