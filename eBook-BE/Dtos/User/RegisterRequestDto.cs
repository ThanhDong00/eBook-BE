namespace eBook_BE.Dtos.User
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
