using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Application.Services;
using CafeManiaApi.Domain.Interfaces;
using CafeManiaApi.Infra.Data.Context;
using CafeManiaApi.Infra.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Infra.Ioc
{
    public static class DependencyInjection
    {
            
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {

            services.AddDbContext<ApplicationDbContext>(options => 
                { 
                    options.UseNpgsql(Environment.GetEnvironmentVariable("ProductionConnection"),p=> p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)); 
                });
            services.AddDataProtection().UseCryptographicAlgorithms(
                new AuthenticatedEncryptorConfiguration
                    {
                        EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                        ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                    });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => { builder.WithOrigins("http://localhost:3000"); });
            });
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("/root/.aspnet/DataProtection-Keys"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CafeManiaApi", Version = "v1" });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();


            return services;
        }

    }
}
