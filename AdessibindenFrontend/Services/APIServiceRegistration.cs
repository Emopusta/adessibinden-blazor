﻿using AdessibindenFrontend.Services.Abstract;
using AdessibindenFrontend.Services.Concrete;

namespace AdessibindenFrontend.Services
{
    public static class APIServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)
        {

            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
