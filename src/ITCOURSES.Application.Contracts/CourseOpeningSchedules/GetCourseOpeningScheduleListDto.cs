using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class GetCourseOpeningScheduleListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}
