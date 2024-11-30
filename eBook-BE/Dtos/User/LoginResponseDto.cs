namespace eBook_BE.Dtos.User
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string AccessToken { get; set; }
        //public string RefreshToken { get; set; }


    }
}
