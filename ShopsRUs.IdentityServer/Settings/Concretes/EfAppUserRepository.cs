using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.IdentityServer.Dtos;
using ShopsRUs.IdentityServer.Models;
using ShopsRUs.IdentityServer.Settings.Context;
using ShopsRUs.IdentityServer.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        private readonly IMapper _mapper;
        public EfAppUserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<AppUserGetDto> GetContactByIdAsync(Guid uuid)
        {
            using var context = new ShopsRUsContext();
            return await (Task<AppUserGetDto>)context.AppUsers.Where(x => x.Id == uuid).Select(x => new AppUserGetDto()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName,
                IsEmployee = x.IsEmployee,
                IsMember = x.IsMember,
                MemberRegistrationTime = x.MemberRegistrationTime
            }).FirstOrDefaultAsync();
        }

        public async Task<List<AppUserGetDto>> GetContactsListAsync()
        {
            using var context = new ShopsRUsContext();
            return await (Task<List<AppUserGetDto>>)context.AppUsers.Select(x => new AppUserGetDto()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName,
                IsEmployee = x.IsEmployee,
                IsMember = x.IsMember,
                MemberRegistrationTime = x.MemberRegistrationTime
            }).ToListAsync();
        }
    }
}
