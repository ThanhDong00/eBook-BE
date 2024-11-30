using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(b => b.BookId);

            builder.HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(b => b.CategoryId);
        }
    }
}
