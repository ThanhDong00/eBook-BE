namespace eBook_BE.Models
{
    public class Cart : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
        public UserApplication User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
