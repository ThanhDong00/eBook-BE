using eBook_BE.Dtos.User;

namespace eBook_BE.Services.Interface
{
    public interface IAuthService 
    {
        Task<Guid> Register(RegisterRequestDto registerRequest);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);

    }
}
