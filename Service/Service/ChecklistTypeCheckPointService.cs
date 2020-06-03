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

    public class ChecklistTypeCheckPointService : IChecklistTypeCheckPointService
    {

        private readonly ChecklistTypeCheckPointRepository _checklisttypeCheckPointRepository;

        public ChecklistTypeCheckPointService()
        {
            _checklisttypeCheckPointRepository = new ChecklistTypeCheckPointRepository();
        }

        public async Task<ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>> GetCheckPointsByChecklistTypeId(Guid id)
        {
            var response = new ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>();
            IEnumerable<ChecklistTypeCheckPoint> checklisttypeCheckPoints = await _checklisttypeCheckPointRepository.FindAllAsync(x => x.ChecklistTypeId == id);
            if (checklisttypeCheckPoints == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklisttypeCheckPoints;
            return response;
        }

        public async Task<ApiResponse<ChecklistTypeCheckPoint>> GetByChecklistTypeCheckPointId(Guid id)
        {
            var response = new ApiResponse<ChecklistTypeCheckPoint>();
            ChecklistTypeCheckPoint checklisttypeCheckPoint = await _checklisttypeCheckPointRepository.GetByGuidAsync(id);
            if (checklisttypeCheckPoint == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklisttypeCheckPoint;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>> GetAllChecklistTypeCheckPoints()
        {
            var response = new ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>();
            IEnumerable<ChecklistTypeCheckPoint> checklisttypeCheckPoint = await _checklisttypeCheckPointRepository.GetAllAsyn();
            if (checklisttypeCheckPoint == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklisttypeCheckPoint;
            return response;
        }

        public async Task<ApiResponse<ChecklistTypeCheckPoint>> CreateChecklistTypeCheckPoint(ChecklistTypeCheckPointDto checklisttypeCheckPointDto)
        {
            var response = new ApiResponse<ChecklistTypeCheckPoint>();
            try
            {
                //check checklisttype Exists
                var isExistChecklistTypeCheckPoint = await _checklisttypeCheckPointRepository.CountAsync(i => i.ChecklistTypeId == checklisttypeCheckPointDto.ChecklistTypeId && i.CheckPointId == checklisttypeCheckPointDto.CheckPointId);

                if (isExistChecklistTypeCheckPoint != 0)
                {
                    response.Success = false;
                    response.Errors.Add("ChecklistTypeCheckPoint Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new checklisttype
                var checklisttypeCheckPoint = Mapper.Map<ChecklistTypeCheckPoint>(checklisttypeCheckPointDto);
                checklisttypeCheckPoint.Id = id;

                //checklisttype.CreatedBy = checklisttype.Id;
                checklisttypeCheckPoint.CreatedDate = DateTime.Now;
                //checklisttype.Roles = checklisttypeRoles;
                checklisttypeCheckPoint.IsActive = true;
                await _checklisttypeCheckPointRepository.AddAsyn(checklisttypeCheckPoint);
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