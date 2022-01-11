using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0.Views
{
    public partial class ErrorMessageView : Form, IErrorMessageView
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }

        //Public Methods
        public void ShowErrorMessageView(string windowTitle, string errorMessage)
        {
            this.Text = windowTitle;
            textBoxError.Text = errorMessage;
            this.ShowDialog();
            this.Close();
        }

        //Event Bindings:
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (textBoxError.Text != null)
            {
                System.Windows.Forms.Clipboard.SetText(textBoxError.Text);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
