using Microsoft.AspNetCore.Identity;

namespace eBook_BE.Models
{
    public class UserApplication: IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? Address { get; set; }

        public Cart Cart { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
