using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nivello.Infrastructure.Data.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class CreatedIsdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemAdmin",
                keyColumn: "Id",
                keyValue: new Guid("23314ddc-f981-42ca-aaaf-8579d55c647b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "SystemAdmin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "AuctionsBid",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "SystemAdmin",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDelete", "Name", "Password" },
                values: new object[] { new Guid("51c12eae-3f9a-4dac-a663-cfaa9056c3ce"), new DateTime(2022, 4, 14, 13, 58, 45, 958, DateTimeKind.Local).AddTicks(7179), "admin@nivello.com", false, "Admin", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemAdmin",
                keyColumn: "Id",
                keyValue: new Guid("51c12eae-3f9a-4dac-a663-cfaa9056c3ce"));

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "SystemAdmin");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AuctionsBid");

            migrationBuilder.InsertData(
                table: "SystemAdmin",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password" },
                values: new object[] { new Guid("23314ddc-f981-42ca-aaaf-8579d55c647b"), new DateTime(2022, 4, 14, 11, 46, 3, 83, DateTimeKind.Local).AddTicks(8714), "admin@nivello.com", "Admin", "123456" });
        }
    }
}
