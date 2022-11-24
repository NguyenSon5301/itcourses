using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITCOURSES.Courses;
using ITCOURSES.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;

namespace ITCOURSES.Web.Pages.Courses
{
    public class EditModalModel : ITCOURSESPageModel
    {
        [BindProperty]
        public EditCourseViewModel Course { get; set; }
        public List<SelectListItem> CourseOpeningSchedules { get; set; }

        private readonly ICourseAppService _courseAppService;

        public EditModalModel(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var courseDto = await _courseAppService.GetAsync(id);
            Course = ObjectMapper.Map<CourseDto, EditCourseViewModel>(courseDto);

            var courseOpeningSchedulesLookup = await _courseAppService.GetCourseOpeningScheduleLookupAsync();
            CourseOpeningSchedules = courseOpeningSchedulesLookup.Items
                .Select(x => new SelectListItem(x.NameCourseOpeningSchedule, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseAppService.UpdateAsync(Course.Id, ObjectMapper.Map<EditCourseViewModel, UpdateCourseDto>(Course));
            return NoContent();
        }
        public class EditCourseViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
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
            [SelectItems(nameof(CourseOpeningSchedules))]
            [DisplayName("CourseOpeningSchedule")]
            public Guid IDCourseOpeningSchedule { get; set; }
        }
    }
}
