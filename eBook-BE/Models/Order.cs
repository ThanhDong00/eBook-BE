namespace eBook_BE.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";

        public Guid UserId { get; set; }
        public UserApplication User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
