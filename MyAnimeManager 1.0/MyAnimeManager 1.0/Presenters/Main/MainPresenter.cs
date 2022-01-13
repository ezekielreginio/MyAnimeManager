using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using MyAnimeManager_1._0.Views.Main.Forms;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeManager_1._0.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        //Attributes
        public event EventHandler SelectDirectoryClickEventRaised;
        public event EventHandler AuthenticationCodeObtainedEventRaised;

        IMainView _mainView;
        IDirectoryView _directoryView;
        ILoginView _loginView;

        IDirectoryPresenter _directoryPresenter;

        IRestfulService _restfulService;

        //Constructor
        public MainPresenter(IMainView mainView, IDirectoryView directoryView, IDirectoryPresenter directoryPresenter, ILoginView loginView, IRestfulService restfulService)
        {
            _mainView = mainView;
            _directoryView = directoryView;
            _loginView = loginView;

            _directoryPresenter = directoryPresenter;

            _restfulService = restfulService;
            _mainView.OpenChildForm(_directoryView.GetDirectoryForm(), null);
            
            SubscribeToEventsSetup();
        }

        //Public Methods
        public IMainView GetMainView()
        {
            return _mainView;
        }

        //Private Methods
        private void SubscribeToEventsSetup()
        {
            _mainView.SelectDirectoryClickEventRaised += new EventHandler(OnAddDirectoryClickEventRaised);
            _loginView.AuthenticationCodeObtainedEventRaised += new EventHandler(OnAuthenticationCodeObtainedEventRaised);
        }

        private void OnAddDirectoryClickEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            _loginView.ShowLoginForm();
        }

        private void OnAuthenticationCodeObtainedEventRaised(object sender, EventArgs e)
        {
            String authCode = ((LoginView)sender).GetCode();
            Console.WriteLine("Code From Presenter:" + ((LoginView)sender).GetCode());
            _restfulService.LoginUser(authCode);
        }

    }
}
