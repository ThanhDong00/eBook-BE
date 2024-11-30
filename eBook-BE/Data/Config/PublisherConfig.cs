using eBook_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBook_BE.Data.Config
{
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
