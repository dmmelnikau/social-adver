using Microsoft.EntityFrameworkCore.Migrations;

namespace MelnikauDV.Migrations
{
    public partial class likesdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDislikes",
                table: "AdvMark");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "AdvMark");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislikes",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDislikes",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislikes",
                table: "AdvMark",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "AdvMark",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
