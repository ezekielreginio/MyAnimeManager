using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Forms
{
    public partial class DirectoryView : Form, IDirectoryView
    {
        public event EventHandler SelectDirectoryClickEventRaised;
        public event EventHandler SearchBoxTextChangedEventRaised;
        public event EventHandler DirectoryLoadedEventRaised;
        public DirectoryView()
        {
            InitializeComponent();
        }
        public Form GetDirectoryForm()
        {
            return this;
        }
        public FlowLayoutPanel GetListViewDirectory()
        {
            return panelDirectoriesList;

        }
        public ImageList GetImageList()
        {
            return imageListFolders;
        }
        public String GetSearchText()
        {
            return bunifuTextBoxSearch.Text;
        }
        public void ShowDirectoryPanel()
        {
            panelDirectory.BringToFront();
        }
        public void ShowDirectoryListPanel()
        {
            panelDirectoriesList.BringToFront();
        }
        public void ShowNoDirectoryPanel()
        {
            panelNoDirectory.BringToFront();
        }
        public void ShowLoadingPanel()
        {
            panelDirectoryLoading.BringToFront();
        }
        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, SelectDirectoryClickEventRaised, e);
        }
        private void DirectoryView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, DirectoryLoadedEventRaised, e);
        }
        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(bunifuTextBoxSearch.Text))
                EventHelpers.RaiseEvent(this, SearchBoxTextChangedEventRaised, e);
        }

        private void bunifuTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                EventHelpers.RaiseEvent(this, SearchBoxTextChangedEventRaised, e);
        }
    }
}
