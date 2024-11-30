namespace eBook_BE.Dtos.Publisher
{
    public class PublisherDto : BaseResponseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
