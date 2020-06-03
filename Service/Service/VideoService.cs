using AutoMapper;
using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class VideoService : IVideoService
    {
        private readonly VideoRepository _videoRepository;
        private readonly VideoTypeService _videoTypeService;

        public VideoService()
        {
            _videoRepository = new VideoRepository();
            _videoTypeService = new VideoTypeService();
        }

        public async Task<ApiResponse<Video>> GetVideoById(Guid id)
        {
            var response = new ApiResponse<Video>();
            Video video = await _videoRepository.GetByGuidAsync(id);
            if (video == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = video;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<Video>>> GetVideosByVideoType(Guid videoTypeAssociatedId, string typeName)
        {
            ApiResponse<VideoType> videoTypeResponse = new ApiResponse<VideoType>();
            videoTypeResponse = await _videoTypeService.GetVideoTypeByName(typeName);

            var response = new ApiResponse<IEnumerable<Video>>();
            IEnumerable<Video> video = await _videoRepository.FindAllAsync(x => x.VideoTypeId == videoTypeResponse.Data.Id && x.VideoTypeAssociatedId == videoTypeAssociatedId);
            if (video == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = video;
            return response;
        }


        public async Task<ApiResponse<IEnumerable<Video>>> GetAllVideos()
        {
            //AddVideoTypes();
            var response = new ApiResponse<IEnumerable<Video>>();
            IEnumerable<Video> video = await _videoRepository.GetAllAsyn();
            if (video == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = video;
            return response;
        }

        public async Task<ApiResponse<Video>> CreateVideo(VideoDto videoDto)
        {
            var response = new ApiResponse<Video>();
            try
            {
                //check video Exists
                var isExistVideo = await _videoRepository.CountAsync(i => i.Name == videoDto.Name);

                if (isExistVideo != 0)
                {
                    response.Success = false;
                    response.Errors.Add("Video Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new video
                var video = Mapper.Map<Video>(videoDto);
                video.Id = id;
                video.CreatedDate = DateTime.Now;
                video.IsActive = true;
                await _videoRepository.AddAsyn(video);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public void AddVideoTypes()
        {
            VideoTypeDto videoTypeChapter = new VideoTypeDto()
            {
                Name = "ChapterVideo",
                Description = "Contains Chapter Video",
            };

            VideoTypeDto videoTypeCourse = new VideoTypeDto()
            {
                Name = "CourseVideo",
                Description = "Contains Course Video",
            };

            var createVideoTypeCourse = _videoTypeService.CreateVideoType(videoTypeCourse);
            var createVideoTypeChapter = _videoTypeService.CreateVideoType(videoTypeChapter);
        }
    }
}
