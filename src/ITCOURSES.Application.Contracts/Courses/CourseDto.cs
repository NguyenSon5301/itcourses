using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ITCOURSES.Courses
{
    public class CourseDto : AuditedEntityDto<Guid>
    {
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public string Schedule { get; set; }
        public Decimal Fee { get; set; }
        public string Description { get; set; }
        //public Guid IDTimeStudyTypes { get; set; }
        public Guid IDCourseOpeningSchedule { get; set; }
        public string NameCourseOpeningSchedule { get; set; }

    }
}
