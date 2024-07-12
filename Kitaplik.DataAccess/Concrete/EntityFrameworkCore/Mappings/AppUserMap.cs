using Kitaplik.Core.DataAccess.EntityFrameworkCore.Mappings;
using Kitaplik.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class AppUserMap : EntityMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.AppUser).HasForeignKey<User>(x => x.Id);

            base.Configure(builder);
        }
    }
}
