using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class initialk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Driver = table.Column<int>(type: "int", nullable: false),
                    ID_Passenger = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Ride = table.Column<int>(type: "int", nullable: false),
                    ID_Passenger = table.Column<int>(type: "int", nullable: false),
                    Statuts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RideDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Driver = table.Column<int>(type: "int", nullable: false),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrival = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicense = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackDTO");

            migrationBuilder.DropTable(
                name: "ReservationDTO");

            migrationBuilder.DropTable(
                name: "RideDTO");

            migrationBuilder.DropTable(
                name: "UserDTO");
        }
    }
}
