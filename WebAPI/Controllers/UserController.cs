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
    public class UserController : ApiController
    {
        private readonly UserService _userServices;

        public UserController()
        {
            _userServices = new UserService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<User>> CreateUser(UserDto user)
        {
            try
            {
                return await _userServices.CreateUser(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpPost]
        public async Task<ApiResponse<User>> UpdateUser(UserDto user)
        {
            try
            {
                return await _userServices.UpdateUser(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[Authorize]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                return await _userServices.GetAllUsers();
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<User>>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [HttpGet]
        public async Task<ApiResponse<User>> GetUserById(string id)
        {
            try
            {
                return await _userServices.GetUserById(new Guid(id));
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [JwtAuthentication]
        [HttpPost]
        public async Task<ApiResponse<User>> GetUser(UserDto user)
        {
            try
            {
                return await _userServices.GetUser(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

