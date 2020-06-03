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
    public class VideoController : ApiController
    {
        private readonly VideoService _videoService;

        public VideoController()
        {
            _videoService = new VideoService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<Video>> CreateVideo(VideoDto video)
        {
            try
            {
                return await _videoService.CreateVideo(video);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Video>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Video>>> GetAllVideos()
        {
            try
            {
                return await _videoService.GetAllVideos();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Video>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<Video>>> GetVideosByVideoType(Guid id, string typeName)
        {
            try
            {
                return await _videoService.GetVideosByVideoType(id, typeName);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<Video>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<Video>> GetVideo(string id)
        {
            try
            {
                return await _videoService.GetVideoById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<Video>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}
