using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBoardApp.Migrations
{
    public partial class IncludePostedDateOnProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Available",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Posted",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Posted",
                table: "Product");
        }
    }
}
