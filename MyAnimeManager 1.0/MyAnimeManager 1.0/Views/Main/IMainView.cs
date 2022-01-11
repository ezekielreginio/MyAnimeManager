using System;

namespace MyAnimeManager_1._0
{
    public interface IMainView
    {
        event EventHandler SelectDirectoryClickEventRaised;
        void ShowMainView();
    }
}