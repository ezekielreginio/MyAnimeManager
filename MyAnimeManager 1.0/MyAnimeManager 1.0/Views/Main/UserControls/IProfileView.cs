using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.Main.UserControls
{
    public interface IProfileView
    {
        event EventHandler ProfileLoadedEventRaised;
        event EventHandler ConnectToMALClickEventRaised;
        event EventHandler AddToListClickEventRaised;
        event EventHandler UpdateAnimeClickEventRaised;
        event EventHandler DeleteAnimeClickEventRaised;
        UserControl GetProfileView();

        int GetSelectedAnimeID();
        int GetScore();
        string GetTitle();
        int GetCurrentEpisode();
        string GetCurrentStatus();
        void SetAnimeDetails(dynamic animeDetails);
        void SetUserData(dynamic userData);
        void SetSelectedAnimeID(int selectedAnimeID);
        void ShowProfileView();
        void ShowProfilePanel();
        void ShowAnimeDetailsPanel();
        void ShowLoginPanel();
        void ShowLoadingPanel();
    }
}