using AutoMapper;
using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Utilities;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordManager _passwordManager;

        public UserService()
        {
            _userRepository = new UserRepository();
            _passwordManager = new PasswordManager();
        }

        public async Task<ApiResponse<User>> GetUserById(Guid id)
        {
            var response = new ApiResponse<User>();
            User user = await _userRepository.GetByGuidAsync(id);
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<User>> GetUserByName(string typeName)
        {
            var response = new ApiResponse<User>();
            User user = await _userRepository.FindAsync(x => x.Name == typeName);
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<User>> GetLogin(UserDto userDto)
        {
            var response = new ApiResponse<User>();
            string password = GetEncryptedPassword(userDto.Password);
            User user = await _userRepository.FindAsync(x => x.Email == userDto.Email && x.Password == password);
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<User>> GetUser(UserDto userDto)
        {
            var response = new ApiResponse<User>();
            User user = await _userRepository.FindAsync(x => x.Email == userDto.Email);
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<User>> UpdateUser(UserDto userDto)
        {
            var response = new ApiResponse<User>();
            string password = GetEncryptedPassword(userDto.Password);
            userDto.Password = password;
            var user = await _userRepository.UpdateAsync(Mapper.Map<User>(userDto), userDto.Id);
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<IEnumerable<User>>> GetAllUsers()
        {
            var response = new ApiResponse<IEnumerable<User>>();
            IEnumerable<User> user = await _userRepository.GetAllAsyn();
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<User>> CreateUser(UserDto userDto)
        {
            var response = new ApiResponse<User>();
            try
            {
                //check user Exists
                var isExistUser = await _userRepository.CountAsync(i => i.Email == userDto.Email);

                if (isExistUser != 0)
                {
                    response.Success = false;
                    response.Errors.Add("User Already Exists");
                    return response;
                }
                var id = Guid.NewGuid();
                //create new user
                var user = Mapper.Map<User>(userDto);
                user.Id = id;
                user.CreatedDate = DateTime.Now;
                user.IsActive = true;
                user.Password = GetEncryptedPassword(userDto.Password);
                await _userRepository.AddAsyn(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public string GetEncryptedPassword(string password)
        {
            return _passwordManager.Encrypt(password);
        }

        public async Task<ApiResponse<string>> ForgotPassword(UserDto userDto)
        {
            var response = new ApiResponse<string>();
            User user = await _userRepository.FindAsync(x => x.Email == userDto.Email);
            if (user == null)
            {                
                response.Success = false;
                response.Data = "User Not Found";
                return response;
            }
            response.Success = true;
            response.Data = _passwordManager.GeneratePassword();
            return response;
        }
    }
}
