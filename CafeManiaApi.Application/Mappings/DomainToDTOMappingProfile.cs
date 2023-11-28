using AutoMapper;
using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManiaApi.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() 
        {
            CreateMap<User, UserDTO>();
        }
    }
}
