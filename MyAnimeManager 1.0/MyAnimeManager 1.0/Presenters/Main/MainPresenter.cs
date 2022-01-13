using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using MyAnimeManager_1._0.Views.Main.Forms;
using MyAnimeManager_1._0.Views.Main.UserControls;
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
        public event EventHandler ConnectToMALClickEventRaised;
        public event EventHandler AuthenticationCodeObtainedEventRaised;
        public event EventHandler ProfileLoadedEventRaised;

        IMainView _mainView;
        IDirectoryView _directoryView;
        ILoginView _loginView;
        IProfileView _profileView;

        IDirectoryPresenter _directoryPresenter;

        IRestfulService _restfulService;

        //Constructor
        public MainPresenter(IMainView mainView, 
                             IDirectoryView directoryView,
                             ILoginView loginView,
                             IProfileView profileView,
                             IDirectoryPresenter directoryPresenter,
                             IRestfulService restfulService)
        {
            //Views
            _mainView = mainView;
            _directoryView = directoryView;
            _loginView = loginView;
            _profileView = profileView;
            //Presenters
            _directoryPresenter = directoryPresenter;
            //Services
            _restfulService = restfulService;

            //Initialize Mainform Panels
            _mainView.OpenChildForm(_directoryView.GetDirectoryForm(), null);
            _mainView.OpenLeftPanel(_profileView.GetProfileView());
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
            _profileView.ConnectToMALClickEventRaised += new EventHandler(OnConnectToMALClickEventRaised);
            _profileView.ProfileLoadedEventRaised += new EventHandler(OnProfileLoadedEventRaised);
            _loginView.AuthenticationCodeObtainedEventRaised += new EventHandler(OnAuthenticationCodeObtainedEventRaised);
        }

        private void OnConnectToMALClickEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            _loginView.ShowLoginForm();
        }

        private async void OnAuthenticationCodeObtainedEventRaised(object sender, EventArgs e)
        {
            String authCode = ((LoginView)sender).GetCode();
            Console.WriteLine("Code From Presenter:" + ((LoginView)sender).GetCode());
            dynamic userData = await _restfulService.LoginUser(authCode);
            if (userData != null)
            {
                Console.WriteLine("User Data Available: " + userData["name"]);
                _profileView.SetUserData(userData);
                _profileView.ShowProfilePanel();
            }
        }
        private async void OnProfileLoadedEventRaised(object sender, EventArgs e)
        {
            dynamic userData = await _restfulService.GetAnimeStatisticsUsingToken();
            if(userData != null)
            {
                _profileView.SetUserData(userData);
                _profileView.ShowProfilePanel();
            }
            else
            {
                _profileView.ShowLoginPanel();

            }
        }
    }
}
