using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ITCOURSES.Courses
{
    public class Course : AuditedAggregateRoot<Guid>
    {
        public string CourseName { get; set; }  // Khai báo các biến
        public string ClassName { get; set; }
        public string Schedule { get; set; }
        public Decimal Fee { get; set; }
        public string Description { get; set; }
        //public Guid IDTimeStudyTypes { get; set; }
        public Guid IDCourseOpeningSchedule { get; set; }
        private Course()
        {

        }
        public Course(Guid id, string courseName, string className, string schedule, decimal fee, string description, Guid iDCourseOpeningSchedule) 
        {
            Id = id;
            CourseName = courseName;
            ClassName = className;
            Schedule = schedule;
            Fee = fee;
            Description = description;
            IDCourseOpeningSchedule = iDCourseOpeningSchedule;
        }
        internal Course ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            CourseName = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: 50
            );
        }
    }
}
