using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProfileOldController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ApiResponse<UserProfileOld>> CreateProfile(ProfileOldDTO profile)
        {
            try
            {
                ProfileOldService service = new ProfileOldService();
                return await service.CreateProfile(profile);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserProfileOld>() { Success = false, Errors = new List<string>() { ex.Message } };
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<UserProfileOld>> GetProfile(string userid)
        {
            try
            {
                ProfileOldService service = new ProfileOldService();
                return await service.GetProfile(userid);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserProfileOld>() { Success = false, Errors = new List<string>() { ex.Message } };
            }

        }
    }
}
