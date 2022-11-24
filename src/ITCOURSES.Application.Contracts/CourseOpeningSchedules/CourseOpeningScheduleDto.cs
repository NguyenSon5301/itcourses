using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class CourseOpeningScheduleDto : AuditedEntityDto<Guid>
    {
        public string NameCourseOpeningSchedule { get; set; }
        public DateTime DateOpening { get; set; }
        public string TimeStart { get; set; }
    }
}
