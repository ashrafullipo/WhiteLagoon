using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Use a fixed date instead of DateTime.Now
            var seedDate = new DateTime(2024, 01, 01);

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Description = "A luxurious villa featuring a private pool, ocean view, and premium amenities.",
                    Price = 200.0,
                    sqft = 550,
                    Occupancy = 4,
                    ImageUrl = "/images/villa1.jpg",
                    CreatedDate = seedDate
                },
                new Villa
                {
                    Id = 2,
                    Name = "Beachfront Paradise",
                    Description = "A modern beachfront villa with stunning sea views and direct beach access.",
                    Price = 300.0,
                    sqft = 700,
                    Occupancy = 6,
                    ImageUrl = "/images/villa2.jpg",
                    CreatedDate = seedDate
                },
                new Villa
                {
                    Id = 3,
                    Name = "Mountain Retreat",
                    Description = "A peaceful villa in the mountains with panoramic views and fresh air.",
                    Price = 180.0,
                    sqft = 480,
                    Occupancy = 3,
                    ImageUrl = "/images/villa3.jpg",
                    CreatedDate = seedDate
                },
                new Villa
                {
                    Id = 4,
                    Name = "City Deluxe Suite",
                    Description = "An elegant villa located in the city center with modern interiors and rooftop access.",
                    Price = 250.0,
                    sqft = 600,
                    Occupancy = 4,
                    ImageUrl = "/images/villa4.jpg",
                    CreatedDate = seedDate
                },
                new Villa
                {
                    Id = 5,
                    Name = "Desert Oasis",
                    Description = "A beautifully designed villa in a desert setting with private spa and pool.",
                    Price = 220.0,
                    sqft = 520,
                    Occupancy = 4,
                    ImageUrl = "/images/villa5.jpg",
                    CreatedDate = seedDate
                },
                new Villa
                {
                    Id = 6,
                    Name = "Lakeview Escape",
                    Description = "A tranquil lakeside villa perfect for relaxation and fishing enthusiasts.",
                    Price = 190.0,
                    sqft = 500,
                    Occupancy = 4,
                    ImageUrl = "/images/villa6.jpg",
                    CreatedDate = seedDate
                }
            );
            modelBuilder.Entity<VillaNumber>().HasData(
    new VillaNumber
    {
        Villa_Number = 101,
        VillaId = 1,
        Special_Details = "Pool facing room"
    },
    new VillaNumber
    {
        Villa_Number = 102,
        VillaId = 2,
        Special_Details = "Beach access, Two Queen beds"
    },
    new VillaNumber
    {
        Villa_Number = 103,
        VillaId = 1,
        Special_Details = "Garden view, King bed"
    },
    new VillaNumber
    {
        Villa_Number = 104,
        VillaId = 2,
        Special_Details = "Sea view, Balcony"
    },
    new VillaNumber
    {
        Villa_Number = 201,
        VillaId = 3,
        Special_Details = "Mountain view, Fireplace"
    },
    new VillaNumber
    {
        Villa_Number = 202,
        VillaId = 4,
        Special_Details = "City center, Rooftop access"
    },
    new VillaNumber
    {
        Villa_Number = 203,
        VillaId = 3,
        Special_Details = "Private terrace, King bed"
    },
    new VillaNumber
    {
        Villa_Number = 204,
        VillaId = 4,
        Special_Details = "Modern interior, Gym access"
    },
    new VillaNumber
    {
        Villa_Number = 301,
        VillaId = 5,
        Special_Details = "Desert view, Private spa"
    },
    new VillaNumber
    {
        Villa_Number = 302,
        VillaId = 6,
        Special_Details = "Lake view, Fishing deck"
    }
);

        }
    }
}
