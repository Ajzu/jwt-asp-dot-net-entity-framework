using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ChecklistTypeCheckPointController : ApiController
    {
        private readonly ChecklistTypeCheckPointService _checklisttypeCheckPointServices;

        public ChecklistTypeCheckPointController()
        {
            _checklisttypeCheckPointServices = new ChecklistTypeCheckPointService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<ChecklistTypeCheckPoint>> CreateChecklistTypeCheckPoint(ChecklistTypeCheckPointDto checklisttypeCheckPoint)
        {
            try
            {
                return await _checklisttypeCheckPointServices.CreateChecklistTypeCheckPoint(checklisttypeCheckPoint);
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChecklistTypeCheckPoint>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>> GetAllChecklistTypeCheckPoints()
        {
            try
            {
                return await _checklisttypeCheckPointServices.GetAllChecklistTypeCheckPoints();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ChecklistTypeCheckPoint>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<ChecklistTypeCheckPoint>> GetChecklistTypeCheckPoint(string id)
        {
            try
            {
                return await _checklisttypeCheckPointServices.GetByChecklistTypeCheckPointId(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChecklistTypeCheckPoint>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

