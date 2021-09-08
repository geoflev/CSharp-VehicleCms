using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VehicleCms.Persistence.Configurations.Bases;
using VehicleCms.Persistence.Entities;

namespace VehicleCms.Persistence.Configurations
{
    public class VehicleConfiguration : TrackableConfiguration<VehicleEntity>
    {
        public override void Configure(EntityTypeBuilder<VehicleEntity> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Vin)
                .IsRequired();

            builder
               .Property(x => x.Make)
               .IsRequired();

            builder
               .Property(x => x.Model)
               .IsRequired();

            builder
               .Property(x => x.ProductionYear)
               .IsRequired();

            builder
               .Property(x => x.Type)
               .IsRequired();

            builder
               .Property(x => x.UserId)
               .IsRequired();

            builder
                 .HasOne(x => x.User)
                .WithMany(x => x.Vehicles)
                .HasForeignKey(x => x.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
