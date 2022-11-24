using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class CourseOpeningSchedule: AuditedAggregateRoot<Guid>
    {
        public string NameCourseOpeningSchedule { get; set; }
        public DateTime DateOpening { get; set; }
        public string TimeStart { get; set; }
        private CourseOpeningSchedule()
        {

        }
        public CourseOpeningSchedule(Guid id, string nameCourseOpeningSchedule, DateTime dateOpening, string timeStart)
        {
            Id = id;
            NameCourseOpeningSchedule = nameCourseOpeningSchedule;
            DateOpening = dateOpening;
            TimeStart = timeStart;
        }

        internal CourseOpeningSchedule ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            NameCourseOpeningSchedule = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: 50
            );
        }
    }
}
