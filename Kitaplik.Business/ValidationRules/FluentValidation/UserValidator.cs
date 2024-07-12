using FluentValidation;
using Kitaplik.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).MaximumLength(25);
        }
    }
}
