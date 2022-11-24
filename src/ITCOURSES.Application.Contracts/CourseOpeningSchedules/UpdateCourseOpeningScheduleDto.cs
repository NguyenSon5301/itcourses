using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class UpdateCourseOpeningScheduleDto
    {
        [Required]
        [StringLength(128)]
        public string NameCourseOpeningSchedule { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOpening { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public string TimeStart { get; set; }
    }
}
