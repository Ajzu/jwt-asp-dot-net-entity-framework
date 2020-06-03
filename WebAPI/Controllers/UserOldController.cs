using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{

    public class UserOldController : ApiController
    {

        private readonly UserOldService _userServices;

        public UserOldController() { _userServices = new UserOldService(); }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<UserOld>> CreateUser(UserOldDto user)
        {
            try
            {
                return await _userServices.CreateUser(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserOld>() { Success = false, Errors = new List<string>() { ex.Message } };
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<UserOld>>> GetUser()
        {
            try
            {

                return await _userServices.GetAllUsers();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<UserOld>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }

        }
    }
}

