using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Concrete;

namespace AdessibindenFrontend.Services
{
    public static class APIServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {

            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddScoped<IPhoneProductService, PhoneProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IUserFavouriteProductService, UserFavouriteProductService>();

            return services;
        }
    }
}
