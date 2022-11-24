namespace ITCOURSES.Permissions;

public static class ITCOURSESPermissions
{
    public const string GroupName = "ITCOURSES";


    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Courses
    {
        public const string Default = GroupName + ".Courses";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class CourseOpeningSchedules
    {
        public const string Default = GroupName + ".CourseOpeningSchedules";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
