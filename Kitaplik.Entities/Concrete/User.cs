using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitaplik.Core.Entities;
using Kitaplik.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Kitaplik.Entities.Concrete
{
    public class User :MyUser,IEntity
    {
        

        public AppUser AppUser { get; set; }

        public List<Book> Books { get; set; }

        
    }

}
