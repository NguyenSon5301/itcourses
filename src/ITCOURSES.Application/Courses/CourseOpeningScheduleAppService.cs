using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ITCOURSES.Courses
{
    [Authorize(ITCOURSESPermissions.CourseOpeningSchedules.Default)]
    public class CourseOpeningScheduleAppService : ITCOURSESAppService, ICourseOpeningScheduleAppService
    {
        private readonly ICourseOpeningScheduleRepository _courseOpeningScheduleRepository;
        private readonly CourseOpeningScheduleManager _courseOpeningScheduleManager;
        public CourseOpeningScheduleAppService(ICourseOpeningScheduleRepository courseOpeningScheduleRepository
            , CourseOpeningScheduleManager courseOpeningScheduleManager)
        {
            _courseOpeningScheduleRepository = courseOpeningScheduleRepository;
            _courseOpeningScheduleManager = courseOpeningScheduleManager;
        }
        public async Task<CourseOpeningScheduleDto> GetAsync(Guid id)
        {
            var courseOpeningSchedule = await _courseOpeningScheduleRepository.GetAsync(id);
            return ObjectMapper.Map<CourseOpeningSchedule, CourseOpeningScheduleDto>(courseOpeningSchedule);
        }
        public async Task<PagedResultDto<CourseOpeningScheduleDto>> GetListAsync(GetCourseOpeningScheduleListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(CourseOpeningSchedule.NameCourseOpeningSchedule);
            }
            var courseOpeningSchedules = await _courseOpeningScheduleRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );
            var totalCount = input.Filter == null
                ? await _courseOpeningScheduleRepository.CountAsync()
                : await _courseOpeningScheduleRepository.CountAsync(
                    courseOpeningSchedule => courseOpeningSchedule.NameCourseOpeningSchedule.Contains(input.Filter));

            return new PagedResultDto<CourseOpeningScheduleDto>(
                totalCount,
                ObjectMapper.Map<List<CourseOpeningSchedule>, List<CourseOpeningScheduleDto>>(courseOpeningSchedules)
            );
        }
        [Authorize(ITCOURSESPermissions.CourseOpeningSchedules.Create)]
        public async Task<CourseOpeningScheduleDto> CreateAsync(CreateCourseOpeningSchedulesDtocs input)
        {
            var courseOpeningSchedule = await _courseOpeningScheduleManager.CreateAsync(
                input.NameCourseOpeningSchedule,
                input.DateOpening,
                input.TimeStart
            );

            await _courseOpeningScheduleRepository.InsertAsync(courseOpeningSchedule);

            return ObjectMapper.Map<CourseOpeningSchedule, CourseOpeningScheduleDto>(courseOpeningSchedule);
        }
        [Authorize(ITCOURSESPermissions.CourseOpeningSchedules.Edit)]
        public async Task UpdateAsync(Guid id, UpdateCourseOpeningScheduleDto input)
        {
            var courseOpeningSchedule = await _courseOpeningScheduleRepository.GetAsync(id);

            if (courseOpeningSchedule.NameCourseOpeningSchedule != input.NameCourseOpeningSchedule)
            {
                await _courseOpeningScheduleManager.ChangeNameAsync(courseOpeningSchedule, input.NameCourseOpeningSchedule);
            }

            courseOpeningSchedule.DateOpening = input.DateOpening;
            courseOpeningSchedule.TimeStart = input.TimeStart;

            await _courseOpeningScheduleRepository.UpdateAsync(courseOpeningSchedule);
        }
        [Authorize(ITCOURSESPermissions.CourseOpeningSchedules.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _courseOpeningScheduleRepository.DeleteAsync(id);
        }
    }
}
