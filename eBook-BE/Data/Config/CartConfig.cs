using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);
        }
    }
}
