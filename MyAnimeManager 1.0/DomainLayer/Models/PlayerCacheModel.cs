using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class PlayerCacheModel
    {
        public int animeID { get; set; }
        public int episode { get; set; }
        public String duration { get; set; }

        public PlayerCacheModel()
        {

        }

        public PlayerCacheModel(int animeID, int episode, string duration)
        {
            this.animeID = animeID;
            this.episode = episode;
            this.duration = duration;
        }
    }
}
