using Management.Vehicles.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Vehicles.Infrastructure;

public class VehicleDBContext : DbContext
{
    public VehicleDBContext(DbContextOptions<VehicleDBContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Car>()
    //        .HasOne(p => p.VehicleType)
    //        .WithMany(b => b.Cars);
    //}


}
