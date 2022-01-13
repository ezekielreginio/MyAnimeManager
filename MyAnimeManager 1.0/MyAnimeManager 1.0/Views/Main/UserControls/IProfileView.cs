using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.Main.UserControls
{
    public interface IProfileView
    {
        event EventHandler ProfileLoadedEventRaised;
        event EventHandler ConnectToMALClickEventRaised;
        UserControl GetProfileView();
        void SetAnimeDetails(dynamic animeDetails);
        void SetUserData(dynamic userData);
        void ShowProfileView();
        void ShowProfilePanel();
        void ShowAnimeDetailsPanel();
        void ShowLoginPanel();
    }
}