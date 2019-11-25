using Microsoft.EntityFrameworkCore.Migrations;

namespace AirplaneTicketService.Migrations
{
    public partial class dd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Plane_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plane",
                table: "Plane");

            migrationBuilder.RenameTable(
                name: "Plane",
                newName: "Planes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "Plane");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plane",
                table: "Plane",
                column: "PlaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Plane_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Plane",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
