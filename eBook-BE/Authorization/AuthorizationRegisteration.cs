using eBook_BE.ConfigSettings;
using eBook_BE.Data;
using eBook_BE.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eBook_BE.Authorization
{
    public static class AuthorizationRegisteration
    {
        public static WebApplicationBuilder AddAppAuthorization(this WebApplicationBuilder builder)
        {

            var jwtOption = builder.Configuration.GetSection(nameof(JWTConfigSetting)).Get<JWTConfigSetting>();
            builder.Services.AddSingleton<JWTConfigSetting>(jwtOption);
            builder.Services.AddIdentity();
            var key = Encoding.ASCII.GetBytes(jwtOption.SecretKey);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidAudience = jwtOption.Audience,
                        ValidIssuer = jwtOption.Issuer,
                        ValidateLifetime = true
                    };
                });
            return builder;
        }
        private static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserApplication, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });
        }
    }
}
