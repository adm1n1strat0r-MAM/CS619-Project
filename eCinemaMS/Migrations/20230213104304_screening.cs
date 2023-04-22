using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinemaMS.Migrations
{
    public partial class screening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "screenings");

            migrationBuilder.CreateIndex(
                name: "IX_screenings_MovieId",
                table: "screenings",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_screenings_Movies_MovieId",
                table: "screenings",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_screenings_Movies_MovieId",
                table: "screenings");

            migrationBuilder.DropIndex(
                name: "IX_screenings_MovieId",
                table: "screenings");

            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "screenings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
