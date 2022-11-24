using AutoMapper;
using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Courses;

namespace ITCOURSES;

public class ITCOURSESApplicationAutoMapperProfile : Profile
{
    public ITCOURSESApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Course, CourseDto>();
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();


        CreateMap<CourseOpeningSchedule, CourseOpeningScheduleDto>();
        CreateMap<CourseOpeningSchedule, CourseOpeningScheduleLookupDto>();
        CreateMap<CreateCourseOpeningSchedulesDtocs, CourseOpeningSchedule>();
        CreateMap<UpdateCourseOpeningScheduleDto, CourseOpeningSchedule>();
    }
}
