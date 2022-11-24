using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace ITCOURSES.Courses
{
    [Authorize(ITCOURSESPermissions.Courses.Default)]
    public class CourseAppService: ITCOURSESAppService, ICourseAppService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly CourseManager _courseManager;
        private readonly ICourseOpeningScheduleRepository _courseOpeningScheduleRepository;

        public CourseAppService(ICourseRepository courseRepository, CourseManager courseManager, ICourseOpeningScheduleRepository courseOpeningScheduleRepository) 
        {
            _courseRepository = courseRepository;
            _courseManager = courseManager;
            _courseOpeningScheduleRepository = courseOpeningScheduleRepository;
        }
        public async Task<CourseDto> GetAsync(Guid id)
        {
            var course = await _courseRepository.GetAsync(id);
            var courseDto = ObjectMapper.Map<Course, CourseDto>(course);
            var courseOpeningSchedule = await _courseOpeningScheduleRepository.GetAsync(course.IDCourseOpeningSchedule);
            courseDto.NameCourseOpeningSchedule = courseOpeningSchedule.NameCourseOpeningSchedule;
            return courseDto;
        }
        public async Task<PagedResultDto<CourseDto>> GetListAsync(GetCourseListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Course.CourseName);
            }

            var courses = await _courseRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );
            var authorDictionary = await GetCourseOpeningScheduleDictionaryAsync(courses);
            var courseDtos = ObjectMapper.Map<List<Course>, List<CourseDto>>(courses);
            
            //Set AuthorName for the DTOs
            courseDtos.ForEach(courseDto => courseDto.NameCourseOpeningSchedule = authorDictionary[courseDto.IDCourseOpeningSchedule].NameCourseOpeningSchedule);
            var totalCount = input.Filter == null
                ? await _courseRepository.CountAsync()
                : await _courseRepository.CountAsync(
                    course => course.CourseName.Contains(input.Filter));

            return new PagedResultDto<CourseDto>(
                totalCount,
                courseDtos
            );
        }
        [Authorize(ITCOURSESPermissions.Courses.Create)]
        public async Task<CourseDto> CreateAsync(CreateCourseDto input)
        {
            var course = await _courseManager.CreateAsync(
                input.CourseName,
                input.ClassName,
                input.Schedule,
                input.Fee,
                input.IDCourseOpeningSchedule,
                input.Description
            );

            await _courseRepository.InsertAsync(course);

            return ObjectMapper.Map<Course, CourseDto>(course);
        }
        [Authorize(ITCOURSESPermissions.Courses.Edit)]
        public async Task UpdateAsync(Guid id, UpdateCourseDto input)
        {
            var course = await _courseRepository.GetAsync(id);

            if (course.CourseName != input.CourseName)
            {
                await _courseManager.ChangeNameAsync(course, input.CourseName);
            }

            course.ClassName = input.ClassName;
            course.Schedule = input.Schedule;
            course.Fee = input.Fee;
            course.Description = input.Description;
            course.IDCourseOpeningSchedule = input.IDCourseOpeningSchedule;

            await _courseRepository.UpdateAsync(course);
        }
        [Authorize(ITCOURSESPermissions.Courses.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }
        public async Task<ListResultDto<CourseOpeningScheduleLookupDto>> GetCourseOpeningScheduleLookupAsync()
        {
            var courseOpeningSchedule = await _courseOpeningScheduleRepository.GetListAsync();

            return new ListResultDto<CourseOpeningScheduleLookupDto>(
                ObjectMapper.Map<List<CourseOpeningSchedule>, List<CourseOpeningScheduleLookupDto>>(courseOpeningSchedule)
            );
        }
        private async Task<Dictionary<Guid, CourseOpeningSchedule>> GetCourseOpeningScheduleDictionaryAsync(List<Course> courses)
        {
            var courseOpeningSchedulerIds = courses
                .Select(b => b.IDCourseOpeningSchedule)
                .Distinct()
                .ToArray();

            var queryable = await _courseOpeningScheduleRepository.GetQueryableAsync();

            var courseOpeningSchedules = await AsyncExecuter.ToListAsync(
                queryable.Where(a => courseOpeningSchedulerIds.Contains(a.Id))
            );

            return courseOpeningSchedules.ToDictionary(x => x.Id, x => x);
        }



    }
}
