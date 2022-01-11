using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using MyAnimeManager_1._0.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
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
                AppDomain.CurrentDomain.BaseDirectory+ @"MyAnimeManager.sqlite;Version = 3;";

            UnityC = new UnityContainer()
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryView, DirectoryView>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryPresenter, DirectoryPresenter>(new ContainerControlledLifetimeManager());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();

            IMainView mainView = mainPresenter.GetMainView();

            Application.Run((MainView)mainView);
        }
    }
}
