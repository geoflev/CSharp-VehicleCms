using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleCms.Persistence.Entities.Bases;

namespace VehicleCms.Persistence.Configurations.Bases
{
    public class TrackableConfiguration<T> : IEntityTypeConfiguration<T> where T : TrackableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.ModifiedBy).IsRequired(false);
            builder.Property(x => x.ModifiedAt).IsRequired(false);
        }
    }
}