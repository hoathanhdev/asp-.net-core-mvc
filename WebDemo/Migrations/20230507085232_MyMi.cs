using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebDemo.Migrations
{
    public partial class MyMi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "wsAccount",
                columns: table => new
                {
                    aID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aIsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    uInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wsAccount", x => x.aID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wsAccount");
        }
    }
}
