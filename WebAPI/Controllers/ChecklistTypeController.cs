using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ChecklistTypeController : ApiController
    {
        private readonly ChecklistTypeService _checklistTypeServices;

        public ChecklistTypeController()
        {
            _checklistTypeServices = new ChecklistTypeService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<ChecklistType>> CreateChecklistType(ChecklistTypeDto checklistType)
        {
            try
            {
                return await _checklistTypeServices.CreateChecklistType(checklistType);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChecklistType>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<ChecklistType>>> GetAllChecklistTypes()
        {
            try
            {
                return await _checklistTypeServices.GetAllChecklistTypes();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ChecklistType>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<ChecklistType>> GetChecklistType(string id)
        {
            try
            {
                return await _checklistTypeServices.GetChecklistTypeById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChecklistType>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

