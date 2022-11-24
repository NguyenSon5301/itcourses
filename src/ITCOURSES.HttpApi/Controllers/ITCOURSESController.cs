using ITCOURSES.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ITCOURSES.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ITCOURSESController : AbpControllerBase
{
    protected ITCOURSESController()
    {
        LocalizationResource = typeof(ITCOURSESResource);
    }
}
