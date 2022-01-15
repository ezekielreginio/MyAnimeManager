using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using CommonComponents;
using FontAwesome.Sharp;
using MyAnimeManager_1._0.Classes;
using MyAnimeManager_1._0.Forms;
using MyAnimeManager_1._0.Presenters.Main.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace MyAnimeManager_1._0
{
    public partial class MainView : Form, IMainView
    {
        //Fields
        private IconPictureBox currentButton;
        private Form activeDesktopForm;
        private UserControl activeDesktopControl;
        private UserControl activeLeftPanel;
        private UserControl playerControl;
        private Form formDirectory;
        private Random random;
        private int tempIndex;

        //Event Handlers
        public event EventHandler ViewProfileClickEventRaised;
        public event EventHandler ViewPlayerClickEventRaised;
        public event EventHandler PlayAnimeClickEventRaised;
        public event EventHandler FormClosedEventRaised;


        //Constructor
        public MainView()
        {
            InitializeComponent();
            random = new Random();
        }

        //Public Methods

        public void ShowMainView()
        {
            this.Show();
        }

        public void ShowRightClickOnFolder()
        {
            contextMenuFolderRightClick.Show(Cursor.Position);
        }

        //Private Methods
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconPictureBox)btnSender)
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
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconPictureBox))
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
        //Public Methods
        public void OpenChildForm(Form childForm, object btnSender)
        {
            activeDesktopForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            if(formDirectory == null)
            {
                formDirectory = childForm;
                this.panelDesktop.Controls.Add(childForm);
                this.panelDesktop.Tag = childForm;
            }
            childForm.BringToFront();
            childForm.Show();
        }

        public void OpenDirectory()
        {
            if (formDirectory != null)
            {
                formDirectory.BringToFront();
                formDirectory.Show();
            }
        }

        public void OpenLeftPanel(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            this.panelLeft.Controls.Add(userControl);
            this.panelLeft.Tag = userControl;
            userControl.BringToFront();
            userControl.Show();
        }
        public void OpenDesktopControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(userControl);
            this.panelDesktop.Tag = userControl;
            userControl.BringToFront();
            userControl.Show();
        }
        public void OpenPlayerControl(UserControl playerControl)
        {
            if(this.playerControl == null)
            {
                playerControl.Dock = DockStyle.Fill;
                this.playerControl = playerControl;
                this.panelDesktop.Controls.Add(playerControl);
                this.panelDesktop.Tag = playerControl;
            }
            this.playerControl.BringToFront();
            this.playerControl.Show();
        }
        public void ShowLeftPanel()
        {
            panelLeft.Show();
        }
        public void HideLeftPanel()
        {
            panelLeft.Hide();
        }

        //Private Methods
        private void DisposeDesktopControls()
        {
            if (activeDesktopForm != null)
            {
                activeDesktopForm.Close();
            }
            if (activeDesktopControl != null)
            {
                activeDesktopControl.Dispose();
            }
        }

        //Event Bindings
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            
                currentButton = (IconPictureBox)sender;
                EventHelpers.RaiseEvent(this, ViewProfileClickEventRaised, e);
                ActivateButton(sender);
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            if (currentButton != (IconPictureBox)sender)
            {
                currentButton = (IconPictureBox)sender;
                EventHelpers.RaiseEvent(this, ViewPlayerClickEventRaised, e);
                ActivateButton(sender);
            }
        }

        private void playAnimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, PlayAnimeClickEventRaised, e);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, FormClosedEventRaised, e);
        }
    }
}
