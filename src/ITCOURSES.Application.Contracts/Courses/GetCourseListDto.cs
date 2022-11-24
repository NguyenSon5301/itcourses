using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace ITCOURSES.Courses
{
    public class GetCourseListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
