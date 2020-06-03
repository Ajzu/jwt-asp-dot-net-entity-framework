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
    public class ChecklistTypeService : IChecklistTypeService
    {
        private readonly ChecklistTypeRepository _checklistTypeRepository;

        public ChecklistTypeService()
        {
            _checklistTypeRepository = new ChecklistTypeRepository();
        }

        public async Task<ApiResponse<ChecklistType>> GetChecklistTypeById(Guid id)
        {
            var response = new ApiResponse<ChecklistType>();
            ChecklistType checklistType = await _checklistTypeRepository.GetByGuidAsync(id);
            if (checklistType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklistType;
            return response;
        }

        public async Task<ApiResponse<ChecklistType>> GetChecklistTypeByName(string typeName)
        {
            var response = new ApiResponse<ChecklistType>();
            ChecklistType checklistType = await _checklistTypeRepository.FindAsync(x => x.Name == typeName);
            if (checklistType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklistType;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<ChecklistType>>> GetAllChecklistTypes()
        {
            var response = new ApiResponse<IEnumerable<ChecklistType>>();
            IEnumerable<ChecklistType> checklistType = await _checklistTypeRepository.GetAllAsyn();
            if (checklistType == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = checklistType;
            return response;
        }

        public async Task<ApiResponse<ChecklistType>> CreateChecklistType(ChecklistTypeDto checklistTypeDto)
        {
            var response = new ApiResponse<ChecklistType>();
            try
            {
                //check videotype Exists
                var isExistChecklistType = await _checklistTypeRepository.CountAsync(i => i.Name == checklistTypeDto.Name);

                if (isExistChecklistType != 0)
                {
                    response.Success = false;
                    response.Errors.Add("ChecklistType Already Exists");
                    return response;
                }

                var id = Guid.NewGuid();

                //create new videotype
                var checklistType = Mapper.Map<ChecklistType>(checklistTypeDto);
                checklistType.Id = id;
                checklistType.CreatedDate = DateTime.Now;
                checklistType.IsActive = true;
                await _checklistTypeRepository.AddAsyn(checklistType);
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
