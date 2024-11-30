using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(oi => oi.Book)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(oi => oi.BookId);
        }
    }
}
