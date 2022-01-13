using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0
{
    public interface IMainView
    {
        event EventHandler SelectDirectoryClickEventRaised;

        void OpenChildForm(Form childForm, object btnSender);
        void ShowMainView();
    }
}