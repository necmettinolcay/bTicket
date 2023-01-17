using System;
using System.Collections.Generic;
using BusTicket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusTicket.Data.Data
{
    public partial class BticketContext : DbContext
    {
        public BticketContext()
        {
        }

        public BticketContext(DbContextOptions<BticketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Expedition> Expeditions { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Point> Points { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ExpeditionType> ExpeditionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.IdBus);

                entity.ToTable("Bus");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.BusType).HasMaxLength(50);

                entity.Property(e => e.Plate).HasMaxLength(50);
            });

            modelBuilder.Entity<Expedition>(entity =>
            {
                entity.HasKey(e => e.IdExpedition);

                entity.ToTable("Expedition");

                entity.Property(e => e.ExpectedTravelTime).HasMaxLength(50);

                entity.Property(e => e.TravelDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPassenger);

                entity.ToTable("Passenger");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.PassengerIdentity).HasMaxLength(50);

                entity.Property(e => e.PassengerName).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Point>(entity =>
            {
                entity.HasKey(e => e.IdPoint);

                entity.ToTable("Point");

                entity.Property(e => e.PointName).HasMaxLength(50);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.IdTicket);

                entity.ToTable("Ticket");

                entity.Property(e => e.Pnr).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdCompany);

                entity.ToTable("Company");

                entity.Property(e => e.CompanyName).HasMaxLength(50);
            });

            modelBuilder.Entity<ExpeditionType>(entity =>
            {
                entity.HasKey(e => e.IdExpeditionType);

                entity.ToTable("ExpeditionType");

                entity.Property(e => e.ExpeditionTypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
