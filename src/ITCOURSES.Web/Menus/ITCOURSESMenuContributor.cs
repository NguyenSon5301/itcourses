using System.Threading.Tasks;
using ITCOURSES.Localization;
using ITCOURSES.MultiTenancy;
using ITCOURSES.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace ITCOURSES.Web.Menus;

public class ITCOURSESMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<ITCOURSESResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                ITCOURSESMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        ); ;

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        var iTCoursesMenu = new ApplicationMenuItem(
            "ITCourses",
            "ITCourses",
            icon: "fa fa-leanpub"
        );
        context.Menu.AddItem(iTCoursesMenu);
        if (await context.IsGrantedAsync(ITCOURSESPermissions.Courses.Default))
        {
            iTCoursesMenu.AddItem(
                new ApplicationMenuItem(
                    "ITCourses.Courses",
                    l["Courses"],
                    url: "/Courses"
                )
            );
        }
        if (await context.IsGrantedAsync(ITCOURSESPermissions.CourseOpeningSchedules.Default))
        {
            iTCoursesMenu.AddItem(
                new ApplicationMenuItem(
                    "ITCourses.CourseOpeningSchedules",
                    l["CourseOpeningSchedules"],
                    url: "/CourseOpeningSchedules"
                )
            );
        }
    }
}
