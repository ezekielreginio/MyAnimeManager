using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonComponents
{
    public class StringExtensions
    {
        public static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static string RemoveSpecialCharacters(String str)
        {
            str = str.Replace("/", " ");
            return Regex.Replace(str, "[^a-zA-Z0-9_()!+ -]+", "", RegexOptions.Compiled);
        }

        public static string GenerateGenreString(dynamic genre)
        {
            String genreString = "";
            int genreSize = ((JArray)genre).Count;
            if (genreSize > 3)
                genreSize = 3;
            for (int i = 0; i < genreSize; i++)
            {
                genreString += genre[i]["name"];
                if (i < genreSize - 1)
                    genreString += ", ";
            }
            return genreString;
        }

        public static int GetDuration(string timestamp)
        {
            try
            {
                String[] time = timestamp.Split(':');
                int min = Int32.Parse(time[0]);
                return (min * 60) + Int32.Parse(time[1]);
            }
            catch (FormatException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
