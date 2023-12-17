using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Text { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        public string EnteredBy { get; set; }
        public DateTime Created { get; set; }
    }
}
