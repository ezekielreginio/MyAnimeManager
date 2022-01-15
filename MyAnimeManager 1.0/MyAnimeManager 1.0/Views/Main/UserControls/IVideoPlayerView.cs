using AxWMPLib;
using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.Main.UserControls
{
    public interface IVideoPlayerView
    {
        event EventHandler PlayerItemChangedEventRaised;
        event EventHandler PlaylistSelectedChangedEventRaised;

        void SetCurrentAnimeID(int animeID);
        void SetCurrentStatus(String currentStatus);

        int GetCurrentAnimeID();
        string GetCurrentStatus();
        UserControl GetVideoPlayer();
        AxWindowsMediaPlayer GetPlayer();
        ListBox GetPlaylistBox();
    }
}