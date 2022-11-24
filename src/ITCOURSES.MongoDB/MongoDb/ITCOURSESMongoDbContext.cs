using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Courses;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace ITCOURSES.MongoDB;

[ConnectionStringName("Default")]
public class ITCOURSESMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<Course> Courses => Collection<Course>();
    public IMongoCollection<CourseOpeningSchedule> CourseOpeningSchedules => Collection<CourseOpeningSchedule>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}
