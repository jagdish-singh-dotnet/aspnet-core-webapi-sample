using SampleApp.Application.DTOs;

namespace SampleApp.Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponseDto Login(LoginRequestDto loginRequest);
    }
}
