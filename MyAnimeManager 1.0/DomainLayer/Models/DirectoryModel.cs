using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public class DirectoryModel : IDirectoryModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Directory Path Cannot Be Empty")]
        public string DirectoryPath { get; set; }
    }
}
