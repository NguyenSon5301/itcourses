using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ITCOURSES.CourseOpeningSchedules
{
    public interface ICourseOpeningScheduleAppService : IApplicationService
    {
        Task<CourseOpeningScheduleDto> GetAsync(Guid id);

        Task<PagedResultDto<CourseOpeningScheduleDto>> GetListAsync(GetCourseOpeningScheduleListDto input);

        Task<CourseOpeningScheduleDto> CreateAsync(CreateCourseOpeningSchedulesDtocs input);

        Task UpdateAsync(Guid id, UpdateCourseOpeningScheduleDto input);

        Task DeleteAsync(Guid id);
    }
}
