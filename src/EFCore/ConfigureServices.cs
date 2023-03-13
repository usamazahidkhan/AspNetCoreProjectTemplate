using ProjectTemplate.Application;
using ProjectTemplate.EFCoreAndIdentity.Persistence;
using ProjectTemplate.EFCoreAndIdentity.Persistence.Interceptors;
using ProjectTemplate.EFCoreAndIdentity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MediatR;
using ProjectTemplate.Infrastructure.EfCore;
using ProjectTemplate.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ProjectTemplateDB"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("LocalConnection")
                        /*,builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)*/));
            }

            services.AddTransient<IDateTime, DateTimeService>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));
            services.AddScoped<IUnitOfWork, UnitOfWorkWithRepositories>();

            services.AddScoped<ApplicationDbContextInitialiser>();

            //Identity services
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddRoles<IdentityRole>()
               .AddUserManager<UserManager>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            });

            return services;
        }
    }
}
