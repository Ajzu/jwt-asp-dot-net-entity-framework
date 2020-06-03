using AutoMapper;
using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi;

namespace WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        private readonly LoginService _loginServices;

        public LoginController()
        {
            _loginServices = new LoginService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<LoginDto>> Login(UserDto user)
        {
            try
            {
                var response = new ApiResponse<LoginDto>();
                LoginDto loginDto = new LoginDto();

                var loginResponse = await _loginServices.Login(user);
                response.Success = loginResponse.Success;
                response.Errors = loginResponse.Errors;

                if (loginResponse.Success == true)
                {
                    string token = JwtManager.GenerateToken(loginResponse.Data.Name);
                    loginDto.Token = token;
                    response.Data = loginDto;
                }
                return response;
            }
            catch (Exception ex)
            {
                return new ApiResponse<LoginDto>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

