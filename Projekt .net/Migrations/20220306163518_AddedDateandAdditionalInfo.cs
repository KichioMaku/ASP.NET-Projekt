using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_.net.Migrations
{
    public partial class AddedDateandAdditionalInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");
        }
    }
}
