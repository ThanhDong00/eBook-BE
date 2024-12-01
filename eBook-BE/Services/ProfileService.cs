using AutoMapper;
using eBook_BE.Data;
using eBook_BE.Dtos.Profile;
using eBook_BE.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProfileService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProfileDto>> GetAllProfileAsync()
        {
            var profiles = await _context.Users.ToListAsync();
            return _mapper.Map<List<ProfileDto>>(profiles);
        }

        public async Task<ProfileDto> GetProfileByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Profile not found");
            }
            return _mapper.Map<ProfileDto>(user);
        }

        public async Task<ProfileDto> UpdateProfileAsync(Guid id, UpdateProfileDto updateProfileDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Profile not found");
            }

            _mapper.Map(updateProfileDto, user);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProfileDto>(user);
        }

        public async Task<ProfileDto> DeleteProfileAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Profile not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProfileDto>(user);
        }
    }
}
