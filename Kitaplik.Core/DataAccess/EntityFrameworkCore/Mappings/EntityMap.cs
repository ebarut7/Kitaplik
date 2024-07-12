using Kitaplik.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Kitaplik.Core.DataAccess.EntityFrameworkCore.Mappings
{
    public class EntityMap<T> : IEntityTypeConfiguration<T> where T : class, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
        }
    }
}
