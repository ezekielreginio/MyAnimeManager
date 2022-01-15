using DomainLayer.Models;
using ServiceLayer.CommonServices;
using ServiceLayer.Services.DirectoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Tests
{
    public class DirectoryServicesFixture
    {
        private IDirectoryServices _directoryServices;
        private DirectoryModel _directoryModel;

        public DirectoryServicesFixture()
        {
            DirectoryModel = new DirectoryModel();
            //DirectoryServices = new DirectoryServices(null, new ModelDataAnnotationCheck());

        }

        
        public IDirectoryServices DirectoryServices { get => _directoryServices; set => _directoryServices = value; }
        public DirectoryModel DirectoryModel { get => _directoryModel; set => _directoryModel = value; }
    }
}
