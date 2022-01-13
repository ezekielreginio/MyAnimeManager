using CommonComponents;
using DomainLayer.Models;
using MyAnimeManager_1._0.Forms;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Presenters.Main.Forms
{
    public class DirectoryPresenter : IDirectoryPresenter
    {
        //Attributes
        public event EventHandler SelectDirectoryClickEventRaised;
        public event EventHandler DirectoryLoadedEventRaised;

        IDirectoryView _directoryView;
        IDirectoryServices _directoryServices;
        IRestfulService _restfulService;
        IFolderItem _folderItem;

        private List<FolderItem> listFolderItems = new List<FolderItem>();
        private FolderItem currentlySelected;

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
                                  IDirectoryServices directoryServices,
                                  IRestfulService restfulService,
                                  IFolderItem folderItem)
        {
            _directoryView = directoryView;
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

        //Private Methods
        private void SubscribeToEventsSetup()
        {
            _directoryView.DirectoryLoadedEventRaised += new EventHandler(OnDirectoryLoadedEventRaised);
            _directoryView.SelectDirectoryClickEventRaised += new EventHandler(OnAddDirectoryClickEventRaised);
        }

        private string GetIconPath(String folderPath)
        {
            //SHFILEINFO shinfo = new SHFILEINFO();
            //Win32.SHGetFileInfo(folderPath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), (int)0x1000);
            //Console.WriteLine("Icon Path: "+shinfo.szDisplayName);
            //if(shinfo.szDisplayName.Equals(@"C:\WINDOWS\system32\imageres.dll"))
            //    return null;
            //else
            //    return shinfo.szDisplayName;
            string[] filePaths = Directory.GetFiles(folderPath, "*.ico", SearchOption.AllDirectories);
            if (filePaths.Count() > 0)
                return filePaths[0];
            else
                return null;
        }


        private void LoadDirectory(DirectoryModel model)
        {
            _directoryView.GetListViewDirectory().Controls.Clear();
            listFolderItems.Clear();
            //_directoryView.GetDirectoryListPanel().Controls.Clear();
            int loopCtr = 0;
            foreach (string item in Directory.GetDirectories(model.DirectoryPath).OrderBy(fi => fi))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(item);
                ListViewItem viewItem = new ListViewItem();
                string iconPath = GetIconPath(directoryInfo.FullName);
                FolderItem folderItem = new FolderItem(CallbackOnFolderLeftClick, loopCtr);
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
        private void CallbackOnFolderLeftClick(String folderName, int index)
        {
            Console.WriteLine("Folder Name: " + folderName);
            if (currentlySelected != null)
                currentlySelected.Deselect();
            currentlySelected = listFolderItems[index];
            listFolderItems[index].SetSelected();
            
        }
    }
}
