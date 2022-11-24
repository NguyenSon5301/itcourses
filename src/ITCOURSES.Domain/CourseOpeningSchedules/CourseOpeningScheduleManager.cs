using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class CourseOpeningScheduleManager : DomainService
    {
        private readonly ICourseOpeningScheduleRepository _courseOpeningScheduleRepository;

        public CourseOpeningScheduleManager(ICourseOpeningScheduleRepository courseOpeningScheduleRepository)
        {
            _courseOpeningScheduleRepository = courseOpeningScheduleRepository;
        }

        public async Task<CourseOpeningSchedule> CreateAsync(
            [NotNull] string name,
            DateTime dateOpening,
             [NotNull] string TimeStart
         )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _courseOpeningScheduleRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new CourseOpeningScheduleAlreadyExistsException(name);
            }

            return new CourseOpeningSchedule(
                GuidGenerator.Create(),
                name,
                dateOpening,
                TimeStart
            );
        }
        public async Task ChangeNameAsync(
        [NotNull] CourseOpeningSchedule courseOpeningSchedule,
        [NotNull] string newName)
        {
            Check.NotNull(courseOpeningSchedule, nameof(courseOpeningSchedule));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingCourseOpeningSchedule= await _courseOpeningScheduleRepository.FindByNameAsync(newName);
            if (existingCourseOpeningSchedule != null && existingCourseOpeningSchedule.Id != courseOpeningSchedule.Id)
            {
                throw new CourseOpeningScheduleAlreadyExistsException(newName);
            }

            courseOpeningSchedule.ChangeName(newName);
        }
    }
}
