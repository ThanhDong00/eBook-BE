using eBook_BE.Dtos.Profile;

namespace eBook_BE.Services.Interface
{
    public interface IProfileService
    {
        Task<List<ProfileDto>> GetAllProfileAsync();
        Task<ProfileDto> GetProfileByIdAsync(Guid id);
        Task<ProfileDto> UpdateProfileAsync(Guid id, UpdateProfileDto updateProfileDto);
        Task<ProfileDto> DeleteProfileAsync(Guid id);
    }
}
