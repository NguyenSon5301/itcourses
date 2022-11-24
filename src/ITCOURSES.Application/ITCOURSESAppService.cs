using System;
using System.Collections.Generic;
using System.Text;
using ITCOURSES.Localization;
using Volo.Abp.Application.Services;

namespace ITCOURSES;

/* Inherit your application services from this class.
 */
public abstract class ITCOURSESAppService : ApplicationService
{
    protected ITCOURSESAppService()
    {
        LocalizationResource = typeof(ITCOURSESResource);
    }
}
