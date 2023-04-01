using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Database
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", maxLength: 250, nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    actionId = table.Column<int>(type: "INTEGER", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Score = table.Column<int>(type: "INTEGER", maxLength: 250, nullable: false),
                    BusinessAchievements = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "Date", "PhotoPath", "UserId", "actionId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dummyPath", 1, 1 });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BusinessAchievements", "Email", "Name", "Password", "Score" },
                values: new object[] { 1, "000000", "support@cercopitechs.com", "Cercopitechs", "parola123", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
