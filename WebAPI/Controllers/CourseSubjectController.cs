using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class CourseSubjectController : ApiController
    {
        private readonly CourseSubjectService _courseSubjectServices;

        public CourseSubjectController() 
        {
            _courseSubjectServices = new CourseSubjectService(); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<CourseSubject>> CreateCourseSubject(CourseSubjectDto courseSubject)
        {
            try
            {
                return await _courseSubjectServices.CreateCourseSubject(courseSubject);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CourseSubject>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<CourseSubject>>> GetAllCourseSubjects()
        {
            try
            {
                return await _courseSubjectServices.GetAllCourseSubjects();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<CourseSubject>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<CourseSubject>> GetCourseSubject(string id)
        {
            try
            {
                return await _courseSubjectServices.GetByCourseSubjectId(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<CourseSubject>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

