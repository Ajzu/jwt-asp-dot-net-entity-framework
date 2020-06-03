using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ForgotPasswordController : ApiController
    {
        private readonly ForgotPasswordService _forgotPasswordServices;

        public ForgotPasswordController()
        {
            _forgotPasswordServices = new ForgotPasswordService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> ForgotPassword(UserDto user)
        {
            try
            {
                return await _forgotPasswordServices.ForgotPassword(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                return await _forgotPasswordServices.ChangePassword(changePasswordDto);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

