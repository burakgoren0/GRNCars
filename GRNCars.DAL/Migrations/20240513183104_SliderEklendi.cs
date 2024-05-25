using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GRNCars.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SliderEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Aciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Resim = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 13, 21, 31, 3, 513, DateTimeKind.Local).AddTicks(4574));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 5, 13, 21, 21, 1, 297, DateTimeKind.Local).AddTicks(4712));
        }
    }
}
