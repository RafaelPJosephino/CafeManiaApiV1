using CafeManiaApi.Infra.Ioc;
using CafeManiaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using CafeManiaApi.MVC.MappingConfig;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Application.Services;
using Microsoft.Extensions.Options;

namespace CafeManiaApi.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Environment.SetEnvironmentVariable("ProductionConnection", "Server=ep-round-fog-74041599.us-east-2.aws.neon.tech;Port=5432;Database=CafeManiaV1;User Id=RafaelPJosephino;Password=molH8dGwtUQ5;Include Error Detail=True;");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructure();
            builder.Services.AddAutoMapperConfiguration();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseCors("AllowSpecificOrigin");
            
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CafeManiaApi V1"); });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}