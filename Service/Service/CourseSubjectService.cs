using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Utilities;


namespace Service.Service
{

    public class CourseSubjectService : ICourseSubjectService
    {

        private readonly CourseSubjectRepository _courseSubjectRepository;

        public CourseSubjectService()
        {
            _courseSubjectRepository = new CourseSubjectRepository();
        }

        public async Task<ApiResponse<IEnumerable<CourseSubject>>> GetSubjectsByCourseId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<CourseSubject>>();
            IEnumerable<CourseSubject> courseSubjects = await _courseSubjectRepository.FindAllAsync(x => x.CourseId == id);
            if (courseSubjects == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = courseSubjects;
            return response;
        }

        public async Task<ApiResponse<CourseSubject>> GetByCourseSubjectId(Guid id)
        {
            var response = new ApiResponse<CourseSubject>();
            CourseSubject courseSubject = await _courseSubjectRepository.GetByGuidAsync(id);
            if (courseSubject == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = courseSubject;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<CourseSubject>>> GetAllCourseSubjects()
        {
            var response = new ApiResponse<IEnumerable<CourseSubject>>();
            IEnumerable<CourseSubject> courseSubject = await _courseSubjectRepository.GetAllAsyn();
            if (courseSubject == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = courseSubject;
            return response;
        }

        public async Task<ApiResponse<CourseSubject>> CreateCourseSubject(CourseSubjectDto courseSubjectDto)
        {
            var response = new ApiResponse<CourseSubject>();
            try
            {
                //check course Exists
                var isExistCourseSubject = await _courseSubjectRepository.CountAsync(i => i.CourseId == courseSubjectDto.CourseId && i.SubjectId == courseSubjectDto.SubjectId);

                if (isExistCourseSubject != 0)
                {
                    response.Success = false;
                    response.Errors.Add("CourseSubject Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new course
                var courseSubject = Mapper.Map<CourseSubject>(courseSubjectDto);
                courseSubject.Id = id;

                //course.CreatedBy = course.Id;
                courseSubject.CreatedDate = DateTime.Now;
                //course.Roles = courseRoles;
                courseSubject.IsActive = true;
                await _courseSubjectRepository.AddAsyn(courseSubject);
                response.Success = true;               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }
    }
}