using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class Monuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictMonumemtSignOfLoss",
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
                    table.PrimaryKey("PK_DictMonumemtSignOfLoss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictMonumentType",
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
                    table.PrimaryKey("PK_DictMonumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictMonumentTypologicalType",
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
                    table.PrimaryKey("PK_DictMonumentTypologicalType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfMonuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DatingOfMonument = table.Column<string>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    DictMonumentTypeId = table.Column<int>(nullable: false),
                    DictMonumemtSignOfLossId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMonuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictMonumemtSignOfLoss_DictMonumemtSignOfLo~",
                        column: x => x.DictMonumemtSignOfLossId,
                        principalTable: "DictMonumemtSignOfLoss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfMonuments_DictMonumentType_DictMonumentTypeId",
                        column: x => x.DictMonumentTypeId,
                        principalTable: "DictMonumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListMonumetnTypologicalAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfMonumentsId = table.Column<int>(nullable: false),
                    DictMonumentTypologicalTypeId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListMonumetnTypologicalAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListMonumetnTypologicalAccessory_DictMonumentTypologicalTyp~",
                        column: x => x.DictMonumentTypologicalTypeId,
                        principalTable: "DictMonumentTypologicalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListMonumetnTypologicalAccessory_ListOfMonuments_ListOfMonu~",
                        column: x => x.ListOfMonumentsId,
                        principalTable: "ListOfMonuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListMonumetnTypologicalAccessory_DictMonumentTypologicalTyp~",
                table: "ListMonumetnTypologicalAccessory",
                column: "DictMonumentTypologicalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListMonumetnTypologicalAccessory_ListOfMonumentsId",
                table: "ListMonumetnTypologicalAccessory",
                column: "ListOfMonumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictDistrictId",
                table: "ListOfMonuments",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictFinSourceId",
                table: "ListOfMonuments",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictMonumemtSignOfLossId",
                table: "ListOfMonuments",
                column: "DictMonumemtSignOfLossId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_DictMonumentTypeId",
                table: "ListOfMonuments",
                column: "DictMonumentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListMonumetnTypologicalAccessory");

            migrationBuilder.DropTable(
                name: "DictMonumentTypologicalType");

            migrationBuilder.DropTable(
                name: "ListOfMonuments");

            migrationBuilder.DropTable(
                name: "DictMonumemtSignOfLoss");

            migrationBuilder.DropTable(
                name: "DictMonumentType");
        }
    }
}
