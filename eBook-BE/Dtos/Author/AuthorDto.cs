﻿namespace eBook_BE.Dtos.Author
{
    public class AuthorDto : BaseResponseDto
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
