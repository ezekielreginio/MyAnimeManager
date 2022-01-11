using MyAnimeManager_1._0.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Presenters.Main.Forms
{
    public class DirectoryPresenter : IDirectoryPresenter
    {
        //Attributes
        IDirectoryView _directoryView;

        public DirectoryPresenter(IDirectoryView directoryView)
        {
            _directoryView = directoryView;
            SubscribeToEventsSetup();
        }

        public IDirectoryView GetDirectoryView()
        {
            return _directoryView;
        }

        private void SubscribeToEventsSetup()
        {
            _directoryView.SelectDirectoryClickEventRaised += new EventHandler(OnAddDirectoryClickEventRaised);
        }

        private void OnAddDirectoryClickEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { Description = "Select your Anime Directory." })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
