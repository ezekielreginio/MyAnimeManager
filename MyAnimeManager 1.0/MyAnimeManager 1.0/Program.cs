using InfrastructureLayer.DataAccess.Repositories;
using InfrastructureLayer.DataAccess.Repositories.Specific.Directory;
using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using MyAnimeManager_1._0.Views;
using MyAnimeManager_1._0.Views.Main.Forms;
using MyAnimeManager_1._0.Views.Main.UserControls;
using MyAnimeManager_1._0.Views.UserControls;
using ServiceLayer.CommonServices;
using ServiceLayer.Services;
using ServiceLayer.Services.DirectoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace MyAnimeManager_1._0
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;

            string _connectionString = "Data Source = " +
                AppDomain.CurrentDomain.BaseDirectory+ @"MyAnimeManager.sqlite";
            Console.WriteLine("SQLite Directory: "+_connectionString);
            UnityC = new UnityContainer()
                //Views
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryView, DirectoryView>(new ContainerControlledLifetimeManager())
                .RegisterType<ILoginView, LoginView>(new ContainerControlledLifetimeManager())
                .RegisterType<IProfileView, ProfileView>(new ContainerControlledLifetimeManager())
                .RegisterType<IVideoPlayerView, VideoPlayerView>(new ContainerControlledLifetimeManager())
                .RegisterType<IFolderItem, FolderItem>(new ContainerControlledLifetimeManager())
                //Presenters
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryPresenter, DirectoryPresenter>(new ContainerControlledLifetimeManager())
                //Repositories
                .RegisterType<IRestfulRepository, RestfulRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IDirectoryRepository, DirectoryRepository>(new InjectionConstructor(_connectionString))
                .RegisterType<IPlayerCacheRepository, PlayerCacheRepository>(new InjectionConstructor(_connectionString))
                //Services
                .RegisterType<IRestfulService, RestfulService>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryServices, DirectoryServices>(new ContainerControlledLifetimeManager())
                .RegisterType<IPlayerCacheServices, PlayerCacheServices>(new ContainerControlledLifetimeManager())
                //Annotation Checker
                .RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>(new ContainerControlledLifetimeManager());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();

            IMainView mainView = mainPresenter.GetMainView();

            Application.Run((MainView)mainView);
        }
    }
}
