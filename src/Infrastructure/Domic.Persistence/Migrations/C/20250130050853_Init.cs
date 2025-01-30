using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domic.Persistence.Migrations.C
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumerEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfRetry = table.Column<int>(type: "int", nullable: false),
                    CreatedAt_EnglishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt_PersianDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumerEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsDeliveries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LineNumber = table.Column<long>(type: "bigint", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SendDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    DeliveryDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SmsDeliveries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsDeliveries_Id_IsDeleted",
                table: "SmsDeliveries",
                columns: new[] { "Id", "IsDeleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerEvents");

            migrationBuilder.DropTable(
                name: "SmsDeliveries");
        }
    }
}
