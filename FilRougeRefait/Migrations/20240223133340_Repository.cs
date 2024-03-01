using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class Repository : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackDTO");

            migrationBuilder.DropTable(
                name: "ReservationDTO");

            migrationBuilder.DropTable(
                name: "RideDTO");

            migrationBuilder.DropTable(
                name: "UserDTO");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicence = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Driver = table.Column<int>(type: "int", nullable: false),
                    Id_Passenger = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UserID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_User_Id_Driver",
                        column: x => x.Id_Driver,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_User_Id_Passenger",
                        column: x => x.Id_Passenger,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedback_User_UserID1",
                        column: x => x.UserID1,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ride",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Rider = table.Column<int>(type: "int", nullable: false),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrival = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPlaces = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ride", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ride_User_DriverID",
                        column: x => x.DriverID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Ride = table.Column<int>(type: "int", nullable: false),
                    Id_Passenger = table.Column<int>(type: "int", nullable: false),
                    Statuts = table.Column<int>(type: "int", nullable: true),
                    TravelID = table.Column<int>(type: "int", nullable: true),
                    PassengerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Ride_Id_Ride",
                        column: x => x.Id_Ride,
                        principalTable: "Ride",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Ride_TravelID",
                        column: x => x.TravelID,
                        principalTable: "Ride",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservation_User_Id_Passenger",
                        column: x => x.Id_Passenger,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_User_PassengerID",
                        column: x => x.PassengerID,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Id_Driver",
                table: "Feedback",
                column: "Id_Driver");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Id_Passenger",
                table: "Feedback",
                column: "Id_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserID",
                table: "Feedback",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserID1",
                table: "Feedback",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Id_Passenger",
                table: "Reservation",
                column: "Id_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Id_Ride",
                table: "Reservation",
                column: "Id_Ride");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_PassengerID",
                table: "Reservation",
                column: "PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_TravelID",
                table: "Reservation",
                column: "TravelID");

            migrationBuilder.CreateIndex(
                name: "IX_Ride_DriverID",
                table: "Ride",
                column: "DriverID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Ride");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "RideDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrival = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Driver = table.Column<int>(type: "int", nullable: false),
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
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicense = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FeedbackDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Driver = table.Column<int>(type: "int", nullable: false),
                    ID_Passenger = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FeedbackDTO_UserDTO_ID_Driver",
                        column: x => x.ID_Driver,
                        principalTable: "UserDTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedbackDTO_UserDTO_ID_Passenger",
                        column: x => x.ID_Passenger,
                        principalTable: "UserDTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationDTO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Passenger = table.Column<int>(type: "int", nullable: false),
                    ID_Ride = table.Column<int>(type: "int", nullable: false),
                    Statuts = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDTO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReservationDTO_RideDTO_ID_Ride",
                        column: x => x.ID_Ride,
                        principalTable: "RideDTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationDTO_UserDTO_ID_Passenger",
                        column: x => x.ID_Passenger,
                        principalTable: "UserDTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDTO_ID_Driver",
                table: "FeedbackDTO",
                column: "ID_Driver");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDTO_ID_Passenger",
                table: "FeedbackDTO",
                column: "ID_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_ID_Passenger",
                table: "ReservationDTO",
                column: "ID_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_ID_Ride",
                table: "ReservationDTO",
                column: "ID_Ride");
        }
    }
}
