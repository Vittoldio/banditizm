using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        [Required]
        [MaxLength(40)]
        public string LanguageName { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
