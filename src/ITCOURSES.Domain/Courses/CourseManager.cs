using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace ITCOURSES.Courses
{
    public class CourseManager : DomainService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> CreateAsync(
            [NotNull] string name,
            [NotNull] string className,
             [NotNull] string Schedule,
             [NotNull] decimal fee,
             [CanBeNull] Guid iDCourseOpeningSchedule,
            [CanBeNull] string description = null
         )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAuthor = await _courseRepository.FindByNameAsync(name);
            if (existingAuthor != null)
            {
                throw new CourseAlreadyExistsException(name);
            }

            return new Course(
                GuidGenerator.Create(),
                name,
                className,
                Schedule,
                fee,
                description,
                iDCourseOpeningSchedule
            );
        }
        public async Task ChangeNameAsync(
        [NotNull] Course course,
        [NotNull] string newName)
        {
            Check.NotNull(course, nameof(course));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAuthor = await _courseRepository.FindByNameAsync(newName);
            if (existingAuthor != null && existingAuthor.Id != course.Id)
            {
                throw new CourseAlreadyExistsException(newName);
            }

            course.ChangeName(newName);
        }
    }
}
