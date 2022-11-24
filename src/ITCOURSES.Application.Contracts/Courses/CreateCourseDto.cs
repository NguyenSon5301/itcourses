using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCOURSES.Courses
{
    public class CreateCourseDto
    {
        [Required]
        [StringLength(128)]
        public string CourseName { get; set; }
        [Required]
        [StringLength(128)]
        public string ClassName { get; set; }
        [Required]
        [StringLength(128)]
        public string Schedule { get; set; }
        [Required]
        public Decimal Fee { get; set; }
        public string Description { get; set; }
        //public Guid IDTimeStudyTypes { get; set; }
        public Guid IDCourseOpeningSchedule { get; set; }
    }
}
