using AutoMapper;
using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Service.Service
{
    public class LoginService : ILoginService
    {
        private readonly UserService _userServices;

        public LoginService()
        {
            _userServices = new UserService();
        }

        //public async Task<ApiResponse<string>> LoginNew(UserDto userDto)
        //{
        //    return await _userServices.GetLogin(userDto);
        //}

        public async Task<ApiResponse<User>> Login(UserDto userDto)
        {
            return await _userServices.GetLogin(userDto);
            //return await _userServices.GetUser(userDto);
        }
    }
}
