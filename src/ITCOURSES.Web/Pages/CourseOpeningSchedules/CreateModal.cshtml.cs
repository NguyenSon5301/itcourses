using System.Threading.Tasks;
using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Web.Pages;
using Microsoft.AspNetCore.Mvc;

namespace ITCOURSES.Web.Pages.CourseOpeningSchedules
{
    public class CreateModalModel : ITCOURSESPageModel
    {
        [BindProperty]
        public CreateCourseOpeningSchedulesDtocs CourseOpeningSchedule { get; set; }

        private readonly ICourseOpeningScheduleAppService _courseOpeningScheduleAppService;

        public CreateModalModel(ICourseOpeningScheduleAppService courseOpeningScheduleAppService)
        {
            _courseOpeningScheduleAppService = courseOpeningScheduleAppService;
        }

        public void OnGet()
        {
            CourseOpeningSchedule = new CreateCourseOpeningSchedulesDtocs();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseOpeningScheduleAppService.CreateAsync(CourseOpeningSchedule);
            return NoContent();
        }
    }
}
