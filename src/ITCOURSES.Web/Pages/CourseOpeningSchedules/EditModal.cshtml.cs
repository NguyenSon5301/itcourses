using System;
using System.Threading.Tasks;
using ITCOURSES.CourseOpeningSchedules;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;

namespace ITCOURSES.Web.Pages.CourseOpeningSchedules
{
    public class EditModalModel : ITCOURSESPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public UpdateCourseOpeningScheduleDto CourseOpeningSchedule { get; set; }

        private readonly ICourseOpeningScheduleAppService _courseOpeningScheduleAppService;

        public EditModalModel(ICourseOpeningScheduleAppService courseOpeningScheduleAppService)
        {
            _courseOpeningScheduleAppService = courseOpeningScheduleAppService;
        }

        public async Task OnGetAsync()
        {
            var courseOpeningScheduleDto = await _courseOpeningScheduleAppService.GetAsync(Id);
            CourseOpeningSchedule = ObjectMapper.Map<CourseOpeningScheduleDto, UpdateCourseOpeningScheduleDto>(courseOpeningScheduleDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseOpeningScheduleAppService.UpdateAsync(Id, CourseOpeningSchedule);
            return NoContent();
        }
    }
}
