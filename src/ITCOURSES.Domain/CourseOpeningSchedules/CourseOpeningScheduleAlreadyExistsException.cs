using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ITCOURSES.CourseOpeningSchedules
{
    public class CourseOpeningScheduleAlreadyExistsException : BusinessException
    {
        public CourseOpeningScheduleAlreadyExistsException(string name)
           : base(ITCOURSESDomainErrorCodes.CourseOpeningScheduleAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
