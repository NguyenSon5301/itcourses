using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ITCOURSES.Web;

[Dependency(ReplaceServices = true)]
public class ITCOURSESBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ITCOURSES";
}
