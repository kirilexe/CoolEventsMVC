using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolEvents.Data.Migrations
{
    /// <inheritdoc />
    public partial class trip_destinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Trip");

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Trip",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DestinationId",
                table: "Trip",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Destination_DestinationId",
                table: "Trip",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Destination_DestinationId",
                table: "Trip");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropIndex(
                name: "IX_Trip_DestinationId",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Trip");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
