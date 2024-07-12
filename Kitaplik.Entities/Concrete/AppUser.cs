using Kitaplik.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public User User { get; set; }
    }
}
