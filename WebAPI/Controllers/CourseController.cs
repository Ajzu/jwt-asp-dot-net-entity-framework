using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class CourseController : ApiController
    {
        private readonly CourseService _courseServices;

        public CourseController() 
        {
            _courseServices = new CourseService(); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<Course>> CreateCourse(CourseDto course)
        {
            try
            {
                return await _courseServices.CreateCourse(course);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Course>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Course>>> GetAllCourses()
        {
            try
            {
                return await _courseServices.GetAllCourses();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Course>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<Course>> GetCourse(string id)
        {
            try
            {
                return await _courseServices.GetCourseById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<Course>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

