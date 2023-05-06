using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDemo.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wsUser",
                columns: table => new
                {
                    uID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uSex = table.Column<bool>(type: "bit", nullable: false),
                    uInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wsUser", x => x.uID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wsUser");
        }
    }
}
