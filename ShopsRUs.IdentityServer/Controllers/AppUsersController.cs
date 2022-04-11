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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _appUserService.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var appUser = await _appUserService.GetByIdAsync(Id);
            return Ok(appUser);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(AppUserUpdateDto appUserUpdateDto)
        {
            var currentAppUser = await _appUserService.GetByIdAsync(appUserUpdateDto.Id);
            if (currentAppUser == null)
            {
                return BadRequest();
            }
            await _appUserService.UpdateAsync(_mapper.Map<AppUser>(appUserUpdateDto));
            return Created("", appUserUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _appUserService.RemoveAsync(new AppUser() { Id = Id });
            return NoContent();
        }
    }
}
