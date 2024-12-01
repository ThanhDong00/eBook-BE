using eBook_BE.Helpers;
using eBook_BE.Helpers.Interface;
using eBook_BE.Services.Interface;

namespace eBook_BE.Services
{
    public static class ServiceRegisteration
    {
        public static void AddApplicationServices(this IServiceCollection services) { 
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookAuthorService, BookAuthorService>();
            services.AddScoped<IBookCategoryService, BookCategoryService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IRecommendationService, RecommendationService>();
            services.AddScoped<IAuthService, AuthService>();    
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
