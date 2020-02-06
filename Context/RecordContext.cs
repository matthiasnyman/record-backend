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
    public DbSet<ProductsInGenre> ProductsInGenre { get; set; } //Tabellen 
    public DbSet<Genre> Genres { get; set; } //Tabellen

    protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite("Data Source=recorddb.db");


    // Only Data under this line.... 
    protected override void OnModelCreating(ModelBuilder ModelBuilder) {

      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 1,
        Artist = "ABBA",
        Album = "ABBA the album",
        Image = "https://www.bengans.se/bilder/artiklar/liten/2572243_S.jpg",
        Price = 120.00m,
        Sale = 0.1m,
        Info = "Skivan är ok..",
        Recommended = false
      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 2,
        Artist = "Kent",
        Album = "Röd",
        Image = "https://www.bengans.se/bilder/artiklar/liten/1689651_S.jpg",
        Price = 200.00m,
        Sale = 0,
        Info = "Skivan är fantastisk!",
        Recommended = true
      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 3,
        Artist = "Håkan Hellström",
        Album = "2 steg från paridise",
        Image = "https://www.bengans.se/bilder/artiklar/liten/619835_S.jpg",
        Price = 130.00m,
        Sale = 0,
        Info = "Håkan bråkan!",
        Recommended = true

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 4,
        Artist = "Fleetwood mac",
        Album = "Boston vol:2",
        Image = "https://www.bengans.se/bilder/artiklar/liten/3601538_S.jpg",
        Price = 200.00m,
        Sale = 0,
        Info = "Simon gillat!",
        Recommended = false

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 5,
        Artist = "Bruse Springstin",
        Album = "Bourn in the USA",
        Image = "https://www.bengans.se/bilder/artiklar/liten/1533609_S.jpg",
        Price = 20.00m,
        Sale = 0,
        Info = "brusse!",
        Recommended = true

      });
      ModelBuilder.Entity<Record>().HasData(new Record{ 
        Id = 6,
        Artist = "Kiss",
        Album = "Hot in the shade",
        Image = "https://www.bengans.se/bilder/artiklar/liten/3496044_S.jpg",
        Price = 2000.00m,
        Sale = 0,
        Info = "brusse!",
        Recommended = true

      });


      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 1,
        Name = "Pop",
      });
      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 2,
        Name = "Rock",
      });
      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 3,
        Name = "Blues",
      });
      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 4,
        Name = "Hiphop",
      });
      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 5,
        Name = "Raggae",
      });
      ModelBuilder.Entity<Genre>().HasData(new Genre{ 
        Id = 6,
        Name = "Punk",
      });




      ModelBuilder.Entity<ProductsInGenre>().HasData(new ProductsInGenre{ 
        Id = 1,
        RecordId = 1,
        GenreId = 2
      });
      ModelBuilder.Entity<ProductsInGenre>().HasData(new ProductsInGenre{ 
        Id = 2,
        RecordId = 2,
        GenreId = 1
      });
      ModelBuilder.Entity<ProductsInGenre>().HasData(new ProductsInGenre{ 
        Id = 3,
        RecordId = 3,
        GenreId = 1
      });
      ModelBuilder.Entity<ProductsInGenre>().HasData(new ProductsInGenre{ 
        Id = 4,
        RecordId = 4,
        GenreId = 1
      });
      ModelBuilder.Entity<ProductsInGenre>().HasData(new ProductsInGenre{ 
        Id = 5,
        RecordId = 4,
        GenreId = 3
      });


      ModelBuilder.Entity<Order>().HasData(new Order{ 
        Id = 1,
        UserId = 1

      });
      ModelBuilder.Entity<Order>().HasData(new Order{ 
        Id = 2,
        UserId = 2

      });


      ModelBuilder.Entity<Cart>().HasData(new Cart{ 
        Id = 1,
        OrderId = 1,
        RecordId = 1,

      });
      ModelBuilder.Entity<Cart>().HasData(new Cart{ 
        Id = 2,
        OrderId = 1,
        RecordId = 2,

      });
      ModelBuilder.Entity<Cart>().HasData(new Cart{ 
        Id = 3,
        OrderId = 1,
        RecordId = 3,

      });

      
      ModelBuilder.Entity<User>().HasData(new User{ 
        Id = 1,
        FirstName = "Matthias",
        LastName = "Nyman",
        Email = "att@att.se",
      });
      ModelBuilder.Entity<User>().HasData(new User{ 
        Id = 2,
        FirstName = "Kalle",
        LastName = "Nyman",
        Email = "Kalle@attd.se",
      });



    }

  }
}
