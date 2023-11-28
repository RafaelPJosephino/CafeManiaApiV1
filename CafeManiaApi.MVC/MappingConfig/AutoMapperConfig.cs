using CafeManiaApi.Application.Mappings;

namespace CafeManiaApi.MVC.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)  throw new ArgumentNullException(nameof(services)); 

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile), typeof(DTOToDomainMappingProfile));
        }
 
    }
}
