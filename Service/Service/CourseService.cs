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

    public class CourseService : ICourseService
    {

        private readonly CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public async Task<ApiResponse<Course>> GetCourseById(Guid id)
        {
            var response = new ApiResponse<Course>();
            //Course course2 = _courseRepository.GetByGuid(id);
            Course course = await _courseRepository.GetByGuidAsync(id);
            if (course == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = course;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Course>>> GetAllCourses()
        {
            var response = new ApiResponse<IEnumerable<Course>>();
            IEnumerable<Course> course = await _courseRepository.GetAllAsyn();
            if (course == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = course;
            return response;
        }

        public async Task<ApiResponse<Course>> CreateCourse(CourseDto courseDto)
        {
            var response = new ApiResponse<Course>();
            try
            {
                //check course Exists
                var isExistCourse = await _courseRepository.CountAsync(i => i.Name == courseDto.Name);

                if (isExistCourse != 0)
                {
                    response.Success = false;
                    response.Errors.Add("Course Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new course
                var course = Mapper.Map<Course>(courseDto);
                course.Id = id;
                
                //course.CreatedBy = course.Id;
                course.CreatedDate = DateTime.Now;
                //course.Roles = courseRoles;
                course.IsActive = true;
                await _courseRepository.AddAsyn(course);
                response.Success = true;               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        //public async Task<ApiResponse<Course>> FindCourse(Course course)
        //{
        //    var response = new ApiResponse<Course>();
        //    var passwordManger = new PasswordManger();
        //    try
        //    {
        //        string password = passwordManger.Encrypt(course.Password);
        //        var courseRes = await _courseRepository.FindAsync(i => i.CourseName == course.CourseName && i.Password == password);
        //        if (courseRes == null)
        //        {
        //            response.Sucssess = true;
        //            response.Errors.Add("invalid Course");
        //            return response;
        //        }

        //        response.Sucssess = true;
        //        response.Data = courseRes;
        //        return response;
        //    }
        //    catch(Exception ex)
        //    {

        //        response.Sucssess = false;
        //        response.Errors.Add(ex.Message);
        //        return response;
        //    }
        //}
    }
}