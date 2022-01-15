using AxWMPLib;
using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.Main.UserControls
{
    public partial class VideoPlayerView : UserControl, IVideoPlayerView
    {
        public event EventHandler PlayerItemChangedEventRaised;
        public event EventHandler PlaylistSelectedChangedEventRaised;

        private int CurrentAnimeID;
        private string CurrentStatus;
        public VideoPlayerView()
        {
            InitializeComponent();
        }
        //Public Methods
        //Setter Methods
        public void SetCurrentAnimeID(int animeID)
        {
            CurrentAnimeID = animeID;
        }
        public void SetCurrentStatus(String currentStatus)
        {
            CurrentStatus = currentStatus;
        }
        //Getter Methods
        public int GetCurrentAnimeID()
        { 
            return CurrentAnimeID; 
        }
        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }
        public UserControl GetVideoPlayer()
        {
            return this;
        }
        public ListBox GetPlaylistBox()
        {
            return listBoxPlaylist;
        }
        public AxWindowsMediaPlayer GetPlayer()
        {
            return axWindowsMediaPlayer1;
        }

        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, PlaylistSelectedChangedEventRaised, e);
        }

        private void axWindowsMediaPlayer1_CurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e)
        {
            EventHelpers.RaiseEvent(this, PlayerItemChangedEventRaised, e);
        }
    }
}
