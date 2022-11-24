using ITCOURSES.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ITCOURSES.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ITCOURSESMongoDbModule),
    typeof(ITCOURSESApplicationContractsModule)
    )]
public class ITCOURSESDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
