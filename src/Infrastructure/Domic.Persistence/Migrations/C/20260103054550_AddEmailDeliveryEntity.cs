using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domic.Persistence.Migrations.C
{
    /// <inheritdoc />
    public partial class AddEmailDeliveryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailDeliveries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<byte>(type: "tinyint", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDeliveries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailDeliveries_Id_IsDeleted",
                table: "EmailDeliveries",
                columns: new[] { "Id", "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailDeliveries");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
