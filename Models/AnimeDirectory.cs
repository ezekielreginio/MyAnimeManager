using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeManager.Models
{
    internal class AnimeDirectory
    {
        private string directory, name;
        public AnimeDirectory(string directory, string name)
        {
            this.Directory = directory;
            this.Name = name;
        }

        public string Directory { get => directory; set => directory = value; }
        public string Name { get => name; set => name = value; }
    }
}
