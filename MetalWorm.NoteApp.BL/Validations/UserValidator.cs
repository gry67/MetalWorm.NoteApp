using FluentValidation;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName boş olamaz");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName boş olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password boş olamaz");
        }
    }
}
