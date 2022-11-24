using Volo.Abp.Modularity;

namespace ITCOURSES;

[DependsOn(
    typeof(ITCOURSESApplicationModule),
    typeof(ITCOURSESDomainTestModule)
    )]
public class ITCOURSESApplicationTestModule : AbpModule
{

}
