using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRNCars.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserGuidEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "UploadDate", "UserGuid" },
                values: new object[] { new DateTime(2024, 5, 17, 3, 34, 25, 913, DateTimeKind.Local).AddTicks(7341), new Guid("d40787cd-fd04-4e6f-966c-f8ab88540c39") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 14, 23, 24, 35, 92, DateTimeKind.Local).AddTicks(504));
        }
    }
}
