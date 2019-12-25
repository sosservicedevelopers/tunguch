using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfLibraryIndicators",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DictAgeRestrictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictAgeRestrictions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictDuration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictDuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictRegiser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Patronic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictRegiser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(nullable: true),
                    GDP = table.Column<string>(nullable: true),
                    InTurist = table.Column<double>(nullable: false),
                    OutTurist = table.Column<double>(nullable: false),
                    VolumeOfServicesForExport = table.Column<double>(nullable: false),
                    VolumeOfServicesForImport = table.Column<double>(nullable: false),
                    SummOfInvestFromBudget = table.Column<double>(nullable: false),
                    SummOfPrivateDomesticInvest = table.Column<double>(nullable: false),
                    SummOfForeignInvest = table.Column<double>(nullable: false),
                    AverageMonthSalary = table.Column<double>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismIndicator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismIndicator_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictCountryId = table.Column<int>(nullable: true),
                    Years = table.Column<string>(nullable: true),
                    DictRegiserId = table.Column<int>(nullable: true),
                    DictDurationId = table.Column<int>(nullable: true),
                    DictAgeRestrictionsId = table.Column<int>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictAgeRestrictions_DictAgeRestrictionsId",
                        column: x => x.DictAgeRestrictionsId,
                        principalTable: "DictAgeRestrictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictCountry_DictCountryId",
                        column: x => x.DictCountryId,
                        principalTable: "DictCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictDuration_DictDurationId",
                        column: x => x.DictDurationId,
                        principalTable: "DictDuration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyCertificates_DictRegiser_DictRegiserId",
                        column: x => x.DictRegiserId,
                        principalTable: "DictRegiser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfLibraryIndicators_ApplicationUserId",
                table: "ListOfLibraryIndicators",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_ApplicationUserId",
                table: "ListOfCinematographyCertificates",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictAgeRestrictionsId",
                table: "ListOfCinematographyCertificates",
                column: "DictAgeRestrictionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictCountryId",
                table: "ListOfCinematographyCertificates",
                column: "DictCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictDurationId",
                table: "ListOfCinematographyCertificates",
                column: "DictDurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictRegiserId",
                table: "ListOfCinematographyCertificates",
                column: "DictRegiserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismIndicator_ApplicationUserId",
                table: "ListOfTourismIndicator",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfLibraryIndicators_AspNetUsers_ApplicationUserId",
                table: "ListOfLibraryIndicators",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfLibraryIndicators_AspNetUsers_ApplicationUserId",
                table: "ListOfLibraryIndicators");

            migrationBuilder.DropTable(
                name: "ListOfCinematographyCertificates");

            migrationBuilder.DropTable(
                name: "ListOfTourismIndicator");

            migrationBuilder.DropTable(
                name: "DictAgeRestrictions");

            migrationBuilder.DropTable(
                name: "DictCountry");

            migrationBuilder.DropTable(
                name: "DictDuration");

            migrationBuilder.DropTable(
                name: "DictRegiser");

            migrationBuilder.DropIndex(
                name: "IX_ListOfLibraryIndicators_ApplicationUserId",
                table: "ListOfLibraryIndicators");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ListOfLibraryIndicators");
        }
    }
}
