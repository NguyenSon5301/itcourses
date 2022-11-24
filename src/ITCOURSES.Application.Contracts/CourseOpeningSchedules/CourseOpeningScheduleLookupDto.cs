using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class CourseOpeningScheduleLookupDto : EntityDto<Guid>
    {
        public string NameCourseOpeningSchedule { get; set; }

    }
}
