using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_.net.Migrations
{
    public partial class ReasonsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdditionalInfo",
                table: "Orders",
                newName: "ReturnReason");

            migrationBuilder.AddColumn<string>(
                name: "CancellationReason",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComplaintDecision",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ComplaintDecision",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReturnReason",
                table: "Orders",
                newName: "AdditionalInfo");
        }
    }
}
