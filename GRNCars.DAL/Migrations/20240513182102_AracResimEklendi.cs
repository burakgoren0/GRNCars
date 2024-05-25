using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRNCars.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AracResimEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Vehicles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 13, 21, 21, 1, 297, DateTimeKind.Local).AddTicks(4712));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 8, 2, 31, 52, 907, DateTimeKind.Local).AddTicks(8169));
        }
    }
}
