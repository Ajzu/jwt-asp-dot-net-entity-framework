using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Utilities;


namespace Service.Service
{

    public class UserOldService : IUserOldService
    {

        private readonly UserOldRepository _usersRepository;

        public UserOldService()
        {
            _usersRepository = new UserOldRepository();
        }

        public async Task<ApiResponse<IEnumerable<UserOld>>> GetAllUsers()
        {
            var response = new ApiResponse<IEnumerable<UserOld>>();
            IEnumerable<UserOld> user = await _usersRepository.GetAllAsyn();
            if (user == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = user;
            return response;
        }

        public async Task<ApiResponse<UserOld>> CreateUser(UserOldDto userDto)
        {
            var response = new ApiResponse<UserOld>();


            try
            {

                //check user Exists
                var isExistUser = await _usersRepository.CountAsync(i => i.UserName == userDto.UserName);

                if (isExistUser != 0)
                {
                    response.Success = false;
                    response.Errors.Add("Username Already Exists");
                    return response;
                }
                //create roles
                var userRoles = new List<UserRolesOld>();
                var id = Guid.NewGuid();
              

              
                foreach (var role in userDto.UserRoles)
                {
                    if (!role.IsSelected) continue;
                    dynamic  roleNmae="";
                    switch (role.Role)
                    {
                        case "Investor":
                            roleNmae = RoleName.Investor;
                            break;
                        case "NonInvestor":
                            roleNmae = RoleName.NonInvestor;
                            break;
                    }
                    var userRole = new UserRolesOld()
                    {
                        Id = Guid.NewGuid(),
                        Role = roleNmae,
                        CreatedBy = id,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    userRoles.Add(userRole);
                }
             
                PasswordManager passwordManger = new PasswordManager();

                //create new user
                var user = Mapper.Map<UserOld>(userDto);
                user.Id = id;
                user.Password = passwordManger.Encrypt(passwordManger.GeneratePassword());
                user.CreatedBy = user.Id;
                user.CreatedDate = DateTime.Now;
                user.Roles = userRoles;
                user.IsActive = true;
                await _usersRepository.AddAsyn(user);
                response.Success = true;
               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;

        }

        public async Task<ApiResponse<UserOld>> FindUser(UserOld user)
        {
            var response = new ApiResponse<UserOld>();
            var passwordManger = new PasswordManager();
            try
            {
                string password = passwordManger.Encrypt(user.Password);
                var userRes = await _usersRepository.FindAsync(i => i.UserName == user.UserName && i.Password == password);
                if (userRes == null)
                {
                    response.Success = true;
                    response.Errors.Add("invalid User");
                    return response;
                }

                response.Success = true;
                response.Data = userRes;
                return response;
            }
            catch(Exception ex)
            {

                response.Success = false;
                response.Errors.Add(ex.Message);
                return response;
            }
        }
    }
}