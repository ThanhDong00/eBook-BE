using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class BookAuthorConfig : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            builder.HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);
        }
    }
}
