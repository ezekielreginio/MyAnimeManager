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

namespace MyAnimeManager_1._0.Views.Main.UserControls
{
    public partial class ProfileView : UserControl, IProfileView
    {
        //Event Handlers
        public event EventHandler ConnectToMALClickEventRaised;
        public event EventHandler ProfileLoadedEventRaised;
        public ProfileView()
        {
            InitializeComponent();
        }

        //Public Methods
        public UserControl GetProfileView()
        {
            return this;
        }
        public void SetUserData(dynamic userData)
        {
            labelUsername.Text = userData["name"]+"'s Profile";
            labelWatching.Text = userData["anime_statistics"]["num_items_watching"];
            labelCompleted.Text = userData["anime_statistics"]["num_items_completed"];
            labelOnHold.Text = userData["anime_statistics"]["num_items_on_hold"];
            labelDropped.Text = userData["anime_statistics"]["num_items_dropped"];
            labelPlanToWatch.Text = userData["anime_statistics"]["num_items_plan_to_watch"];
            labelTotalEntries.Text = userData["anime_statistics"]["num_items"];
            labelRewatched.Text = userData["anime_statistics"]["num_times_rewatched"];
            labelEpisodes.Text = userData["anime_statistics"]["num_episodes"];

            pictureBoxUser.ImageLocation = userData["picture"];
        }
        public void ShowProfileView()
        {
            this.Show();
        }
        public void ShowProfilePanel()
        {
            panelUserProfile.BringToFront();
        }
        public void ShowLoginPanel()
        {
            panelLeftLogin.BringToFront();
        }

        private void buttonConenctMAL_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ConnectToMALClickEventRaised, e);
        }

        private void ProfileView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ProfileLoadedEventRaised, e);
        }
    }
}
