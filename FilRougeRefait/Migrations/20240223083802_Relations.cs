using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoVoyageur.API.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_ID_Passenger",
                table: "ReservationDTO",
                column: "ID_Passenger");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationDTO_ID_Ride",
                table: "ReservationDTO",
                column: "ID_Ride");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDTO_ID_Driver",
                table: "FeedbackDTO",
                column: "ID_Driver");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackDTO_ID_Passenger",
                table: "FeedbackDTO",
                column: "ID_Passenger");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackDTO_UserDTO_ID_Driver",
                table: "FeedbackDTO",
                column: "ID_Driver",
                principalTable: "UserDTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedbackDTO_UserDTO_ID_Passenger",
                table: "FeedbackDTO",
                column: "ID_Passenger",
                principalTable: "UserDTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDTO_RideDTO_ID_Ride",
                table: "ReservationDTO",
                column: "ID_Ride",
                principalTable: "RideDTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDTO_UserDTO_ID_Passenger",
                table: "ReservationDTO",
                column: "ID_Passenger",
                principalTable: "UserDTO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackDTO_UserDTO_ID_Driver",
                table: "FeedbackDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedbackDTO_UserDTO_ID_Passenger",
                table: "FeedbackDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDTO_RideDTO_ID_Ride",
                table: "ReservationDTO");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDTO_UserDTO_ID_Passenger",
                table: "ReservationDTO");

            migrationBuilder.DropIndex(
                name: "IX_ReservationDTO_ID_Passenger",
                table: "ReservationDTO");

            migrationBuilder.DropIndex(
                name: "IX_ReservationDTO_ID_Ride",
                table: "ReservationDTO");

            migrationBuilder.DropIndex(
                name: "IX_FeedbackDTO_ID_Driver",
                table: "FeedbackDTO");

            migrationBuilder.DropIndex(
                name: "IX_FeedbackDTO_ID_Passenger",
                table: "FeedbackDTO");
        }
    }
}
