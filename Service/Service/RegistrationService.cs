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
    public class RegistrationService : IRegistrationService
    {
        private readonly UserService _userServices;

        public RegistrationService()
        {
            _userServices = new UserService();
        }

        public async Task<ApiResponse<User>> RegisterUser(UserDto userDto)
        {
            return await _userServices.CreateUser(userDto);
        }
    }
}
