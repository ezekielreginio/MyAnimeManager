using System;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Forms
{
    public interface IDirectoryView
    {
        event EventHandler SelectDirectoryClickEventRaised;
        Form GetDirectoryForm();
    }
}