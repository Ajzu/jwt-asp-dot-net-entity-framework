using DTOModel;
using EnityModel;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi;
using WebApi.Filters;

namespace WebAPI.Controllers
{
    public class MyController : ApiController
    {
        public MyController()
        {
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> Registration(object user)
        {
            try
            {
                var sampleUser = user;
                return await RegistrationService();
                //return await _chapterService.CreateChapter(chapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        //[JwtAuthentication]
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> Login(object user)
        {
            try
            {
                var sampleUser = user;
                return await LoginService("Arjun","Qwerty@1234");
                //return await _chapterService.CreateChapter(chapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<CustomUser>> Login2(object user)
        {
            try
            {
                var sampleUser = user;
                return await LoginService2("Arjun", "Qwerty@1234");
                //return await _chapterService.CreateChapter(chapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<CustomUser>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        [JwtAuthentication]
        [HttpGet]
        public async Task<ApiResponse<string>> GetUserName()
        {
            try
            {
                //var sampleUser = user;
                return await GetUserService();
                //return await _chapterService.CreateChapter(chapter);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>() { Success = false, Errors = new List<string>() { ex.Message } };
            }
        }

        public async Task<ApiResponse<string>> RegistrationService()
        {
            var response = new ApiResponse<string>();
            string user = await Task.Run(() => "Successfully Called Registration Controller and Service.");
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<string>> LoginService(string userName, string password)
        {
            var response = new ApiResponse<string>();
            string token = GetToken(userName, password);
            string user = await Task.Run(() => "Successfully Called Login Controller and Service.");
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = token;
            return response;
        }

        public async Task<ApiResponse<CustomUser>> LoginService2(string userName, string password)
        {
            CustomUser customUser = new CustomUser();
            var response = new ApiResponse<CustomUser>();
            string token = GetToken(userName, password);
            string user = await Task.Run(() => "Successfully Called Login Controller and Service.");
            if (user == null)
            {
                response.Success = false;
                return response;
            }

            customUser.UserName = "Arjun Sing";
            customUser.Token = token;
            response.Success = true;
            response.Data = customUser;//token;
            
            return response;
        }


        public string GetToken(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }

        public async Task<ApiResponse<string>> GetUserService()
        {
            var response = new ApiResponse<string>();
            string user = await Task.Run(() => "Arjun Logged In Successfully.");
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }
    }

    public class CustomUser
    {
        public string UserName { set; get; }
        public string Token { set; get; }
    }

}
