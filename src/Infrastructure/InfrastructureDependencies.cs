using Buna.SharedKernel;
using Core.Users.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddDatabaseDeveloperPageExceptionFilter();

            if (configuration.GetValue<bool>("IsDevelopment"))
            {
                services.AddIdentityCore<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;  
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            }
            else
            {
                services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddSignInManager()
                    .AddDefaultTokenProviders();
            }

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
