using Microsoft.EntityFrameworkCore;
using pcAPI.Models;

namespace pcAPI.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PC>().HasData([
            new PC
            {
                Id = 1,
                Name = "Home Server Alpha",
                Weight = 8.5,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                Stock = 8
            },
            new PC
            {
                Id = 2,
                Name = "Budget Gamer V2",
                Weight = 6.0,
                Warranty = 12,
                CreatedAt = new DateTime(2026, 2, 28, 14, 45, 0),
                Stock = 20
            },
            new PC
            {
                Id = 3,
                Name = "Designer Mac-Killer",
                Weight = 5.5,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 5, 9, 30, 0),
                Stock = 4
            }
        ]);

        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType
            {
                Id = 1,
                Abbreviation = "MOBO",
                Name = "Motherboard"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "SSD",
                Name = "Solid State Drive"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "PSU",
                Name = "Power Supply Unit"
            }
        ]);

        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "ASUS",
                FullName = "ASUSTeK Computer Inc.",
                FoundationDate = new DateOnly(1989, 4, 2)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "SAMSUNG",
                FullName = "Samsung Electronics",
                FoundationDate = new DateOnly(1969, 1, 13)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "CORSAIR",
                FullName = "Corsair Gaming, Inc.",
                FoundationDate = new DateOnly(1994, 1, 1)
            }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component
            {
                Code = "MOB0000001",
                Name = "ROG Strix X670E",
                Description = "Premium gaming motherboard with WiFi 6E",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "SSD0000001",
                Name = "990 PRO 2TB",
                Description = "Ultra-fast PCIe 4.0 NVMe drive",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "PSU0000001",
                Name = "RM850x",
                Description = "850W 80+ Gold Fully Modular",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        ]);

        modelBuilder.Entity<PCComponent>().HasData([
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "MOB0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "SSD0000001",
                Amount = 2
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "PSU0000001",
                Amount = 1
            }
        ]);
    }
}