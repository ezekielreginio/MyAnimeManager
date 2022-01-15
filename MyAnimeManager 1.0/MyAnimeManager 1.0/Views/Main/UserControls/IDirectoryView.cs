using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Forms
{
    public interface IDirectoryView
    {
        event EventHandler SearchBoxTextChangedEventRaised;
        event EventHandler SelectDirectoryClickEventRaised;
        event EventHandler DirectoryLoadedEventRaised;

        void ShowDirectoryPanel();
        void ShowDirectoryListPanel();
        void ShowNoDirectoryPanel();
        void ShowLoadingPanel();

        FlowLayoutPanel GetListViewDirectory();
        Form GetDirectoryForm();
        ImageList GetImageList();
        String GetSearchText();
    }
}