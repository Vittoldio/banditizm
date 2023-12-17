using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public enum Level
    {
        A1,A2,B1,B2,C1,C2
    }
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        [MaxLength(60)]
        public string CourseName { get; set; }
        [Required]
        public Level Level { get; set; }
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<CourseUser> CourseUsers { get; set; }
    }
}
