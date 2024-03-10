using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_FOREGET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    mode = table.Column<int>(type: "int", nullable: false),
                    movementType = table.Column<int>(type: "int", nullable: false),
                    incoterms = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false),
                    citiy = table.Column<string>(type: "longtext", nullable: false),
                    packageType = table.Column<int>(type: "int", nullable: false),
                    unitFirst = table.Column<int>(type: "int", nullable: false),
                    secondUnit = table.Column<int>(type: "int", nullable: false),
                    currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    HashPassword = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
