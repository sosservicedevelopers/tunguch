using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class SMI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DictDistribTerritoryMediaId = table.Column<int>(nullable: true),
                    DictMediaDistribTerritoryId = table.Column<int>(nullable: true),
                    DictLangMediaTypeId = table.Column<int>(nullable: true),
                    DictMediaLangTypeId = table.Column<int>(nullable: true),
                    DictMediaTypeId = table.Column<int>(nullable: true),
                    AddressRus = table.Column<string>(nullable: true),
                    AddressKyrg = table.Column<string>(nullable: true),
                    DictRegionId = table.Column<int>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    DictMediaFreqReleaseId = table.Column<int>(nullable: true),
                    DictMediaFinSourceId = table.Column<int>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    EliminationDate = table.Column<DateTime>(nullable: true),
                    NumberOfPermission = table.Column<int>(nullable: true),
                    PermissionDate = table.Column<DateTime>(nullable: true),
                    DictAgencyPermId = table.Column<int>(nullable: true),
                    DateOfPay = table.Column<DateTime>(nullable: true),
                    NumOfPermGas = table.Column<string>(nullable: true),
                    PermGASDate = table.Column<DateTime>(nullable: true),
                    PermElimGASDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictAgencyPerm_DictAgencyPermId",
                        column: x => x.DictAgencyPermId,
                        principalTable: "DictAgencyPerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaDistribTerritory_DictMediaDistribTerri~",
                        column: x => x.DictMediaDistribTerritoryId,
                        principalTable: "DictMediaDistribTerritory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaFreqRelease_DictMediaFreqReleaseId",
                        column: x => x.DictMediaFreqReleaseId,
                        principalTable: "DictMediaFreqRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaLangType_DictMediaLangTypeId",
                        column: x => x.DictMediaLangTypeId,
                        principalTable: "DictMediaLangType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictMediaType_DictMediaTypeId",
                        column: x => x.DictMediaTypeId,
                        principalTable: "DictMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMedia_DictRegion_DictRegionId",
                        column: x => x.DictRegionId,
                        principalTable: "DictRegion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfControlMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    DictControlTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    StartDatePeriod = table.Column<DateTime>(nullable: true),
                    EndDatePeriod = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    PatronicName = table.Column<string>(nullable: true),
                    ActDateControl = table.Column<DateTime>(nullable: true),
                    NumberOfAct = table.Column<string>(nullable: true),
                    DictMediaControlResultId = table.Column<int>(nullable: true),
                    NumberOfWarning = table.Column<string>(nullable: true),
                    WarningDate = table.Column<DateTime>(nullable: true),
                    WarningEndDate = table.Column<DateTime>(nullable: true),
                    WarningRemovalDate = table.Column<DateTime>(nullable: true),
                    DateOfPenalty = table.Column<DateTime>(nullable: true),
                    DocNumPenalty = table.Column<string>(nullable: true),
                    PenaltySum = table.Column<string>(nullable: true),
                    DateOfPenaltyPay = table.Column<DateTime>(nullable: true),
                    AnulmentDate = table.Column<DateTime>(nullable: true),
                    NumberOfAnulment = table.Column<string>(nullable: true),
                    DateOfSuit = table.Column<DateTime>(nullable: true),
                    NumberOfSuit = table.Column<string>(nullable: true),
                    DateOfSuitPerm = table.Column<DateTime>(nullable: true),
                    NumberOfSuitPerm = table.Column<string>(nullable: true),
                    DictMediaSuitPermId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfControlMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictControlType_DictControlTypeId",
                        column: x => x.DictControlTypeId,
                        principalTable: "DictControlType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictMediaControlResult_DictMediaControlR~",
                        column: x => x.DictMediaControlResultId,
                        principalTable: "DictMediaControlResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_DictMediaSuitPerm_DictMediaSuitPermId",
                        column: x => x.DictMediaSuitPermId,
                        principalTable: "DictMediaSuitPerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfControlMedia_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictControlTypeId",
                table: "ListOfControlMedia",
                column: "DictControlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictMediaControlResultId",
                table: "ListOfControlMedia",
                column: "DictMediaControlResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_DictMediaSuitPermId",
                table: "ListOfControlMedia",
                column: "DictMediaSuitPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_ListOfMediaId",
                table: "ListOfControlMedia",
                column: "ListOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictAgencyPermId",
                table: "ListOfMedia",
                column: "DictAgencyPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictDistrictId",
                table: "ListOfMedia",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictFinSourceId",
                table: "ListOfMedia",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictLegalFormId",
                table: "ListOfMedia",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaDistribTerritoryId",
                table: "ListOfMedia",
                column: "DictMediaDistribTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaFreqReleaseId",
                table: "ListOfMedia",
                column: "DictMediaFreqReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaLangTypeId",
                table: "ListOfMedia",
                column: "DictMediaLangTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaTypeId",
                table: "ListOfMedia",
                column: "DictMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictRegionId",
                table: "ListOfMedia",
                column: "DictRegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfControlMedia");

            migrationBuilder.DropTable(
                name: "ListOfMedia");
        }
    }
}
