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
    public class BookMap : EntityMap<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Author).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.Note).WithOne(x => x.Book).HasForeignKey<Note>(x => x.BookId);


            base.Configure(builder);
        }
    }
}
