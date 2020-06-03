using EnityModel;
using Repositorie.Repositories;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace Service.Service
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly RefreshTokenRepository _refreshTokenRepository;
       
        public RefreshTokenService()
        {
            _refreshTokenRepository = new RefreshTokenRepository();
        }
        public async Task<ApiResponse<RefreshToken>> AddRefreshToken(RefreshToken refreshTokenDto)
        {
            var response = new ApiResponse<RefreshToken>();

            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                ClientId = refreshTokenDto.ClientId,
                CreatedBy = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ExpiresAt = refreshTokenDto.ExpiresAt,
                IsActive = true,
                IssuedAt = refreshTokenDto.IssuedAt,
                ProtectedTicket = refreshTokenDto.ProtectedTicket,
                RefreshTokensId = refreshTokenDto.RefreshTokensId,
                Subject = refreshTokenDto.Subject
            };

            RefreshToken token = await _refreshTokenRepository.AddAsyn(refreshToken);
            if (token == null)
            {
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Data = token;
            return response;
        }

        public async Task<ApiResponse<RefreshToken>> FindRefreshToken(string refreshToken)
        {
            var response = new ApiResponse<RefreshToken>();
            var token = await _refreshTokenRepository.FindAsync(i => i.RefreshTokensId == refreshToken);
            if (token == null)
            {
                response.Success = false;
            }
            response.Data = token;
            return response;
        }
        public async Task<ApiResponse<RefreshToken>> RemoveRefreshToken(RefreshToken refreshToken)
        {
            var response = new ApiResponse<RefreshToken>();
            await _refreshTokenRepository.DeleteAsyn(refreshToken);

            return response;
        }
    }
}
