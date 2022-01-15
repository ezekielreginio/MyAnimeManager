using CommonComponents;
using DomainLayer.Models;
using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using MyAnimeManager_1._0.Views.Main.Forms;
using MyAnimeManager_1._0.Views.Main.UserControls;
using ServiceLayer.Services;
using ServiceLayer.Services.DirectoryServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MyAnimeManager_1._0.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        //Attributes
        //Main View Events
        public event EventHandler ViewProfileClickEventRaised;
        public event EventHandler ViewPlayerClickEventRaised;
        public event EventHandler FormClosedEventRaised;
        //Left Panel Events
        public event EventHandler ConnectToMALClickEventRaised;
        public event EventHandler AddToListClickEventRaised;
        public event EventHandler UpdateAnimeClickEventRaised;
        public event EventHandler DeleteAnimeClickEventRaised;
        public event EventHandler AuthenticationCodeObtainedEventRaised;
        public event EventHandler ProfileLoadedEventRaised;
        //DirectoryView Events
        public event EventHandler PlayAnimeClickEventRaised;
        //VidePlayer View Events
        public event EventHandler PlaylistSelectedChangedEventRaised;
        public event EventHandler PlayerItemChangedEventRaised;

        private IMainView _mainView;
        private IDirectoryView _directoryView;
        private ILoginView _loginView;
        private IProfileView _profileView;
        private IVideoPlayerView _videoPlayerView;

        private IDirectoryPresenter _directoryPresenter;

        private IRestfulService _restfulService;
        private IDirectoryServices _directoryServices;
        private IPlayerCacheServices _playerCacheServices;

        //Constructor
        public MainPresenter(IMainView mainView, 
                             IDirectoryView directoryView,
                             ILoginView loginView,
                             IProfileView profileView,
                             IVideoPlayerView videoPlayerView,
                             IDirectoryPresenter directoryPresenter,
                             IRestfulService restfulService,
                             IDirectoryServices directoryServices,
                             IPlayerCacheServices playerCacheServices)
        {
            //Views
            _mainView = mainView;
            _directoryView = directoryView;
            _loginView = loginView;
            _profileView = profileView;
            _videoPlayerView = videoPlayerView;
            //Presenters
            _directoryPresenter = directoryPresenter;
            //Services
            _restfulService = restfulService;
            _directoryServices = directoryServices;
            _playerCacheServices = playerCacheServices;
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
            _mainView.ViewProfileClickEventRaised += new EventHandler(OnViewProfileClickEventRaised);
            _mainView.ViewPlayerClickEventRaised += new EventHandler(OnViewPlayerClickEventRaised);
            _mainView.PlayAnimeClickEventRaised += new EventHandler(OnPlayAnimeClickEventRaised);
            _mainView.FormClosedEventRaised += new EventHandler(OnFormClosedEventRaised);

            _videoPlayerView.PlaylistSelectedChangedEventRaised += new EventHandler(OnPlaylistSelectedChangedEventRaised);
            _videoPlayerView.PlayerItemChangedEventRaised += new EventHandler(OnPlayerItemChangedEventRaised);

            _profileView.ConnectToMALClickEventRaised += new EventHandler(OnConnectToMALClickEventRaised);
            _profileView.AddToListClickEventRaised += new EventHandler(OnAddToListClickEventRaised);
            _profileView.UpdateAnimeClickEventRaised += new EventHandler(OnUpdateAnimeClickEventRaised);
            _profileView.DeleteAnimeClickEventRaised += new EventHandler(OnDeleteAnimeClickEventRaised);
            _profileView.ProfileLoadedEventRaised += new EventHandler(OnProfileLoadedEventRaised);
            _loginView.AuthenticationCodeObtainedEventRaised += new EventHandler(OnAuthenticationCodeObtainedEventRaised);
        }
        private async Task<bool> LoadProfile()
        {
            dynamic userData = await _restfulService.GetAnimeStatisticsUsingToken();
            _mainView.ShowLeftPanel();
            if (userData != null)
            {
                _profileView.SetUserData(userData);
                _profileView.ShowProfilePanel();
            }
            else
                _profileView.ShowLoginPanel();
            return true;
        }
        private void playIndex()
        {
            try
            {
                int position = _videoPlayerView.GetPlaylistBox().SelectedIndex;
                _videoPlayerView.GetPlayer().Ctlcontrols.stop();
                _videoPlayerView.GetPlayer().Ctlcontrols.currentItem = _videoPlayerView.GetPlayer().currentPlaylist.get_Item(position);
                _videoPlayerView.GetPlayer().Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void playAnime()
        {
            String title = _directoryPresenter.GetCurrentlySelected().GetTitle();
            String directory = _directoryServices.Get().DirectoryPath + @"\" + title;
            int animeID = _profileView.GetSelectedAnimeID();
            List<MediaFile> episodes = new List<MediaFile>();
            IWMPPlaylistArray plCollection = _videoPlayerView.GetPlayer().playlistCollection.getByName("Playlist 1");
            
            //Save Previous Player Cache
            if(animeID != -1)
            {
                PlayerCacheModel playerCacheModel = new PlayerCacheModel(_videoPlayerView.GetCurrentAnimeID(), _videoPlayerView.GetPlaylistBox().SelectedIndex, _videoPlayerView.GetPlayer().Ctlcontrols.currentPositionString);
                _playerCacheServices.UpdatePlayerCache(playerCacheModel);
            }
            //Reset Playlist
            _videoPlayerView.GetPlaylistBox().SelectedIndex = -1;
            if (plCollection.count > 0)
            {
                IWMPPlaylist pl = plCollection.Item(0);
                _videoPlayerView.GetPlayer().playlistCollection.remove(pl);
            }

            _videoPlayerView.SetCurrentAnimeID(animeID);
            _videoPlayerView.SetCurrentStatus(_profileView.GetCurrentStatus());
            

            IWMPPlaylist pList = _videoPlayerView.GetPlayer().playlistCollection.newPlaylist("Playlist 1");
            foreach (string file in Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).OrderBy(fi => fi).Where(s => s.EndsWith(".mp4") || s.EndsWith(".mkv")))
            {
                FileInfo fileInfo = new FileInfo(file);
                IWMPMedia media = _videoPlayerView.GetPlayer().newMedia(fileInfo.FullName);
                episodes.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fileInfo.Name), Path = fileInfo.FullName });
                pList.appendItem(media);
            }
            _videoPlayerView.GetPlaylistBox().DataSource = episodes;
            _videoPlayerView.GetPlaylistBox().DisplayMember = "FileName";
            _videoPlayerView.GetPlayer().currentPlaylist = pList;

            PlayerCacheModel cacheModel = _playerCacheServices.GetPlayerCache(animeID);
            if(cacheModel == null)
                _videoPlayerView.GetPlayer().Ctlcontrols.play();
            else
            {
                string duration = "00:00";
                if (!String.IsNullOrEmpty(cacheModel.duration))
                    duration = cacheModel.duration;
                _videoPlayerView.GetPlaylistBox().SelectedIndex = cacheModel.episode;
                _videoPlayerView.GetPlayer().Ctlcontrols.currentPosition = StringExtensions.GetDuration(duration);
                playIndex();
            }
        }

        //Event Handlers
        private async void OnViewProfileClickEventRaised(object sender, EventArgs e)
        {
            await LoadProfile();
            _mainView.OpenDirectory();
        }
        private void OnViewPlayerClickEventRaised(object sender, EventArgs e)
        {
            _mainView.HideLeftPanel();
            _mainView.OpenPlayerControl(_videoPlayerView.GetVideoPlayer());
        }
        private void OnPlayAnimeClickEventRaised(object sender, EventArgs e)
        {
            _mainView.HideLeftPanel();
            _mainView.OpenPlayerControl(_videoPlayerView.GetVideoPlayer());
            playAnime();
        }
        private void OnFormClosedEventRaised(object sender, EventArgs e)
        {
            PlayerCacheModel playerCacheModel = new PlayerCacheModel(_videoPlayerView.GetCurrentAnimeID(), _videoPlayerView.GetPlaylistBox().SelectedIndex, _videoPlayerView.GetPlayer().Ctlcontrols.currentPositionString);
            _playerCacheServices.UpdatePlayerCache(playerCacheModel);
        }
        private void OnPlaylistSelectedChangedEventRaised(object sender, EventArgs e)
        {
            playIndex();
            AnimeStatus animeStatus = new AnimeStatus(_videoPlayerView.GetCurrentAnimeID(), -1, "watching", _videoPlayerView.GetPlaylistBox().SelectedIndex + 1);
            if (_videoPlayerView.GetCurrentAnimeID() > 0 && (_videoPlayerView.GetCurrentStatus() == null || !_videoPlayerView.GetCurrentStatus().Equals("completed")))
                _restfulService.UpdateAnimeStatus(animeStatus);
        }
        private void OnPlayerItemChangedEventRaised(object sender, EventArgs e)
        {
            int startIndex = _videoPlayerView.GetPlayer().currentMedia.name.ToLower().IndexOf("ep");
            if(startIndex < 0)
                startIndex = _videoPlayerView.GetPlayer().currentMedia.name.ToLower().IndexOf("e");
            int ep = Int32.Parse(Regex.Match(_videoPlayerView.GetPlayer().currentMedia.name.Substring(startIndex), @"\d+").Value);
            _videoPlayerView.GetPlaylistBox().SelectedIndex = ep - 1;
            AnimeStatus animeStatus = new AnimeStatus(_videoPlayerView.GetCurrentAnimeID(), -1, "watching", _videoPlayerView.GetPlaylistBox().SelectedIndex+1);
            if(_videoPlayerView.GetCurrentAnimeID() > 0 && (_videoPlayerView.GetCurrentStatus() == null || !_videoPlayerView.GetCurrentStatus().Equals("completed")))
                _restfulService.UpdateAnimeStatus(animeStatus);
        }

        private void OnConnectToMALClickEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            _loginView.ShowLoginForm();
        }
        private async void OnAddToListClickEventRaised(object sender, EventArgs e)
        {
            _profileView.ShowLoadingPanel();
            AnimeStatus animeStatus = new AnimeStatus(_profileView.GetSelectedAnimeID(), -1, "plan_to_watch", -1);
            await _restfulService.UpdateAnimeStatus(animeStatus);
            _directoryPresenter.LoadAnimeData(_profileView.GetSelectedAnimeID());
        }
        private async void OnUpdateAnimeClickEventRaised(object sender, EventArgs e)
        {
            int score = -1;
            int currentEpisode = -1;
            string currentStatus = _profileView.GetCurrentStatus();
            _profileView.ShowLoadingPanel();
            if (!currentStatus.Equals("plan_to_watch"))
            {
                if (_profileView.GetScore() > 0)
                    score = 11-_profileView.GetScore();
                currentEpisode = _profileView.GetCurrentEpisode();
            }
            
            AnimeStatus animeStatus = new AnimeStatus(_profileView.GetSelectedAnimeID(), score, currentStatus, currentEpisode);
            await _restfulService.UpdateAnimeStatus(animeStatus);
            _directoryPresenter.LoadAnimeData(_profileView.GetSelectedAnimeID());
        }
        private async void OnDeleteAnimeClickEventRaised(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You Wish To Delete "+_profileView.GetTitle()+" From Your List?", "Delete From List?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _profileView.ShowLoadingPanel();
                await _restfulService.deleteAnime(_profileView.GetSelectedAnimeID());
                _directoryPresenter.LoadAnimeData(_profileView.GetSelectedAnimeID());
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
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
            await LoadProfile();
        }
    }
}
