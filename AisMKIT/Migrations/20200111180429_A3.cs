using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries");

            migrationBuilder.AlterColumn<int>(
                name: "ListOfCinematographyCertificatesId",
                table: "CinemaCountries",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries",
                column: "ListOfCinematographyCertificatesId",
                principalTable: "ListOfCinematographyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                table: "CinemaCountries",
                column: "ListOfCinematographyCertificatesId",
                principalTable: "ListOfCinematographyCertificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
