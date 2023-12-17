using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakAndRead.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime DateTime { get; set; }
        public string Link { get; set; }
        
    }
}
