using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.IdentityServer.Dtos;
using ShopsRUs.IdentityServer.Models;
using ShopsRUs.IdentityServer.Settings.Interfaces;
using ShopsRUs.IdentityServer.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AppUsersController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(AppUserAddDto appUserAddDto)
        {
            var entity = await _appUserService.AddAsync(_mapper.Map<AppUser>(appUserAddDto));
            return Created("", entity);
        }
    }
}
