using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Forms
{
    public interface IDirectoryView
    {
        event EventHandler SelectDirectoryClickEventRaised;
        event EventHandler DirectoryLoadedEventRaised;

        void ShowDirectoryPanel();
        void ShowNoDirectoryPanel();

        FlowLayoutPanel GetListViewDirectory();
        Form GetDirectoryForm();
        ImageList GetImageList();
    }
}