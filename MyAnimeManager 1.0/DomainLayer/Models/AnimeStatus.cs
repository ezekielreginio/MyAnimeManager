using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AnimeStatus
    {
        public int score { get; set; }
        public string currentStatus { get; set; }
        public int currentEpisode { get; set; }
        public int animeID { get; set; }

        public AnimeStatus(int animeID, int score, string currentStatus, int currentEpisode)
        {
            this.animeID = animeID;
            this.score = score;
            this.currentStatus = currentStatus;
            this.currentEpisode = currentEpisode;
        }
    }
}
