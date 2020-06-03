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
    public class ChapterController : ApiController
    {
        private readonly ChapterService _chapterService;

        public ChapterController()
        {
            _chapterService = new ChapterService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<Chapter>> CreateChapter(ChapterDto chapter)
        {
            try
            {
                return await _chapterService.CreateChapter(chapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Chapter>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Chapter>>> GetAllChapters()
        {
            try
            {
                return await _chapterService.GetAllChapters();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Chapter>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Chapter>>> GetSubjectChapters(Guid id)
        {
            try
            {
                return await _chapterService.GetChaptersBySubjectId(id);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Chapter>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<Chapter>> GetChapter(string id)
        {
            try
            {
                return await _chapterService.GetChapterById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<Chapter>() { Success = false, Errors = new List<string>() { ex.Message } };
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
