using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using VehicleCms.Persistence.Entities;
using VehicleCms.Persistence.Entities.Bases;

namespace VehicleCms.Persistence
{
    public class VehicleCmsContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VehicleCmsContext(DbContextOptions<VehicleCmsContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
#if DEBUG
            Database.EnsureCreated();
#endif
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(VehicleCmsContext)));
        }

        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            TrackChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void TrackChanges()
        {
            ChangeTracker.DetectChanges();

            var now = DateTimeOffset.UtcNow;
            var identityName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            foreach (var item in ChangeTracker.Entries<TrackableEntity>().Where(e => e.State == EntityState.Added))
            {
                item.Entity.CreatedAt = now;
                item.Entity.CreatedBy = identityName ?? "System";
            }

            foreach (var item in ChangeTracker.Entries<TrackableEntity>().Where(e => e.State == EntityState.Modified))
            {
                item.Entity.ModifiedAt = now;
                item.Entity.ModifiedBy = identityName ?? "System";
            }
        }
    }
}
