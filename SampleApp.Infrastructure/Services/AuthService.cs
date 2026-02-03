using SampleApp.Application.DTOs;
using SampleApp.Application.Interfaces;
using SampleApp.Domain.Interfaces;
using SampleApp.Infrastructure.Data;

namespace SampleApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        public LoginResponseDto Login(LoginRequestDto request)
        {
            var user = InMemoryUserStore.Users
        .FirstOrDefault(x => x.UserName == request.UserName);

            if (user is null)
                throw new Exception("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = _jwtTokenService.GenerateToken(user.Id, user.UserName);

            return new LoginResponseDto { Token = token };
        }
    }
}
