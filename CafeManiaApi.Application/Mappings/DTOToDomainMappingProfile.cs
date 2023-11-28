using AutoMapper;
using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Domain.Entities;

namespace CafeManiaApi.Application.Mappings
{
    public class DTOToDomainMappingProfile: Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<ProductDTO, Product>();
        }
    }
}
