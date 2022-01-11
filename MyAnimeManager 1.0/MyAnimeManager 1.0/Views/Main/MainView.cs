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
        private Random random;
        private int tempIndex;
        private IUnityContainer UnityC;

        //Event Handlers
        public event EventHandler SelectDirectoryClickEventRaised;

        //Constructor
        public MainView()
        {
            InitializeComponent();
            random = new Random();
            UnityC = new UnityContainer()
                .RegisterType<IDirectoryView, DirectoryView>(new ContainerControlledLifetimeManager())
                .RegisterType<IDirectoryPresenter, DirectoryPresenter>(new ContainerControlledLifetimeManager());

            //Open Directory Form
            IDirectoryPresenter directoryPresenter = UnityC.Resolve<DirectoryPresenter>();
            IDirectoryView directoryView = directoryPresenter.GetDirectoryView();
            OpenChildForm(directoryView.GetDirectoryForm(), null);
            Console.WriteLine("Directory: " + AppDomain.CurrentDomain.BaseDirectory);
        }

        //Public Methods

        public void ShowMainView()
        {
            this.Show();
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

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeDesktopForm != null)
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
        }

        private void buttonConenctMAL_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, SelectDirectoryClickEventRaised, e);
        }
    }
}
