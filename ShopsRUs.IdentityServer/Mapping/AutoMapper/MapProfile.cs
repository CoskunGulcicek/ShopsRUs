using AutoMapper;
using ShopsRUs.IdentityServer.Dtos;
using ShopsRUs.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();

            CreateMap<AppUserUpdateDto, AppUser>();
            CreateMap<AppUser, AppUserUpdateDto>();

            CreateMap<AppUserGetDto, AppUser>();
            CreateMap<AppUser, AppUserGetDto>();
        }
    }
}
