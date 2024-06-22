using FluentValidation;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Validations
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title boş olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content boş olamaz");
        }
    }
}
