using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRNCars.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AnasayfaEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anasayfa",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 14, 23, 24, 35, 92, DateTimeKind.Local).AddTicks(504));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anasayfa",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 13, 21, 31, 3, 513, DateTimeKind.Local).AddTicks(4574));
        }
    }
}
