using FluentValidation;
using Kitaplik.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Author).NotEmpty();
            RuleFor(p => p.ShelfLocation).NotEmpty();
            RuleFor(p => p.ImageUrl).NotEmpty();
            
        }
    }
}
