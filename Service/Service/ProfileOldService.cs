using DTOModel;
using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Threading.Tasks;


namespace Service.Service
{
    public class ProfileOldService : IProfileOldService

    {

        private readonly ProfileOldRepository _profileRepository;

        private readonly UserOldRepository _usersRepository;
        
        public ProfileOldService()
        {
            _profileRepository = new ProfileOldRepository();
            _usersRepository= new UserOldRepository ();
    }

        public async Task<ApiResponse<UserProfileOld>> CreateProfile(ProfileOldDTO profileDto)
        {
            var response = new ApiResponse<UserProfileOld>();
            try
            {
               int isExist= await _profileRepository.CountAsync(i=>i.UserId== profileDto.UserId);
                if (isExist == 0)
                {
                    var Skills = string.Join(",", profileDto.Skills);
                    UserProfileOld profile = new UserProfileOld();
                    profile.Id = Guid.NewGuid();

                    profile.Skills = Skills;
                    profile.Looking = profileDto.Looking;
                    profile.Description = profileDto.Description;
                    profile.CreatedDate = DateTime.Now;
                    profile.IsActive = true;

                    var userRes = await _usersRepository.FindAsync(i => i.Id == profileDto.UserId);
                    if (userRes != null)
                    {
                        profile.CreatedBy = userRes.Id;
                        profile.UserId = userRes.Id;
                       var data= await _profileRepository.AddAsyn(profile);
                        response.Success = true;
                        response.Data = data;
                    }
                    else
                    {
                        response.Success = false;
                        response.Errors.Add("User not found");
                    }
                }
                else
                {
                    response.Success = false;
                    response.Errors.Add("Already User Profile Created ");
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;

        }

        public async Task<ApiResponse<UserProfileOld>> GetProfile(string userid)
        {
            var response = new ApiResponse<UserProfileOld>();
            try
            {
                UserProfileOld profile = new UserProfileOld();
                var res = await _profileRepository.FindAsync(i => i.UserId.ToString() == userid);
                if (res != null)
                {
                    response.Success = true;
                    response.Data = res;
                }
                else
                {
                    response.Success = true;
                    response.Errors.Add("this user dont have profile");
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;

        }
    }
}
