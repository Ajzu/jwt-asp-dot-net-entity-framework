using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Filters;

namespace WebAPI.Controllers
{
    public class CheckPointController : ApiController
    {
        private readonly CheckPointService _checkPointServices;

        public CheckPointController()
        {
            _checkPointServices = new CheckPointService();
        }

        //[AllowAnonymous]
        [JwtAuthentication]
        [HttpPost]
        public async Task<ApiResponse<CheckPoint>> CreateCheckPoint(CheckPointDto checkPoint)
        {
            try
            {
                return await _checkPointServices.CreateCheckPoint(checkPoint);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CheckPoint>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [JwtAuthentication]
        [HttpPost]
        public async Task<ApiResponse<CheckPoint>> UpdateCheckPoint(CheckPointDto checkPoint)
        {
            try
            {
                return await _checkPointServices.UpdateCheckPoint(checkPoint);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CheckPoint>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [JwtAuthentication]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<CheckPoint>>> GetAllCheckPoints()
        {
            try
            {
                return await _checkPointServices.GetAllCheckPoints();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<CheckPoint>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[JwtAuthentication]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<CheckPoint>>> GetChecklistTypeCheckPoints(Guid id)
        {
            try
            {
                return await _checkPointServices.GetCheckPointsByChecklistTypeId(id);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<CheckPoint>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<CheckPoint>> GetCheckPoint(string id)
        {
            try
            {
                return await _checkPointServices.GetCheckPointById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<CheckPoint>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

