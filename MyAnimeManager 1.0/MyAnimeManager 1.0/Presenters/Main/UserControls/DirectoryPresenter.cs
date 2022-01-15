using CommonComponents;
using DomainLayer.Models;
using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Views.Main.UserControls;
using MyAnimeManager_1._0.Views.UserControls;
using ServiceLayer.Services;
using ServiceLayer.Services.DirectoryServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Presenters.Main.Forms
{
    public class DirectoryPresenter : IDirectoryPresenter
    {
        //Attributes
        public event EventHandler SelectDirectoryClickEventRaised;
        public event EventHandler SearchBoxTextChangedEventRaised;
        public event EventHandler DirectoryLoadedEventRaised;

        IDirectoryView _directoryView;
        IProfileView _profileView;
        IMainView _mainView;
        IDirectoryServices _directoryServices;
        IRestfulService _restfulService;
        IFolderItem _folderItem;

        private List<FolderItem> listFolderItems = new List<FolderItem>();
        private FolderItem currentlySelected;

        private Thread searchThread;

        //-------------------------------------------------  (START) GET STOCK ICON -----------------------------------------------------------------------//
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        class Win32
        {
            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
        }

        //Constants flags for SHGetFileInfo 
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon

        //Get Default Fodler Icon
        private static Icon folderIcon;

        public static Icon FolderLarge => folderIcon ?? (folderIcon = GetStockIcon(SHSIID_FOLDER, SHGSI_LARGEICON));

        private static Icon GetStockIcon(uint type, uint size)
        {
            var info = new SHSTOCKICONINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);

            SHGetStockIconInfo(type, SHGSI_ICON | size, ref info);

            var icon = (Icon)Icon.FromHandle(info.hIcon).Clone(); // Get a copy that doesn't use the original handle
            DestroyIcon(info.hIcon); // Clean up native icon to prevent resource leak

            return icon;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public int iSysIconIndex;
            public int iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        [DllImport("shell32.dll")]
        public static extern int SHGetStockIconInfo(uint siid, uint uFlags, ref SHSTOCKICONINFO psii);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr handle);

        private const uint SHSIID_FOLDER = 0x4;
        private const uint SHGSI_ICON = 0x100;
        private const uint SHGSI_LARGEICON = 0x000000000;
        private const uint SHGSI_SMALLICON = 0x1;

        //-------------------------------------------------  (END GET STOCK ICON -----------------------------------------------------------------------//

        public DirectoryPresenter(IDirectoryView directoryView,
                                  IProfileView profileView,
                                  IMainView mainView,
                                  IDirectoryServices directoryServices,
                                  IRestfulService restfulService,
                                  IFolderItem folderItem)
        {
            _directoryView = directoryView;
            _profileView = profileView;
            _mainView = mainView;
            _directoryServices = directoryServices;
            _restfulService = restfulService;
            _folderItem = folderItem;
            SubscribeToEventsSetup();
            //DirectoryModel model = _directoryServices.Get();
            //if(model != null)
            //{
            //    _directoryView.ShowDirectoryPanel();
            //}
                
            //else
            //    _directoryView.ShowNoDirectoryPanel();

        }
        //Public Methods
        public IDirectoryView GetDirectoryView()
        {
            return _directoryView;
        }

        public async void LoadAnimeData(int animeID)
        {
            dynamic animeDetails = await _restfulService.GetAnimeDetailsByID(animeID);
            if (animeDetails != null)
            {
                Console.WriteLine(animeDetails);
                _profileView.SetSelectedAnimeID((int)animeDetails["id"]);
                _profileView.SetAnimeDetails(animeDetails);
                _profileView.ShowAnimeDetailsPanel();
            }
            else
                MessageBox.Show("Anime Not Found. The name of the folder should be exactly the same as shown in MAL");
        }

        public FolderItem GetCurrentlySelected()
        {
            return currentlySelected;
        }

        //Private Methods
        private void SubscribeToEventsSetup()
        {
            _directoryView.DirectoryLoadedEventRaised += new EventHandler(OnDirectoryLoadedEventRaised);
            _directoryView.SearchBoxTextChangedEventRaised += new EventHandler(OnSearchBoxTextChangedEventRaised);
            _directoryView.SelectDirectoryClickEventRaised += new EventHandler(OnAddDirectoryClickEventRaised);
        }

        
        private string GetIconPath(String folderPath)
        {
            string[] filePaths = Directory.GetFiles(folderPath, "*.ico", SearchOption.AllDirectories);
            if (filePaths.Count() > 0)
                return filePaths[0];
            else
                return null;
        }

        private void ThreadLoadDirectory(DirectoryModel model, String filter = "")
        {
            _directoryView.GetListViewDirectory().Invoke(new Action(delegate
            {
                
                _directoryView.GetListViewDirectory().Controls.Clear();
                
            }));
            _directoryView.GetDirectoryForm().Invoke(new Action(delegate
            {
                _directoryView.ShowLoadingPanel();
            }));
            listFolderItems.Clear();
            //_directoryView.GetDirectoryListPanel().Controls.Clear();
            int loopCtr = 0;
            foreach (string item in Directory.GetDirectories(model.DirectoryPath).OrderBy(fi => fi))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(item);
                if (directoryInfo.Name.ToLower().Contains(filter.ToLower()))
                {
                    ListViewItem viewItem = new ListViewItem();
                    string iconPath = GetIconPath(directoryInfo.FullName);
                    FolderItem folderItem = new FolderItem(
                        CallbackOnFolderLeftClick,
                        CallbackOnFolderRightClick,
                        loopCtr
                        );
                    folderItem.Name = directoryInfo.Name;
                    if (!String.IsNullOrEmpty(iconPath))
                        folderItem = (FolderItem)folderItem.SetFolderIcon(iconPath, directoryInfo.Name);
                    else
                        folderItem = (FolderItem)folderItem.SetFolderIcon(directoryInfo.Name);

                    _directoryView.GetListViewDirectory().Invoke(new Action(delegate
                    {
                        _directoryView.GetListViewDirectory().Controls.Add(folderItem);
                    }));

                    listFolderItems.Add((FolderItem)folderItem);
                    loopCtr++;
                }
            }
            Console.WriteLine("counter: " + loopCtr);
            _directoryView.GetDirectoryForm().Invoke(new Action(delegate
            {
                _directoryView.ShowDirectoryListPanel();
            }));
        }

        private void LoadDirectory(DirectoryModel model, String filter = "")
        {
            _directoryView.GetListViewDirectory().Controls.Clear();
            listFolderItems.Clear();
            int loopCtr = 0;
            foreach (string item in Directory.GetDirectories(model.DirectoryPath).OrderBy(fi => fi))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(item);
                if (directoryInfo.Name.ToLower().Contains(filter.ToLower()))
                {
                    ListViewItem viewItem = new ListViewItem();
                    string iconPath = GetIconPath(directoryInfo.FullName);
                    FolderItem folderItem = new FolderItem(
                        CallbackOnFolderLeftClick, 
                        CallbackOnFolderRightClick, 
                        loopCtr
                        );
                    folderItem.Name = directoryInfo.Name;
                    if (!String.IsNullOrEmpty(iconPath))
                    {
                        folderItem = (FolderItem)folderItem.SetFolderIcon(iconPath, directoryInfo.Name);
                        _directoryView.GetListViewDirectory().Controls.Add(folderItem);
                    }
                    else
                    {
                        folderItem = (FolderItem)folderItem.SetFolderIcon(directoryInfo.Name);
                        _directoryView.GetListViewDirectory().Controls.Add(folderItem);
                    }
                    listFolderItems.Add((FolderItem)folderItem);
                    loopCtr++;
                }
            }
            Console.WriteLine("counter: "+ loopCtr);

            _directoryView.ShowDirectoryPanel();
        }

        //Event Handlers
        private void OnDirectoryLoadedEventRaised(object sender, EventArgs e)
        {
            DirectoryModel model = _directoryServices.Get();
            if (model != null)
                LoadDirectory(model);
            else
                _directoryView.ShowNoDirectoryPanel();
        }
        private void OnSearchBoxTextChangedEventRaised(object sender, EventArgs e)
        {
            Console.WriteLine("Text Search: " + _directoryView.GetSearchText());
            DirectoryModel model = _directoryServices.Get();
            if(searchThread != null)
            {
                searchThread.Abort();
                _directoryView.GetListViewDirectory().Controls.Clear();
                listFolderItems.Clear();
            }
            if (model != null)
            {
                searchThread = new Thread(()=> ThreadLoadDirectory(model, _directoryView.GetSearchText()));
                searchThread.Start();
            }
        }
        private void OnAddDirectoryClickEventRaised(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { Description = "Select your Anime Directory." })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryModel model = _directoryServices.Add(folderBrowserDialog.SelectedPath);
                    LoadDirectory(model);
                }
            }
        }
        //Callbacks
        private async void CallbackOnFolderLeftClick(String folderName, int index)
        {
            if (currentlySelected != null)
                currentlySelected.Deselect();
            currentlySelected = listFolderItems[index];
            listFolderItems[index].SetSelected();
            dynamic animeDetails = await _restfulService.GetAnimeDetails(folderName);
            if (animeDetails != null)
            {
                Console.WriteLine(animeDetails);
                _profileView.SetSelectedAnimeID((int)animeDetails["id"]);
                _profileView.SetAnimeDetails(animeDetails);
                _profileView.ShowAnimeDetailsPanel();
            }
            else
                MessageBox.Show("Anime Not Found. The name of the folder should be exactly the same as shown in MAL");
        }
        private async void CallbackOnFolderRightClick(String folderName, int index)
        {
            
            if (currentlySelected != null)
                currentlySelected.Deselect();
            currentlySelected = listFolderItems[index];
            listFolderItems[index].SetSelected();
            dynamic animeDetails = await _restfulService.GetAnimeDetails(folderName);
            _mainView.ShowRightClickOnFolder();
            if (animeDetails != null)
            {
                Console.WriteLine(animeDetails);
                _profileView.SetSelectedAnimeID((int)animeDetails["id"]);
                _profileView.SetAnimeDetails(animeDetails);
                _profileView.ShowAnimeDetailsPanel();
            }
            else
                MessageBox.Show("Anime Not Found. The name of the folder should be exactly the same as shown in MAL");
        }
    }
}
