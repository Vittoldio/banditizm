using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
