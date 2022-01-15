using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views.UserControls
{
    public interface IFolderItem
    {
        event EventHandler FolderClickEventRaised;

        UserControl GetFolderItem();
        int GetIndex();
        String GetTitle();

        void ShowItem();
        void HideItem();

        UserControl SetFolderIcon(String iconDirectory, String folderName);
        UserControl SetFolderIcon(String folderName);
    }
}