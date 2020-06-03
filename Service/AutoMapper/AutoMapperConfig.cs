
using AutoMapper;
using DTOModel;
using EnityModel;

namespace Service.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<UserOldDto, UserOld>().ReverseMap();
                config.CreateMap<CourseDto, Course>().ReverseMap();
                config.CreateMap<SubjectDto, Subject>().ReverseMap();
                config.CreateMap<CourseSubjectDto, CourseSubject>().ReverseMap();
                config.CreateMap<ChapterDto, Chapter>().ReverseMap();
                config.CreateMap<SubjectChapterDto, SubjectChapter>().ReverseMap();
                config.CreateMap<VideoTypeDto, VideoType>().ReverseMap();
                config.CreateMap<VideoDto, Video>().ReverseMap();
                config.CreateMap<ChecklistTypeDto, ChecklistType>().ReverseMap();
                config.CreateMap<CheckPointDto, CheckPoint>().ReverseMap();
                config.CreateMap<ChecklistTypeCheckPointDto, ChecklistTypeCheckPoint>().ReverseMap();
                config.CreateMap<UserDto, User>().ReverseMap();
                config.CreateMap<UserDto, LoginDto>().ReverseMap();
                config.CreateMap<ForgotPasswordDto, ForgotPassword>().ReverseMap();
            });
        }
    }
}
