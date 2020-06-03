using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SubjectController : ApiController
    {
        private readonly SubjectService _subjectService;

        public SubjectController()
        {
            _subjectService = new SubjectService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<Subject>> CreateSubject(SubjectDto subject)
        {
            try
            {
                return await _subjectService.CreateSubject(subject);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Subject>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Subject>>> GetAllSubjects()
        {
            try
            {
                return await _subjectService.GetAllSubjects();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Subject>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Subject>>> GetCourseSubjects(Guid id)
        {
            try
            {
                return await _subjectService.GetSubjectsByCourseId(id);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Subject>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<Subject>> GetSubject(string id)
        {
            try
            {
                return await _subjectService.GetSubjectById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<Subject>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }




        //Default implementation
        //// GET: api/Subject
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Subject/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Subject
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Subject/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Subject/5
        //public void Delete(int id)
        //{
        //}
    }
}
