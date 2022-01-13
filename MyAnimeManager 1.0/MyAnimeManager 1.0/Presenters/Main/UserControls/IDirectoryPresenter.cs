using MyAnimeManager_1._0.Forms;
using System;

namespace MyAnimeManager_1._0.Presenters.Main.Forms
{
    public interface IDirectoryPresenter
    {
        event EventHandler SelectDirectoryClickEventRaised;
        IDirectoryView GetDirectoryView();
    }
}