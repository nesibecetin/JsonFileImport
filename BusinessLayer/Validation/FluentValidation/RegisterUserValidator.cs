using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class RegisterUserValidator : AbstractValidator<Users>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(x => x.LanguageId).NotEmpty().WithMessage("Boş olamaz");



        }

    }
}
