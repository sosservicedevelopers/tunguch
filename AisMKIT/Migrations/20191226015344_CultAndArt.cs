using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class CultAndArt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictCultAndArtType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true),
                    DictStatusId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictCultAndArtType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DictCultAndArtType_DictStatus_DictStatusId",
                        column: x => x.DictStatusId,
                        principalTable: "DictStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCultAndArt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictCultAndArtTypeId = table.Column<int>(nullable: false),
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
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCultAndArt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictCultAndArtType_DictCultAndArtTypeId",
                        column: x => x.DictCultAndArtTypeId,
                        principalTable: "DictCultAndArtType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfCultAndArt_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictCultAndArtType_DictStatusId",
                table: "DictCultAndArtType",
                column: "DictStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_ApplicationUserId",
                table: "ListOfCultAndArt",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictCultAndArtTypeId",
                table: "ListOfCultAndArt",
                column: "DictCultAndArtTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictDistrictId",
                table: "ListOfCultAndArt",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictFinSourceId",
                table: "ListOfCultAndArt",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultAndArt_DictLegalFormId",
                table: "ListOfCultAndArt",
                column: "DictLegalFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfCultAndArt");

            migrationBuilder.DropTable(
                name: "DictCultAndArtType");
        }
    }
}
