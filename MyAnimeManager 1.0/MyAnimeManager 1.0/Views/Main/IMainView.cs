using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0
{
    public interface IMainView
    {
        event EventHandler ViewProfileClickEventRaised;
        event EventHandler ViewPlayerClickEventRaised;
        event EventHandler PlayAnimeClickEventRaised;
        event EventHandler FormClosedEventRaised;

        void OpenChildForm(Form childForm, object btnSender);
        void OpenDirectory();
        void OpenLeftPanel(UserControl userControl);
        void OpenDesktopControl(UserControl userControl);
        void OpenPlayerControl(UserControl playerControl);
        void ShowMainView();
        void ShowRightClickOnFolder();
        void ShowLeftPanel();
        void HideLeftPanel();
    }
}