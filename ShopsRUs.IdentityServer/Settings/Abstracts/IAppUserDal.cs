using ShopsRUs.IdentityServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Interfaces
{
    public interface IAppUserDal
    {
        Task<List<AppUserGetDto>> GetContactsListAsync();
        Task<AppUserGetDto> GetContactByIdAsync(int id);
    }
}
