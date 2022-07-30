using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class LoginUserValidator : AbstractValidator<Users>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş olamaz");
        }
    }
}
