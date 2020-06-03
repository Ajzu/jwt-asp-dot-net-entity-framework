using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ChecklistTypeOldController : ApiController
    {
        private readonly ChecklistTypeService _checklisttypeServices;

        public ChecklistTypeOldController() 
        {
            _checklisttypeServices = new ChecklistTypeService(); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<ChecklistType>> CreateChecklistType(ChecklistTypeDto course)
        {
            try
            {
                return await _checklisttypeServices.CreateChecklistType(course);
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
                return await _checklisttypeServices.GetAllChecklistTypes();
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
                return await _checklisttypeServices.GetChecklistTypeById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChecklistType>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

