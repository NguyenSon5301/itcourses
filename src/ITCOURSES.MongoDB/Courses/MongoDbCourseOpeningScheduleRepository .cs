using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using System.Linq.Dynamic.Core;

namespace ITCOURSES.Courses
{
    public class MongoDbCourseOpeningScheduleRepository : MongoDbRepository<ITCOURSESMongoDbContext, CourseOpeningSchedule, Guid>,
        ICourseOpeningScheduleRepository
    {
        public MongoDbCourseOpeningScheduleRepository(
            IMongoDbContextProvider<ITCOURSESMongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<CourseOpeningSchedule> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(courseOpeningSchedule => courseOpeningSchedule.NameCourseOpeningSchedule == name);
        }

        public async Task<List<CourseOpeningSchedule>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<CourseOpeningSchedule, IMongoQueryable<CourseOpeningSchedule>>(
                    !filter.IsNullOrWhiteSpace(),
                    courseOpeningSchedule => courseOpeningSchedule.NameCourseOpeningSchedule.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<CourseOpeningSchedule>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
