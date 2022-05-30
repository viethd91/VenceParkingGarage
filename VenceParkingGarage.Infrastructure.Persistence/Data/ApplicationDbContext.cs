using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;
using VenceParkingGarage.Core.Domain;
using VenceParkingGarage.Core.Domain.Entities;

namespace VenceParkingGarage.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<ParkingLevel> ParkingLevels { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<ParkingSlotVehicle> ParkingSlotVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
