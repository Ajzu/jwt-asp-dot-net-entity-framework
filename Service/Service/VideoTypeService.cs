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
    public class VideoTypeService : IVideoTypeService
    {
        private readonly VideoTypeRepository _videoTypeRepository;

        public VideoTypeService()
        {
            _videoTypeRepository = new VideoTypeRepository();
        }

        public async Task<ApiResponse<VideoType>> GetVideoTypeById(Guid id)
        {
            var response = new ApiResponse<VideoType>();
            VideoType videoType = await _videoTypeRepository.GetByGuidAsync(id);
            if (videoType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = videoType;
            return response;
        }

        public async Task<ApiResponse<VideoType>> GetVideoTypeByName(string typeName)
        {
            var response = new ApiResponse<VideoType>();
            VideoType videoType = await _videoTypeRepository.FindAsync(x => x.Name == typeName);
            if (videoType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = videoType;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<VideoType>>> GetAllVideoTypes()
        {
            var response = new ApiResponse<IEnumerable<VideoType>>();
            IEnumerable<VideoType> videoType = await _videoTypeRepository.GetAllAsyn();
            if (videoType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = videoType;
            return response;
        }

        public async Task<ApiResponse<VideoType>> CreateVideoType(VideoTypeDto videoTypeDto)
        {
            var response = new ApiResponse<VideoType>();
            try
            {
                //check videotype Exists
                var isExistVideoType = await _videoTypeRepository.CountAsync(i => i.Name == videoTypeDto.Name);

                if (isExistVideoType != 0)
                {
                    response.Success = false;
                    response.Errors.Add("VideoType Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new videotype
                var videoType = Mapper.Map<VideoType>(videoTypeDto);
                videoType.Id = id;
                videoType.CreatedDate = DateTime.Now;
                videoType.IsActive = true;
                await _videoTypeRepository.AddAsyn(videoType);
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
