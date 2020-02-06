﻿// <auto-generated />
using System;
using EntityFrameworkUppgift.contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace record_backend.Migrations
{
    [DbContext(typeof(RecordStoreContexts))]
    partial class RecordStoreContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("record_backend.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("RecordId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            RecordId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            RecordId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 1,
                            RecordId = 3
                        });
                });

            modelBuilder.Entity("record_backend.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pop"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rock"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Blues"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hiphop"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Raggae"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Punk"
                        });
                });

            modelBuilder.Entity("record_backend.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("record_backend.Models.ProductsInGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("RecordId");

                    b.ToTable("ProductsInGenre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 2,
                            RecordId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 1,
                            RecordId = 2
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 1,
                            RecordId = 3
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 1,
                            RecordId = 4
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 3,
                            RecordId = 4
                        });
                });

            modelBuilder.Entity("record_backend.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("Recommended")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Sale")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "ABBA the album",
                            Artist = "ABBA",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/2572243_S.jpg",
                            Info = "Skivan är ok..",
                            Price = 120.00m,
                            Recommended = false,
                            Sale = 0.1m
                        },
                        new
                        {
                            Id = 2,
                            Album = "Röd",
                            Artist = "Kent",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/1689651_S.jpg",
                            Info = "Skivan är fantastisk!",
                            Price = 200.00m,
                            Recommended = true,
                            Sale = 0m
                        },
                        new
                        {
                            Id = 3,
                            Album = "2 steg från paridise",
                            Artist = "Håkan Hellström",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/619835_S.jpg",
                            Info = "Håkan bråkan!",
                            Price = 130.00m,
                            Recommended = true,
                            Sale = 0m
                        },
                        new
                        {
                            Id = 4,
                            Album = "Boston vol:2",
                            Artist = "Fleetwood mac",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/3601538_S.jpg",
                            Info = "Simon gillat!",
                            Price = 200.00m,
                            Recommended = false,
                            Sale = 0m
                        },
                        new
                        {
                            Id = 5,
                            Album = "Bourn in the USA",
                            Artist = "Bruse Springstin",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/1533609_S.jpg",
                            Info = "brusse!",
                            Price = 20.00m,
                            Recommended = true,
                            Sale = 0m
                        },
                        new
                        {
                            Id = 6,
                            Album = "Hot in the shade",
                            Artist = "Kiss",
                            Image = "https://www.bengans.se/bilder/artiklar/liten/3496044_S.jpg",
                            Info = "brusse!",
                            Price = 2000.00m,
                            Recommended = true,
                            Sale = 0m
                        });
                });

            modelBuilder.Entity("record_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "att@att.se",
                            FirstName = "Matthias",
                            LastName = "Nyman"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Kalle@attd.se",
                            FirstName = "Kalle",
                            LastName = "Nyman"
                        });
                });

            modelBuilder.Entity("record_backend.Models.Cart", b =>
                {
                    b.HasOne("record_backend.Models.Order", null)
                        .WithMany("Cart")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_backend.Models.Record", "Record")
                        .WithMany()
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_backend.Models.Order", b =>
                {
                    b.HasOne("record_backend.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("record_backend.Models.ProductsInGenre", b =>
                {
                    b.HasOne("record_backend.Models.Genre", "Genre")
                        .WithMany("ProductsInGenre")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("record_backend.Models.Record", "Record")
                        .WithMany("ProductsInGenre")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
