using AutoMapper;
using ITCOURSES.CourseOpeningSchedules;
using ITCOURSES.Courses;
using static ITCOURSES.Web.Pages.Courses.CreateModalModel;
using static ITCOURSES.Web.Pages.Courses.EditModalModel;

namespace ITCOURSES.Web;

public class ITCOURSESWebAutoMapperProfile : Profile
{
    public ITCOURSESWebAutoMapperProfile()
    {
        ////Define your AutoMapper configuration here for the Web project.
        //CreateMap<CourseDto, CreateCourseDto>();
        //CreateMap<CourseOpeningScheduleDto, CreateCourseOpeningSchedulesDtocs>();
        //CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateCourseDto>();
        //CreateMap<CourseDto, Pages.Courses.EditModalModel.EditCourseViewModel>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, CreateCourseDto>();

        //CreateMap<CourseDto, UpdateCourseDto>();
        //CreateMap<CourseOpeningScheduleDto, UpdateCourseOpeningScheduleDto>();
        //CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, UpdateCourseDto>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, UpdateCourseDto>();

        //CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateCourseOpeningSchedulesDtocs>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, UpdateCourseOpeningScheduleDto>();
        //CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, UpdateCourseOpeningScheduleDto>();
        //CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, CreateCourseOpeningSchedulesDtocs>();


        CreateMap<CourseDto, CreateCourseDto>();
        CreateMap<CourseDto, UpdateCourseDto>();


        CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateCourseDto>();
        CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, UpdateCourseDto>();

        CreateMap<CourseDto, Pages.Courses.EditModalModel.EditCourseViewModel>();
        CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, CreateCourseDto>();
        CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, UpdateCourseDto>();

        CreateMap<CourseOpeningScheduleDto, UpdateCourseOpeningScheduleDto>();


        CreateMap<CreateCourseViewModel, CreateCourseDto>();
        CreateMap<CourseDto, EditCourseViewModel>();
        CreateMap<EditCourseViewModel, UpdateCourseDto>();
       
    }
}
