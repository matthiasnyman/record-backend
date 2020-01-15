using record_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.contexts
{
  public class RecordStoreContexts : DbContext
  {
    public DbSet<User> Users { get; set; } //Tabellen User
    public DbSet<Record> Records { get; set; } //Tabellen Record
    public DbSet<Order> Orders { get; set; } //Tabellen Order
    public DbSet<Cart> Carts { get; set; } //Tabellen Cart 
    public DbSet<ProductGenre> ProductGenres { get; set; } //Tabellen 
    public DbSet<Genre> Genres { get; set; } //Tabellen

    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite("Data Source=recorddb.db");

    protected override void OnModelCreating(ModelBuilder ModelBuilder) {

      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 1,
        Artist = "ABBA",
        Album = "Greatest hits",
        Image = "/image1",
        Price = 120.00m,
        Sale = 0,
        Info = "Skivan är ok..",
      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 2,
        Artist = "Kent",
        Album = "Röd",
        Image = "'/image2",
        Price = 200.00m,
        Sale = 0,
        Info = "Skivan är fantastisk!"
      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 3,
        Artist = "Håkan Hellström",
        Album = "2 steg från paridise",
        Image = "'/image2",
        Price = 130.00m,
        Sale = 0,
        Info = "Håkan bråkan!",

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 4,
        Artist = "Fleetwood mac",
        Album = "The roumers",
        Image = "'/image2",
        Price = 200.00m,
        Sale = 0,
        Info = "Simon gillat!",

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 5,
        Artist = "Bruse Springstin",
        Album = "Bourn in the USA",
        Image = "'/image7",
        Price = 20.00m,
        Sale = 0,
        Info = "brusse!",

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 6,
        Artist = "Kiss",
        Album = "Dynasti",
        Image = "'/image7",
        Price = 2000.00m,
        Sale = 0,
        Info = "brusse!",

      });
      ModelBuilder.Entity<User>().HasData(new User{ 
        Id = 7,
        FirstName = "Matthias",
        LastName = "Nyman",
        Email = "att@att.se",
      });
      ModelBuilder.Entity<User>().HasData(new User{ 
        Id = 8,
        FirstName = "Kalle",
        LastName = "Nyman",
        Email = "Kalle@attd.se",
      });

    }

  }
}