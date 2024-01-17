using WineTourism.Application.DTOs;
using WineTourism.Shared;

namespace WineTourism.Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<Result<string>> RegisterUser(RegisterDTO registerDto);
        Task<Result<string>> Login(LoginDTO loginDto);
    }
}
