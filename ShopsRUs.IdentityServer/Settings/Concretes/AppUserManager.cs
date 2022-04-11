using ShopsRUs.IdentityServer.Models;
using ShopsRUs.IdentityServer.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Repositories
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        IGenericDal<AppUser> _genericDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
            _genericDal = genericDal;
        }
    }
}
