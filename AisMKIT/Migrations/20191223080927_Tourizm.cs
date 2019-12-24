using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class Tourizm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictTourismServices",
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
                    table.PrimaryKey("PK_DictTourismServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourism",
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
                    FactDistrictId = table.Column<int>(nullable: false),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourism", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourism_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfTourismId = table.Column<int>(nullable: false),
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
                    FactDistrictId = table.Column<int>(nullable: false),
                    LegalFactAddress = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTourismHistory_ListOfTourism_ListOfTourismId",
                        column: x => x.ListOfTourismId,
                        principalTable: "ListOfTourism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTourismServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DictTourismServicesId = table.Column<int>(nullable: false),
                    ListOfTourismId = table.Column<int>(nullable: false),
                    DictStatusId = table.Column<int>(nullable: false),
                    DeactivateStatus = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_DictTourismServices_DictTourismServic~",
                        column: x => x.DictTourismServicesId,
                        principalTable: "DictTourismServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfTourismServices_ListOfTourism_ListOfTourismId",
                        column: x => x.ListOfTourismId,
                        principalTable: "ListOfTourism",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictDistrictId",
                table: "ListOfTourism",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictFinSourceId",
                table: "ListOfTourism",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_DictLegalFormId",
                table: "ListOfTourism",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictDistrictId",
                table: "ListOfTourismHistory",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictFinSourceId",
                table: "ListOfTourismHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_DictLegalFormId",
                table: "ListOfTourismHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_ListOfTourismId",
                table: "ListOfTourismHistory",
                column: "ListOfTourismId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_DictStatusId",
                table: "ListOfTourismServices",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_DictTourismServicesId",
                table: "ListOfTourismServices",
                column: "DictTourismServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_ListOfTourismId",
                table: "ListOfTourismServices",
                column: "ListOfTourismId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfTourismHistory");

            migrationBuilder.DropTable(
                name: "ListOfTourismServices");

            migrationBuilder.DropTable(
                name: "DictTourismServices");

            migrationBuilder.DropTable(
                name: "ListOfTourism");
        }
    }
}
