using Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using Kitaplik.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitaplik.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class KitaplikContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public KitaplikContext(DbContextOptions<KitaplikContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new NoteMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ShareSettingMap());
            builder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<ShareSetting> ShareSettings { get; set; }

    }
}
