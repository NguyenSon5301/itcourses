using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ITCOURSES.CourseOpeningSchedules
{
    public interface ICourseOpeningScheduleRepository : IRepository<CourseOpeningSchedule, Guid>
    {
        Task<CourseOpeningSchedule> FindByNameAsync(string name);

        Task<List<CourseOpeningSchedule>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
