using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeManager_1._0.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        //Attributes

        IMainView _mainView;

        //Constructor
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            SubscribeToEventsSetup();
        }

        //Public Methods
        public IMainView GetMainView()
        {
            return _mainView;
        }

        //Private Methods
        private void SubscribeToEventsSetup()
        {
            _mainView.SelectDirectoryClickEventRaised += new EventHandler(OnAddDirectoryClickEventRaised);
        }

        private void OnAddDirectoryClickEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");
        }

        
    }
}
