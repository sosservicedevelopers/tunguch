using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries");

            migrationBuilder.AlterColumn<int>(
                name: "ListOfCinematographyCertificatesId",
                table: "CinemaCountries",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries",
                column: "ListOfCinematographyCertificatesId",
                principalTable: "ListOfCinematographyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries");

            migrationBuilder.AlterColumn<int>(
                name: "ListOfCinematographyCertificatesId",
                table: "CinemaCountries",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries",
                column: "ListOfCinematographyCertificatesId",
                principalTable: "ListOfCinematographyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
