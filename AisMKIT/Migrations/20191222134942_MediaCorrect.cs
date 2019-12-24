using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class MediaCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_DictAgencyPerm_DictAgencyPermId",
                table: "ListOfMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_DictDistrict_DictDistrictId",
                table: "ListOfMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_DictMediaDistribTerritory_DictMediaDistribTerri~",
                table: "ListOfMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_DictRegion_DictRegionId",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_DictAgencyPermId",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_DictDistrictId",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_DictMediaDistribTerritoryId",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_DictRegionId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DateOfPay",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DictAgencyPermId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DictDistribTerritoryMediaId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DictDistrictId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DictMediaDistribTerritoryId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "DictRegionId",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "NumOfPermGas",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "NumberOfPermission",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "PermElimGASDate",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "PermGASDate",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "PermissionDate",
                table: "ListOfMedia");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ListOfMedia",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Territoryy",
                table: "ListOfMedia",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListOfMediaHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictLegalFormId = table.Column<int>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Territoryy = table.Column<string>(nullable: true),
                    DictLangMediaTypeId = table.Column<int>(nullable: true),
                    DictMediaLangTypeId = table.Column<int>(nullable: true),
                    DictMediaTypeId = table.Column<int>(nullable: true),
                    AddressRus = table.Column<string>(nullable: true),
                    AddressKyrg = table.Column<string>(nullable: true),
                    DictMediaFreqReleaseId = table.Column<int>(nullable: true),
                    DictMediaFinSourceId = table.Column<int>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    EliminationDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMediaHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaFreqRelease_DictMediaFreqReleas~",
                        column: x => x.DictMediaFreqReleaseId,
                        principalTable: "DictMediaFreqRelease",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaLangType_DictMediaLangTypeId",
                        column: x => x.DictMediaLangTypeId,
                        principalTable: "DictMediaLangType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_DictMediaType_DictMediaTypeId",
                        column: x => x.DictMediaTypeId,
                        principalTable: "DictMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMediaHistory_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTeleRadio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfMediaId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    NumberOfPermission = table.Column<int>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false),
                    DictAgencyPermId = table.Column<int>(nullable: true),
                    DateOfPay = table.Column<DateTime>(nullable: true),
                    NumOfPermGas = table.Column<string>(nullable: true),
                    PermGASDate = table.Column<DateTime>(nullable: true),
                    PermElimGASDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTeleRadio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTeleRadio_DictAgencyPerm_DictAgencyPermId",
                        column: x => x.DictAgencyPermId,
                        principalTable: "DictAgencyPerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTeleRadio_ListOfMedia_ListOfMediaId",
                        column: x => x.ListOfMediaId,
                        principalTable: "ListOfMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictFinSourceId",
                table: "ListOfMediaHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictLegalFormId",
                table: "ListOfMediaHistory",
                column: "DictLegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaFreqReleaseId",
                table: "ListOfMediaHistory",
                column: "DictMediaFreqReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaLangTypeId",
                table: "ListOfMediaHistory",
                column: "DictMediaLangTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_DictMediaTypeId",
                table: "ListOfMediaHistory",
                column: "DictMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_ListOfMediaId",
                table: "ListOfMediaHistory",
                column: "ListOfMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_DictAgencyPermId",
                table: "ListOfTeleRadio",
                column: "DictAgencyPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_ListOfMediaId",
                table: "ListOfTeleRadio",
                column: "ListOfMediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfMediaHistory");

            migrationBuilder.DropTable(
                name: "ListOfTeleRadio");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "Territoryy",
                table: "ListOfMedia");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPay",
                table: "ListOfMedia",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictAgencyPermId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictDistribTerritoryMediaId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictDistrictId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictMediaDistribTerritoryId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictRegionId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumOfPermGas",
                table: "ListOfMedia",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPermission",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PermElimGASDate",
                table: "ListOfMedia",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PermGASDate",
                table: "ListOfMedia",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PermissionDate",
                table: "ListOfMedia",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictAgencyPermId",
                table: "ListOfMedia",
                column: "DictAgencyPermId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictDistrictId",
                table: "ListOfMedia",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictMediaDistribTerritoryId",
                table: "ListOfMedia",
                column: "DictMediaDistribTerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_DictRegionId",
                table: "ListOfMedia",
                column: "DictRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_DictAgencyPerm_DictAgencyPermId",
                table: "ListOfMedia",
                column: "DictAgencyPermId",
                principalTable: "DictAgencyPerm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_DictDistrict_DictDistrictId",
                table: "ListOfMedia",
                column: "DictDistrictId",
                principalTable: "DictDistrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_DictMediaDistribTerritory_DictMediaDistribTerri~",
                table: "ListOfMedia",
                column: "DictMediaDistribTerritoryId",
                principalTable: "DictMediaDistribTerritory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_DictRegion_DictRegionId",
                table: "ListOfMedia",
                column: "DictRegionId",
                principalTable: "DictRegion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
