using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            builder.HasOne(ci => ci.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(ci => ci.BookId);
        }
    }
}
