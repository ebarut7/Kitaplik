using Kitaplik.Core.DataAccess.EntityFrameworkCore.Mappings;
using Kitaplik.Core.Entities;
using Kitaplik.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class NoteMap : EntityMap<Note>
    {
        public override void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Content).IsRequired();

            builder.HasOne(x => x.ShareSetting).WithOne(x => x.Note).HasForeignKey<ShareSetting>(x => x.NoteId);
                  
            base.Configure(builder);
        }
    }
}
