using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneTicketService.Migrations
{
    public partial class AddFlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneId = table.Column<int>(nullable: true),
                    ArriveAirport = table.Column<string>(nullable: true),
                    DepartureAirport = table.Column<string>(nullable: true),
                    DepartureGate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Planes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Planes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: true),
                    ArriveCountry = table.Column<string>(nullable: true),
                    ArriveCity = table.Column<string>(nullable: true),
                    DepartureCountry = table.Column<string>(nullable: true),
                    DepartureCity = table.Column<string>(nullable: true),
                    FirstPilot = table.Column<string>(nullable: true),
                    SecondPilot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FlightDetails_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightDetails_FlightId",
                table: "FlightDetails",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
