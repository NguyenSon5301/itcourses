using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ITCOURSES.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace ITCOURSES.Web.Pages.Courses
{
    public class CreateModalModel : ITCOURSESPageModel
    {
        [BindProperty]
        public CreateCourseViewModel Course { get; set; }
        public List<SelectListItem> CourseOpeningSchedules { get; set; }

        private readonly ICourseAppService _courseAppService;

        public CreateModalModel(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        public async Task OnGetAsync()
        {
            Course = new CreateCourseViewModel();
            var courseOpeningScheduleLookupDTO = await _courseAppService.GetCourseOpeningScheduleLookupAsync();
            CourseOpeningSchedules = courseOpeningScheduleLookupDTO.Items.Select(x => new SelectListItem(x.NameCourseOpeningSchedule, x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseAppService.CreateAsync(ObjectMapper.Map<CreateCourseViewModel, CreateCourseDto>(Course));
            return NoContent();
        }
        public class CreateCourseViewModel
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
            [SelectItems(nameof(CourseOpeningSchedules))]
            [DisplayName("CourseOpeningSchedule")]
            public Guid IDCourseOpeningSchedule { get; set; }
        }
    }
}
