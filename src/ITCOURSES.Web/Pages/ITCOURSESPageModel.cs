using ITCOURSES.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ITCOURSES.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ITCOURSESPageModel : AbpPageModel
{
    protected ITCOURSESPageModel()
    {
        LocalizationResourceType = typeof(ITCOURSESResource);
    }
}
