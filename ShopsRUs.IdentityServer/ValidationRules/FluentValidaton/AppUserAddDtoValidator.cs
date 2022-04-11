using FluentValidation;
using ShopsRUs.IdentityServer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.ValidationRules.FluentValidaton
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Isım boş geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SoyIsım boş geçilemez");
        }
    }
}
