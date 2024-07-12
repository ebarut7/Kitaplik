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
    public class ShareSettingMap : EntityMap<ShareSetting>
    {
        public override void Configure(EntityTypeBuilder<ShareSetting> builder)
        {
            builder.HasKey(e => e.Id);


          

            base.Configure(builder);
        }
    }
}
