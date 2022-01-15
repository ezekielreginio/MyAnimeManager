using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Views.UserControls;
using System;

namespace MyAnimeManager_1._0.Presenters.Main.Forms
{
    public interface IDirectoryPresenter
    {
        event EventHandler SelectDirectoryClickEventRaised;
        FolderItem GetCurrentlySelected();
        void LoadAnimeData(int animeID);
        IDirectoryView GetDirectoryView();
    }
}