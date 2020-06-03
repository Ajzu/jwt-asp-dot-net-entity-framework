using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        private readonly RegistrationService _registrationServices;

        public RegistrationController()
        {
            _registrationServices = new RegistrationService();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<User>> RegisterUser(UserDto user)
        {
            try
            {
                return await _registrationServices.RegisterUser(user);
            }
            catch (Exception ex)
            {
                return new ApiResponse<User>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }
    }
}

