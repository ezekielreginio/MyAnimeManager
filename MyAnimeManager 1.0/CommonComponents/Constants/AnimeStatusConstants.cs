using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonComponents.Constants
{
    public class AnimeStatusConstants
    {
        private static Dictionary<String, int> AnimeStatusArray = new Dictionary<String, int>()
            {
                {"plan_to_watch", 0},
                {"watching", 1},
                {"completed", 2},
                {"on_hold", 3},
                {"dropped", 4}
            };
        private static Dictionary<String, String> CurrentStatusArray = new Dictionary<String, String>()
            {
                {"finished_airing", "Finished Airing"},
                {"currently_airing", "Currently Airing"},
                {"not_yet_aired", "Not Yet Aired"},
            };
        public static Dictionary<String, int> getStatusArray()
        {
            return AnimeStatusArray;
        }

        public static Dictionary<String, String> getCurrentArray()
        {
            return CurrentStatusArray;
        }

        public static String getKey(int index)
        {
            foreach (string key in AnimeStatusArray.Keys)
            {
                if (AnimeStatusArray[key] == index)
                {
                    return key;
                }
            }
            return null;
        }
    }
}
