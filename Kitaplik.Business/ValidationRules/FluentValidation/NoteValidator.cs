using FluentValidation;
using Kitaplik.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.ValidationRules.FluentValidation
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(p => p.Content).NotEmpty();
            RuleFor(p => p.IsShared).NotEmpty();
            
        }
    }
}
