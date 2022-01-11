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
        public DirectoryView()
        {
            InitializeComponent();
        }

        public Form GetDirectoryForm()
        {
            return this;
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, SelectDirectoryClickEventRaised, e);
        }
    }
}
