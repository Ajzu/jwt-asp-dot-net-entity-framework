using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class SubjectChapterController : ApiController
    {
        private readonly SubjectChapterService _subjectChapterServices;

        public SubjectChapterController() 
        {
            _subjectChapterServices = new SubjectChapterService(); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<SubjectChapter>> CreateSubjectChapter(SubjectChapterDto subjectChapter)
        {
            try
            {
                return await _subjectChapterServices.CreateSubjectChapter(subjectChapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<SubjectChapter>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<SubjectChapter>>> GetAllSubjectChapters()
        {
            try
            {
                return await _subjectChapterServices.GetAllSubjectChapters();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<SubjectChapter>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<SubjectChapter>> GetSubjectChapter(string id)
        {
            try
            {
                return await _subjectChapterServices.GetBySubjectChapterId(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<SubjectChapter>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

