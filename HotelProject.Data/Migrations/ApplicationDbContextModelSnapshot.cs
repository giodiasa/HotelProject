﻿// <auto-generated />
using System;
using HotelProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelProject.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelProject.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("HotelProject.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Nikoloz",
                            LastName = "Chkhartishvili",
                            PersonalNumber = "01024085083",
                            PhoneNumber = "555337681"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Khatia",
                            LastName = "Burduli",
                            PersonalNumber = "01024082203",
                            PhoneNumber = "579057747"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Erekle",
                            LastName = "Davitashvili",
                            PersonalNumber = "12345678947",
                            PhoneNumber = "571058998"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Dali",
                            LastName = "Goderdzishvili",
                            PersonalNumber = "87005633698",
                            PhoneNumber = "555887469"
                        });
                });

            modelBuilder.Entity("HotelProject.Models.GuestReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ReservationId");

                    b.ToTable("GuestReservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GuestId = 1,
                            ReservationId = 1
                        },
                        new
                        {
                            Id = 2,
                            GuestId = 2,
                            ReservationId = 1
                        },
                        new
                        {
                            Id = 3,
                            GuestId = 3,
                            ReservationId = 2
                        },
                        new
                        {
                            Id = 4,
                            GuestId = 4,
                            ReservationId = 3
                        });
                });

            modelBuilder.Entity("HotelProject.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhysicalAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "თბილისი",
                            Country = "საქართველო",
                            Name = "პირველი სასტუმრო",
                            PhysicalAddress = "რუსთაველის 4",
                            Rating = 10.0
                        },
                        new
                        {
                            Id = 2,
                            City = "თბილისი",
                            Country = "საქართველო",
                            Name = "მეორე სასტუმრო",
                            PhysicalAddress = "პეკინის 13",
                            Rating = 8.0
                        },
                        new
                        {
                            Id = 3,
                            City = "ბათუმი",
                            Country = "საქართველო",
                            Name = "მესამე სასტუმრო",
                            PhysicalAddress = "გამსახურდიას 12",
                            Rating = 7.7000000000000002
                        });
                });

            modelBuilder.Entity("HotelProject.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "გიორგი",
                            HotelId = 1,
                            LastName = "გიორგაძე"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "თამაზი",
                            HotelId = 2,
                            LastName = "გოდერძიშვილი"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "გოირგი",
                            HotelId = 3,
                            LastName = "გუჯარელიძე"
                        });
                });

            modelBuilder.Entity("HotelProject.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckInDate = new DateTime(2024, 4, 26, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6382),
                            CheckOutDate = new DateTime(2024, 5, 6, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6451)
                        },
                        new
                        {
                            Id = 2,
                            CheckInDate = new DateTime(2024, 4, 26, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6456),
                            CheckOutDate = new DateTime(2024, 5, 26, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6458)
                        },
                        new
                        {
                            Id = 3,
                            CheckInDate = new DateTime(2024, 4, 26, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6463),
                            CheckOutDate = new DateTime(2024, 5, 16, 0, 53, 3, 146, DateTimeKind.Local).AddTicks(6464)
                        });
                });

            modelBuilder.Entity("HotelProject.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "A-100"
                        },
                        new
                        {
                            Id = 2,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "A-200"
                        },
                        new
                        {
                            Id = 3,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "A-300"
                        },
                        new
                        {
                            Id = 4,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "B-100"
                        },
                        new
                        {
                            Id = 5,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "B-200"
                        },
                        new
                        {
                            Id = 6,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "B-300"
                        },
                        new
                        {
                            Id = 7,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "C-100"
                        },
                        new
                        {
                            Id = 8,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "C-200"
                        },
                        new
                        {
                            Id = 9,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "C-300"
                        },
                        new
                        {
                            Id = 10,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "100"
                        },
                        new
                        {
                            Id = 11,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "101"
                        },
                        new
                        {
                            Id = 12,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "102"
                        },
                        new
                        {
                            Id = 13,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "200"
                        },
                        new
                        {
                            Id = 14,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "201"
                        },
                        new
                        {
                            Id = 15,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "202"
                        },
                        new
                        {
                            Id = 16,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "300"
                        },
                        new
                        {
                            Id = 17,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "301"
                        },
                        new
                        {
                            Id = 18,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "302"
                        },
                        new
                        {
                            Id = 19,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "A-10"
                        },
                        new
                        {
                            Id = 20,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "A-20"
                        },
                        new
                        {
                            Id = 21,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "A-30"
                        },
                        new
                        {
                            Id = 22,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "B-10"
                        },
                        new
                        {
                            Id = 23,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "B-20"
                        },
                        new
                        {
                            Id = 24,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "B-30"
                        },
                        new
                        {
                            Id = 25,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "C-10"
                        },
                        new
                        {
                            Id = 26,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "C-20"
                        },
                        new
                        {
                            Id = 27,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "C-30"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f14530f8-2b5f-4983-90e1-a82660947f93",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "01f1e33f-e7dd-4732-8833-bc98547d76ee",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HotelProject.Models.GuestReservation", b =>
                {
                    b.HasOne("HotelProject.Models.Guest", "Guest")
                        .WithMany("GuestReservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelProject.Models.Reservation", "Reservation")
                        .WithMany("GuestReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelProject.Models.Manager", b =>
                {
                    b.HasOne("HotelProject.Models.Hotel", "Hotel")
                        .WithOne("Manager")
                        .HasForeignKey("HotelProject.Models.Manager", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelProject.Models.Room", b =>
                {
                    b.HasOne("HotelProject.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HotelProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HotelProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HotelProject.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HotelProject.Models.Guest", b =>
                {
                    b.Navigation("GuestReservations");
                });

            modelBuilder.Entity("HotelProject.Models.Hotel", b =>
                {
                    b.Navigation("Manager");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelProject.Models.Reservation", b =>
                {
                    b.Navigation("GuestReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
