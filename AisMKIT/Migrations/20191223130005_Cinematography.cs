using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class Cinematography : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictCinematographyServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCinematographyServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematography", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematography_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfCinematographyId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    FactDistrictId = table.Column<string>(nullable: true),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyHistory_ListOfCinematography_ListOfCine~",
                        column: x => x.ListOfCinematographyId,
                        principalTable: "ListOfCinematography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DictCinematographyServicesId = table.Column<int>(nullable: false),
                    ListOfCinematographyId = table.Column<int>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: false),
                    DeactivateStatus = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_DictCinematographyServices_Dic~",
                        column: x => x.DictCinematographyServicesId,
                        principalTable: "DictCinematographyServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyServices_ListOfCinematography_ListOfCin~",
                        column: x => x.ListOfCinematographyId,
                        principalTable: "ListOfCinematography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictDistrictId",
                table: "ListOfCinematography",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictFinSourceId",
                table: "ListOfCinematography",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_DictLegalFormId",
                table: "ListOfCinematography",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictDistrictId",
                table: "ListOfCinematographyHistory",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictFinSourceId",
                table: "ListOfCinematographyHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_DictLegalFormId",
                table: "ListOfCinematographyHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_ListOfCinematographyId",
                table: "ListOfCinematographyHistory",
                column: "ListOfCinematographyId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_DictCinematographyServicesId",
                table: "ListOfCinematographyServices",
                column: "DictCinematographyServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_DictStatusId",
                table: "ListOfCinematographyServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_ListOfCinematographyId",
                table: "ListOfCinematographyServices",
                column: "ListOfCinematographyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfCinematographyHistory");

            migrationBuilder.DropTable(
                name: "ListOfCinematographyServices");

            migrationBuilder.DropTable(
                name: "DictCinematographyServices");

            migrationBuilder.DropTable(
                name: "ListOfCinematography");
        }
    }
}
