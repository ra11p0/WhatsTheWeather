using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhatsTheWeather.Migrations
{
    public partial class AddedCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "LocationVisits");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "LocationVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coords",
                columns: table => new
                {
                    CoordsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coords", x => x.CoordsId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Coords_CoordsId",
                        column: x => x.CoordsId,
                        principalTable: "Coords",
                        principalColumn: "CoordsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationVisits_CityId",
                table: "LocationVisits",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CoordsId",
                table: "City",
                column: "CoordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisits_City_CityId",
                table: "LocationVisits",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisits_City_CityId",
                table: "LocationVisits");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Coords");

            migrationBuilder.DropIndex(
                name: "IX_LocationVisits_CityId",
                table: "LocationVisits");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "LocationVisits");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LocationVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
