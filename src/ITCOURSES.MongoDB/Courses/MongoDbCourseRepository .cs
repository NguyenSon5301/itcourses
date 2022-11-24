using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using ITCOURSES.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace ITCOURSES.Courses
{
    public class MongoDbCourseRepository
        : MongoDbRepository<ITCOURSESMongoDbContext, Course, Guid>,
        ICourseRepository
    {   
        public MongoDbCourseRepository(
            IMongoDbContextProvider<ITCOURSESMongoDbContext> dbContextProvider
            ) : base(dbContextProvider)
        {
        }

        public async Task<Course> FindByNameAsync(string name)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable.FirstOrDefaultAsync(course => course.CourseName == name);
        }

        public async Task<List<Course>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var queryable = await GetMongoQueryableAsync();
            return await queryable
                .WhereIf<Course, IMongoQueryable<Course>>(
                    !filter.IsNullOrWhiteSpace(),
                    course => course.CourseName.Contains(filter)
                )
                .OrderBy(sorting)
                .As<IMongoQueryable<Course>>()
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
