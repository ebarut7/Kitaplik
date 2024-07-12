using Kitaplik.Core.DataAccess.EntityFrameworkCore.Mappings;
using Kitaplik.Core.Entities;
using Kitaplik.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class UserMap : EntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            
            



            builder.HasMany(x => x.Books).WithOne(x => x.User).HasForeignKey(x=>x.Id);

            base.Configure(builder);
        }
    }
}
