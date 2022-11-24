using ITCOURSES.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ITCOURSES.Permissions;

public class ITCOURSESPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var ITCOURSESGroup = context.AddGroup(ITCOURSESPermissions.GroupName, L("Permission:ITCOURSES"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ITCOURSESPermissions.MyPermission1, L("Permission:MyPermission1"));
        var coursesPermission = ITCOURSESGroup.AddPermission(ITCOURSESPermissions.Courses.Default, L("Permission:Courses"));
        coursesPermission.AddChild(ITCOURSESPermissions.Courses.Create, L("Permission:Courses.Create"));
        coursesPermission.AddChild(ITCOURSESPermissions.Courses.Edit, L("Permission:Courses.Edit"));
        coursesPermission.AddChild(ITCOURSESPermissions.Courses.Delete, L("Permission:Courses.Delete"));


        var courseOpeninSchedulesPermission = ITCOURSESGroup.AddPermission(ITCOURSESPermissions.CourseOpeningSchedules.Default, L("Permission:CourseOpeningSchedules"));
        courseOpeninSchedulesPermission.AddChild(ITCOURSESPermissions.CourseOpeningSchedules.Create, L("Permission:CourseOpeningSchedules.Create"));
        courseOpeninSchedulesPermission.AddChild(ITCOURSESPermissions.CourseOpeningSchedules.Edit, L("Permission:CourseOpeningSchedules.Edit"));
        courseOpeninSchedulesPermission.AddChild(ITCOURSESPermissions.CourseOpeningSchedules.Delete, L("Permission:CourseOpeningSchedules.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ITCOURSESResource>(name);
    }
}
