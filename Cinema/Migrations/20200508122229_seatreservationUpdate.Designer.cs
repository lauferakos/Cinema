﻿// <auto-generated />
using System;
using Cinema.DAL.EfDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20200508122229_seatreservationUpdate")]
    partial class seatreservationUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbFilm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "asd",
                            Director = "asd",
                            Rating = 5,
                            Title = "aaa"
                        },
                        new
                        {
                            Id = 2,
                            Description = "asd",
                            Director = "asd",
                            Rating = 3,
                            Title = "bb"
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProjectionId")
                        .HasColumnType("int");

                    b.Property<int>("ReservedSeats")
                        .HasColumnType("int");

                    b.Property<int>("ViewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectionId");

                    b.HasIndex("ViewerId");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 1000,
                            ProjectionId = 1,
                            ReservedSeats = 1,
                            ViewerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Price = 2000,
                            ProjectionId = 1,
                            ReservedSeats = 2,
                            ViewerId = 1
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbProjection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("RoomId");

                    b.ToTable("projections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FilmId = 1,
                            RoomId = 2,
                            Start = new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            FilmId = 1,
                            RoomId = 1,
                            Start = new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 30
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 30
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbSeat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Column = 1,
                            RoomId = 1,
                            Row = 1
                        },
                        new
                        {
                            Id = 2,
                            Column = 1,
                            RoomId = 2,
                            Row = 1
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbSeatReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Column")
                        .HasColumnType("int");

                    b.Property<int>("ProjectionId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("ViewerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbViewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("viewers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ASD",
                            PassWord = "asd"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASD2",
                            PassWord = "asdasd"
                        });
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbOrder", b =>
                {
                    b.HasOne("Cinema.DAL.EfDbContext.DbProjection", "Projection")
                        .WithMany()
                        .HasForeignKey("ProjectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.DAL.EfDbContext.DbViewer", "Viewer")
                        .WithMany()
                        .HasForeignKey("ViewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbProjection", b =>
                {
                    b.HasOne("Cinema.DAL.EfDbContext.DbFilm", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.DAL.EfDbContext.DbRoom", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cinema.DAL.EfDbContext.DbSeat", b =>
                {
                    b.HasOne("Cinema.DAL.EfDbContext.DbRoom", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
