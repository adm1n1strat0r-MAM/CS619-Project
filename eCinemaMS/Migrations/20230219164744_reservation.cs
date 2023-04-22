using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinemaMS.Migrations
{
    public partial class reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "reservations");

            migrationBuilder.AddColumn<int>(
                name: "cost",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "qty",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "subtotal",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "qty",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "reservations");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
