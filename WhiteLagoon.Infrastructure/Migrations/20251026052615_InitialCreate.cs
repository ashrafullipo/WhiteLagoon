using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    Special_Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "UpdatedDate", "sqft" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa featuring a private pool, ocean view, and premium amenities.", "/images/villa1.jpg", "Royal Villa", 4, 200.0, null, 550 },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A modern beachfront villa with stunning sea views and direct beach access.", "/images/villa2.jpg", "Beachfront Paradise", 6, 300.0, null, 700 },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A peaceful villa in the mountains with panoramic views and fresh air.", "/images/villa3.jpg", "Mountain Retreat", 3, 180.0, null, 480 },
                    { 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An elegant villa located in the city center with modern interiors and rooftop access.", "/images/villa4.jpg", "City Deluxe Suite", 4, 250.0, null, 600 },
                    { 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beautifully designed villa in a desert setting with private spa and pool.", "/images/villa5.jpg", "Desert Oasis", 4, 220.0, null, 520 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A tranquil lakeside villa perfect for relaxation and fishing enthusiasts.", "/images/villa6.jpg", "Lakeview Escape", 4, 190.0, null, 500 }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "Special_Details", "VillaId" },
                values: new object[,]
                {
                    { 101, "Pool facing room", 1 },
                    { 102, "Beach access, Two Queen beds", 2 },
                    { 103, "Garden view, King bed", 1 },
                    { 104, "Sea view, Balcony", 2 },
                    { 201, "Mountain view, Fireplace", 3 },
                    { 202, "City center, Rooftop access", 4 },
                    { 203, "Private terrace, King bed", 3 },
                    { 204, "Modern interior, Gym access", 4 },
                    { 301, "Desert view, Private spa", 5 },
                    { 302, "Lake view, Fishing deck", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
