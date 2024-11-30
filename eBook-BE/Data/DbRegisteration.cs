using eBook_BE.ConfigSettings;
using eBook_BE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBook_BE.Data
{
    public static class DbRegisteration
    {
        public static WebApplicationBuilder AddEntityFrameworkCore(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}
