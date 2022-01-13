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

namespace MyAnimeManager_1._0.Views.UserControls
{
    public partial class FolderItem : UserControl, IFolderItem
    {
        public event EventHandler FolderClickEventRaised;
        private Action<string, int> _callback;
        private int _index = -1;
        public FolderItem()
        {
            InitializeComponent();
        }
        public FolderItem(Action<string, int> callback, int index)
        {
            InitializeComponent();
            _callback = callback;
            _index = index;
        }
        public FolderItem(String iconDirectory, String folderName)
        {
            InitializeComponent();
            pictureBoxFolderIcon.Image = Image.FromFile(iconDirectory);
            labelFolderName.Text = folderName;
        }

        public FolderItem(String folderName)
        {
            InitializeComponent();
            labelFolderName.Text = folderName;
        }

        public UserControl GetFolderItem()
        {
            return this;
        }

        public UserControl SetFolderIcon(String iconDirectory, String folderName)
        {
            Console.WriteLine("Icon Directory: " + iconDirectory);
            pictureBoxFolderIcon.Image = Image.FromFile(iconDirectory);
            labelFolderName.Text = folderName;

            return this;
        }

        public UserControl SetFolderIcon(String folderName)
        {
            labelFolderName.Text = folderName;

            return this;
        }

        public void SetSelected()
        {
            this.BackColor = Color.FromArgb(68, 71, 90);
        }

        public void Deselect()
        {
            this.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void labelFolderName_Click(object sender, EventArgs e)
        {
            _callback(labelFolderName.Text, _index);
        }

        private void pictureBoxFolderIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _callback(labelFolderName.Text, _index);
            }
            
        }
    }
}
