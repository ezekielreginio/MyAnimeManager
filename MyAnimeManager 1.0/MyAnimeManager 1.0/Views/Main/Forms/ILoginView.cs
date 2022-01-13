using System;

namespace MyAnimeManager_1._0.Views.Main.Forms
{
    public interface ILoginView
    {
        event EventHandler AuthenticationCodeObtainedEventRaised;
        void ShowLoginForm();
        String GetCode();
    }
}