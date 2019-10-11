using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreWebApi.Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    userId = table.Column<string>(maxLength: 32, nullable: false),
                    userName = table.Column<string>(maxLength: 20, nullable: true),
                    email = table.Column<string>(maxLength: 30, nullable: true),
                    createTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_User");
        }
    }
}
