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
    public class CheckPointService : ICheckPointService
    {
        private readonly CheckPointRepository _checkPointRepository;
        private readonly ChecklistTypeCheckPointService checklistTypeCheckPointService;

        public CheckPointService()
        {
            _checkPointRepository = new CheckPointRepository();
            checklistTypeCheckPointService = new ChecklistTypeCheckPointService();
        }

        public async Task<ApiResponse<CheckPoint>> GetCheckPointById(Guid id)
        {
            var response = new ApiResponse<CheckPoint>();
            CheckPoint checkPoint = await _checkPointRepository.GetByGuidAsync(id);
            if (checkPoint == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checkPoint;
            return response;
        }

        public async Task<ApiResponse<CheckPoint>> GetCheckPointByName(string typeName)
        {
            var response = new ApiResponse<CheckPoint>();
            CheckPoint checkPoint = await _checkPointRepository.FindAsync(x => x.Name == typeName);
            if (checkPoint == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checkPoint;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<CheckPoint>>> GetAllCheckPoints()
        {
            var response = new ApiResponse<IEnumerable<CheckPoint>>();
            IEnumerable<CheckPoint> checkPoint = await _checkPointRepository.GetAllAsyn();
            if (checkPoint == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checkPoint;
            return response;
        }

        public async Task<ApiResponse<CheckPoint>> CreateCheckPoint(CheckPointDto checkPointDto)
        {
            var response = new ApiResponse<CheckPoint>();
            try
            {
                //check videotype Exists
                var isExistCheckPoint = await _checkPointRepository.CountAsync(i => i.Name == checkPointDto.Name);

                if (isExistCheckPoint != 0)
                {
                    response.Success = false;
                    response.Errors.Add("CheckPoint Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new videotype
                var checkPoint = Mapper.Map<CheckPoint>(checkPointDto);
                checkPoint.Id = id;
                checkPoint.CreatedDate = DateTime.Now;
                checkPoint.UpdatedDate = DateTime.Now;
                checkPoint.IsActive = true;
                await _checkPointRepository.AddAsyn(checkPoint);
                response.Data = checkPoint;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<CheckPoint>> UpdateCheckPoint(CheckPointDto checkPointDto)
        {
            var response = new ApiResponse<CheckPoint>();
            try
            {
                checkPointDto.UpdatedDate = DateTime.Now;
                await _checkPointRepository.UpdateAsync(Mapper.Map<CheckPoint>(checkPointDto), checkPointDto.Id);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }


        public async Task<ApiResponse<IEnumerable<CheckPoint>>> GetCheckPointsByChecklistTypeId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<CheckPoint>>();
            List<CheckPoint> checkPoints = new List<CheckPoint>();
            //subjects based on course id
            ApiResponse<IEnumerable<ChecklistTypeCheckPoint>> courseCheckPoints = new ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>();
            courseCheckPoints = await checklistTypeCheckPointService.GetCheckPointsByChecklistTypeId(id);
            foreach (ChecklistTypeCheckPoint cs in courseCheckPoints.Data)
            {
                CheckPoint checkPoint = await _checkPointRepository.GetByGuidAsync(cs.CheckPointId);
                if (checkPoint != null && checkPoint.IsActive==true)
                {
                    checkPoints.Add(checkPoint);
                }
            }

            if (checkPoints == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checkPoints;
            return response;
        }
    }
}
