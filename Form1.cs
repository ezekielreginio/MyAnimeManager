using MyAnimeManager.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace MyAnimeManager
{
    public partial class Form1 : Form
    {
        List<string> listFiles = new List<string>();
        List<Panel> listPanel = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
        }

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

        string getIconPath(string folderPath)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            Win32.SHGetFileInfo(folderPath, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), (int)0x1000);
            return shinfo.szDisplayName;
        }

  
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listFiles.Clear();
            listViewFiles.Items.Clear();
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { Description = "Select your Anime Directory." })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string item in Directory.GetDirectories(folderBrowserDialog.SelectedPath))
                    {
                        //imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
                        //FileInfo fileInfo = new FileInfo(item);
                        //listFiles.Add(fileInfo.FullName);
                        //listViewFiles.Items.Add(fileInfo.Name,imageList1.Images.Count - 1);
                        //MessageBox.Show("Icon Path: " + getIconPath(directoryInfo.FullName));
                        DirectoryInfo directoryInfo = new DirectoryInfo(item);
                        ListViewItem viewItem = new ListViewItem();

                        Bitmap bp = new Bitmap(getIconPath(directoryInfo.FullName));
                        imageList1.Images.Add(bp);

                        AnimeDirectory animeDirectory = new AnimeDirectory(directoryInfo.FullName, directoryInfo.Name);

                        viewItem.Text = directoryInfo.Name;
                        viewItem.ImageIndex = imageList1.Images.Count - 1;
                        viewItem.Tag = animeDirectory;
                        listViewFiles.Items.Add(viewItem);
                    }
                    panelAnimeDirectory.BringToFront();
                }
            }
            //using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() { Description = "Select your Anime Directory." })
            //{
            //    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        foreach (string item in Directory.GetFiles(folderBrowserDialog.SelectedPath))
            //        {
            //            imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(item));
            //            FileInfo fi = new FileInfo(item);
            //            listViewFiles.Items.Add(fi.Name, imageList1.Images.Count - 1);
            //        }
            //    }
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listPanel.Add(panelAnimeDirectory);
            listPanel.Add(panelHome);
        }

        private void listViewFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listViewFiles.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            AnimeDirectory animeDirectory = (AnimeDirectory)info.Item.Tag;
            if (item != null)
            {
                labelAnimeFolderTitle.Text = animeDirectory.Name;
                panelAnimeFolder.BringToFront();
            }
        }
    }
}