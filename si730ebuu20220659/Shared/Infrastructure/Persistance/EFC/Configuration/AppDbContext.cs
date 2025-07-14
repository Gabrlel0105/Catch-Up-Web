using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebuu20220659.Inventory.Domain.Model.Aggregates;
using si730ebuu20220659.Inventory.Domain.Model.ValueObjects;
using si730ebuu20220659.Observability.Domain.Model.Aggregates;

namespace si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration;
using si730ebuu20220659.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;
public class AppDbContext : DbContext {
    
    public DbSet<ThingState> ThingStates { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Thing>().ToTable("Thing");
        builder.Entity<Thing>().HasKey(e => e.Id);
        builder.Entity<Thing>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Thing>().Property(e=> e.Model).IsRequired();

        builder.Entity<Thing>().OwnsOne<SerialNumber>(serial => serial.SerialNumberValObj, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        
        builder.Entity<Thing>().Property(e=> e.OperationModeEnum).IsRequired();

        builder.Entity<Thing>().Property(e=> e.MaximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(e=> e.MinimumHumidityThreshold).IsRequired();
        
        
        //
        builder.Entity<ThingState>().ToTable("thing_states");
        builder.Entity<ThingState>().HasKey(e => e.Id);
        builder.Entity<ThingState>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ThingState>().OwnsOne<SerialNumber>(serial => serial.ThingSerialNumber, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        builder.Entity<ThingState>().Property(e => e.CurrentOperationMode).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CurrentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CurrentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CollectedAt).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();

    }

}