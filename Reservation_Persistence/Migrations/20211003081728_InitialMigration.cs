using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation_Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TripId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReversationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "CityName", "CreationDate", "ImageUrl", "Name", "content", "price" },
                values: new object[] { new Guid("860764f2-d405-4142-86d1-efc7bb8c9672"), "hurghada", new DateTime(2021, 10, 3, 10, 17, 28, 126, DateTimeKind.Local).AddTicks(9514), null, "break trip", " Accepts HTML Format", 1000 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password" },
                values: new object[] { new Guid("d5a11f41-2e72-4b08-b02b-f0250f540654"), "mamdouh.koleap@gmail.com", "mamdouh123" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReversationId", "CreationDate", "CustomerName", "Notes", "ReservationDate", "ReservedBy", "TripId" },
                values: new object[] { new Guid("cc505b3b-d35f-4e74-935b-38b42271ec4a"), new DateTime(2021, 10, 3, 10, 17, 28, 129, DateTimeKind.Local).AddTicks(1467), "Ali Nadi Ali", "no notes", new DateTime(2021, 10, 3, 10, 17, 28, 129, DateTimeKind.Local).AddTicks(49), "mamdouh.koleap@gmail.com", new Guid("860764f2-d405-4142-86d1-efc7bb8c9672") });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                column: "TripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
