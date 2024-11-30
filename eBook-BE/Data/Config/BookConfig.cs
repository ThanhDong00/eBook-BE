using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }
    }
}
