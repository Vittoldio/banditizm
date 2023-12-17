using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public class CourseUser
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
