using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.DAL.EfDbContext
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<DbFilm> Films { get; set; }
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbProjection> Projections { get; set; }
        public DbSet<DbRoom> Rooms { get; set; }
        public DbSet<DbSeat> Seats { get; set; }
        public DbSet<DbViewer> Viewers { get; set; }

        public DbSet<DbSeatReservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbFilm>()
           .ToTable("films");
            modelBuilder.Entity<DbFilm>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<DbOrder>()
           .ToTable("orders");
            modelBuilder.Entity<DbOrder>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<DbProjection>()
           .ToTable("projections");
            modelBuilder.Entity<DbProjection>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<DbRoom>()
           .ToTable("rooms");
            modelBuilder.Entity<DbRoom>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<DbSeat>()
           .ToTable("seats");
            modelBuilder.Entity<DbSeat>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<DbSeat>()
         .HasOne(s => s.Room)
         .WithMany(r => r.Seats)
         .HasForeignKey(s => s.RoomId);

            modelBuilder.Entity<DbSeatReservation>()
         .ToTable("reservations");
            modelBuilder.Entity<DbSeatReservation>()
                .HasKey(sr => sr.Id);

            modelBuilder.Entity<DbViewer>()
           .ToTable("viewers");
            modelBuilder.Entity<DbViewer>()
                .HasKey(v => v.Id);
            modelBuilder.Entity<DbFilm>()
             .HasData(new[]
             {
                new DbFilm() { Id = 1, Title="aaa", Director ="asd", Description="asd", Rating = 5},
                new DbFilm() { Id = 2, Title="bb", Director ="asd", Description="asd", Rating = 3},
             });

            modelBuilder.Entity<DbOrder>()
             .HasData(new[]
             {
                new DbOrder() { Id = 1, ProjectionId=1, Price= 1000, ReservedSeats = 1,ViewerId = 1},
                new DbOrder() { Id = 2, ProjectionId= 1, Price = 2000, ReservedSeats = 2, ViewerId = 1},
             });

            modelBuilder.Entity<DbProjection>()
             .HasData(new[]
             {
                new DbProjection() { Id = 1, FilmId=1, RoomId= 2, Start = new DateTime(2020,12,10)},
                new DbProjection() { Id = 2, FilmId= 1, RoomId = 1, Start = new DateTime(2020,12,11)},
             });

            modelBuilder.Entity<DbRoom>()
           .HasData(new[]
           {
                new DbRoom() { Id = 1, Capacity = 30},
                new DbRoom() { Id = 2, Capacity = 30},
           });
            modelBuilder.Entity<DbSeat>()
            .HasData(new[]
            {
                new DbSeat() { Id = 1, Row = 1 ,Column=1, RoomId = 1},
                new DbSeat() { Id = 2, Row = 1 ,Column=1, RoomId = 2},
            });
            modelBuilder.Entity<DbViewer>()
            .HasData(new[]
            {
                new DbViewer() { Id = 1, Name = "ASD" ,PassWord="asd"},
                new DbViewer() { Id = 2, Name = "ASD2" ,PassWord="asdasd"},
            });

        }

    }
}
