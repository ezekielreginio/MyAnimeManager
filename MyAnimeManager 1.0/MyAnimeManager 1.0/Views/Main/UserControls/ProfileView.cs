using CommonComponents;
using CommonComponents.Constants;
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
        public event EventHandler AddToListClickEventRaised;
        public event EventHandler UpdateAnimeClickEventRaised;
        public event EventHandler DeleteAnimeClickEventRaised;
        public event EventHandler ProfileLoadedEventRaised;

        public int SelectedAnimeID;

        public string CurrentStatus;

        public ProfileView()
        {
            InitializeComponent();
        }

        //Public Methods
        public UserControl GetProfileView()
        {
            return this;
        }
        public int GetSelectedAnimeID()
        {
            return SelectedAnimeID;
        }
        public int GetScore()
        {
            return bunifuDropdownYourScore.selectedIndex;
        }
        public string GetTitle() {
            return labelAnimeInfoTitle.Text;
        }
        public int GetCurrentEpisode()
        {
            try
            {
                if (!String.IsNullOrEmpty(textBoxEpsSeen.Text))
                    return Int32.Parse(textBoxEpsSeen.Text);
                else
                    return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Episode Number. It should only contain numerical characters.");
                textBoxEpsSeen.Text = "";
                return -1;
            }
        }
        public string GetCurrentStatus()
        {
            return CurrentStatus;
        }

        public void SetAnimeDetails(dynamic animeDetails)
        {
            labelAnimeInfoTitle.Text = animeDetails["title"];
            pictureBoxAnimeInfoPoster.ImageLocation = animeDetails["main_picture"]["medium"];
            
            if (animeDetails["mean"] == null)
                labelAnimeRating.Text = "N/A";
            else
                labelAnimeRating.Text = String.Format("{0:0.00}", animeDetails["mean"]);
            labelRanked.Text = "#" + animeDetails["rank"];
            labelPopularity.Text = "#" + animeDetails["popularity"];
            labelUserWatchers.Text = String.Format("{0:n0}", animeDetails["num_list_users"]) + " users";
            pictureBoxAnimeInfoPoster.ImageLocation = animeDetails["main_picture"]["medium"];

            if (animeDetails["my_list_status"] != null)
            {
                CurrentStatus = (String)animeDetails["my_list_status"]["status"];
                //panelContainerAnimeStatus.BringToFront();
                textBoxEpsSeen.Text = animeDetails["my_list_status"]["num_episodes_watched"];
                labelNoOfeps.Text = animeDetails["num_episodes"];
                if ((int)animeDetails["my_list_status"]["score"] != 0)
                {
                    bunifuDropdownYourScore.selectedIndex = 11 - (int)animeDetails["my_list_status"]["score"];
                }
                else
                    bunifuDropdownYourScore.selectedIndex = 0;
                bunifuDropdownStatus.selectedIndex = AnimeStatusConstants.getStatusArray()[(String)animeDetails["my_list_status"]["status"]];
                tableLayoutPanelAnimeStatus.BringToFront();
            }
            else
            {
                CurrentStatus = null;
                panelAnimeNotListed.BringToFront();
            }

            labelAnimeInfoStatus.Text = AnimeStatusConstants.getCurrentArray()[(String)animeDetails["status"]];
            labelAnimeInfoSeason.Text = StringExtensions.FirstLetterToUpper((String)animeDetails["start_season"]["season"]) + " " + animeDetails["start_season"]["year"];
            labelAnimeInfoStudio.Text = animeDetails["studios"][0]["name"];
            labelAnimeInfoSource.Text = animeDetails["source"];
            labelAnimeInfoGenre.Text = StringExtensions.GenerateGenreString(animeDetails["genres"]);


        }

        public void SetSelectedAnimeID(int selectedAnimeID)
        {
            this.SelectedAnimeID = selectedAnimeID;
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
        public void ShowAnimeDetailsPanel()
        {
            panelAnimeDetails.BringToFront();
        }
        public void ShowLoginPanel()
        {
            panelLeftLogin.BringToFront();
        }
        public void ShowLoadingPanel()
        {
            panelProfileLoading.BringToFront();
        }

        private void buttonConenctMAL_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ConnectToMALClickEventRaised, e);
        }

        private void ProfileView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ProfileLoadedEventRaised, e);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, UpdateAnimeClickEventRaised, e);
        }

        private void textBoxEpsSeen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void pictureBoxDeleteIcon_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, DeleteAnimeClickEventRaised, e);
        }

        private void bunifuButtonAddToList_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, AddToListClickEventRaised, e);
        }
    }
}
