using ITCOURSES.MongoDB;
using Volo.Abp.Modularity;

namespace ITCOURSES;

[DependsOn(
    typeof(ITCOURSESMongoDbTestModule)
    )]
public class ITCOURSESDomainTestModule : AbpModule
{

}
