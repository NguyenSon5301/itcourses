using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace ITCOURSES.Courses
{
    public class CourseAlreadyExistsException : BusinessException
    {
        public CourseAlreadyExistsException(string name)
            : base(ITCOURSESDomainErrorCodes.CourseAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
