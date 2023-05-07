using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDemo.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "uInformation",
                table: "wsAccount",
                newName: "aInformation");

            migrationBuilder.RenameColumn(
                name: "uEmail",
                table: "wsAccount",
                newName: "aEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "aInformation",
                table: "wsAccount",
                newName: "uInformation");

            migrationBuilder.RenameColumn(
                name: "aEmail",
                table: "wsAccount",
                newName: "uEmail");
        }
    }
}
