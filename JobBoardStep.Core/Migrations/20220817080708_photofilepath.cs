using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardStep.Core.Migrations
{
    public partial class photofilepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFilePath",
                table: "Users",
                type: "longtext",
                nullable: true
                ).Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFilePath",
                table: "Users"
                );
        }
    }
}
