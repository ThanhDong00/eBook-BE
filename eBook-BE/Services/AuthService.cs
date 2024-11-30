using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.User;
using eBook_BE.Enum;
using eBook_BE.Helpers.Interface;
using eBook_BE.Models;
using eBook_BE.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class AuthService : IAuthService
    {

        private readonly IClaimService _claimService;
        private UserManager<UserApplication> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private ITokenService _tokenService;

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext context
            , IMapper mapper
            , UserManager<UserApplication> userManager
            , RoleManager<ApplicationRole> roleManager
            , ITokenService tokenService
            , IClaimService claimService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _claimService = claimService;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == loginRequest.Username);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found!");
            }

            var result = _userManager.CheckPasswordAsync(user, loginRequest.Password).Result;

            if (!result)
            {
                throw new Exception("Password is incorrect");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = _tokenService.GenerateAccessToken(user, roles);

            LoginResponseDto loginResponse = new LoginResponseDto
            {
                AccessToken = accessToken,
                User = _mapper.Map<UserDto>(user),
            };

            return loginResponse;
        }

        public async Task<Guid> Register(RegisterRequestDto registerRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == registerRequest.Email
                                || x.UserName == registerRequest.Username);

            if (user != null)
            {
                throw new Exception("User already exists");
            }

            var newUser = new UserApplication
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Username,
                FullName = registerRequest.FullName,
            };

            var result = await _userManager.CreateAsync(newUser, registerRequest.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Register failed");
            }

            await _userManager.AddToRoleAsync(newUser, Roles.User);

            return newUser.Id;
        }
    }
}
