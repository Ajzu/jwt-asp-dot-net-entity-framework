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
    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly ForgotPasswordRepository _forgotPasswordRepository;
        private readonly UserService _userServices;
        private readonly ExternalCommunication _externalCommunication;

        public ForgotPasswordService()
        {
            _forgotPasswordRepository = new ForgotPasswordRepository();
            _userServices = new UserService();
            _externalCommunication = new ExternalCommunication();
        }

        public async Task<ApiResponse<string>> ForgotPassword(UserDto userDto)
        {
            var samplePassword = await _userServices.ForgotPassword(userDto);
            if(samplePassword.Success == true)
            {
                ForgotPasswordDto forgotPasswordDto = new ForgotPasswordDto();
                forgotPasswordDto.Email = userDto.Email;
                forgotPasswordDto.OTP = samplePassword.Data;
                var saveOTP = await SaveForgotPasswordOTP(forgotPasswordDto);

                samplePassword.Success = saveOTP.Success;
                samplePassword.Errors = saveOTP.Errors;
                samplePassword.Data = "";
            }            
            return samplePassword;
        }

        public async Task<ApiResponse<ForgotPassword>> SaveForgotPasswordOTP(ForgotPasswordDto forgotPasswordDto)
        {
            var response = new ApiResponse<ForgotPassword>();
            try
            {
                var id = Guid.NewGuid();
                var forgotPassword = Mapper.Map<ForgotPassword>(forgotPasswordDto);
                forgotPassword.Id = id;
                forgotPassword.CreatedDate = DateTime.Now;
                forgotPassword.IsActive = true;
                await _forgotPasswordRepository.AddAsyn(forgotPassword);
                response.Success = true;
                _externalCommunication.SendMail(forgotPasswordDto.Email, forgotPasswordDto.OTP);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }
            return response;
        }

        public async Task<ApiResponse<string>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            //check forgotpassword request exists in database.
            var response = new ApiResponse<string>();
            ForgotPassword forgotPassword = await _forgotPasswordRepository.FindAsync(x => x.Email == changePasswordDto.Email && x.OTP == changePasswordDto.OTP && x.IsActive==true);
            if (forgotPassword == null)
            {
                response.Success = false;
                response.Data = "OTP Not Found";
                return response;
            }
            else
            {
                //get existing user password
                UserDto user = new UserDto();
                user.Email = changePasswordDto.Email;
                var userResponse = await _userServices.GetUser(user);
                if(userResponse.Success == true)
                {
                    //update new password
                    user = Mapper.Map<UserDto>(userResponse.Data);
                    user.Password = changePasswordDto.Password;
                    var updateUser = await _userServices.UpdateUser(user);
                    if(updateUser.Success == true)
                    {
                        //deactivate OTP
                        response.Data = "Password Changed Successfully.";
                        forgotPassword.IsActive = false;
                        var deactivateOTP = await _forgotPasswordRepository.UpdateAsync(forgotPassword, forgotPassword.Id);
                    }                
                }
                else
                {
                    response.Success = false;
                    response.Data = "User Not Found.";
                    return response;
                }
            }
            response.Success = true;
            return response;
        }
    }
}
