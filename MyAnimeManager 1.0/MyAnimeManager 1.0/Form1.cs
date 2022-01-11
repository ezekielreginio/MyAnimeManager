using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAnimeManager_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
<<<<<<< HEAD
            random = new Random();
            //Open Directory Form
            OpenChildForm(new Forms.Directory(), null);
            //Console.WriteLine("Directory: " + AppDomain.CurrentDomain.BaseDirectory);
        }

        //Private Methods
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (IconPictureBox)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (IconPictureBox)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType() == typeof(IconPictureBox))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                }
            }
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == ThemeColor.ColorList.Count)
            {
                random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeDesktopForm != null)
            {
                activeDesktopForm.Close();
            }
            activeDesktopForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //Event Bindings
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
=======
>>>>>>> parent of 46f95da (Desktop UI Finished)
        }
    }
}
