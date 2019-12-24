using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class MonumentsCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListMonumetnTypologicalAccessory");

            migrationBuilder.CreateTable(
                name: "ListOfMonumetnTypologicalAccessory",
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
                    table.PrimaryKey("PK_ListOfMonumetnTypologicalAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMonumetnTypologicalAccessory_DictMonumentTypologicalT~",
                        column: x => x.DictMonumentTypologicalTypeId,
                        principalTable: "DictMonumentTypologicalType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfMonumetnTypologicalAccessory_ListOfMonuments_ListOfMo~",
                        column: x => x.ListOfMonumentsId,
                        principalTable: "ListOfMonuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_DictMonumentTypologicalT~",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "DictMonumentTypologicalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ListOfMonumentsId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ListOfMonumentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.CreateTable(
                name: "ListMonumetnTypologicalAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DictMonumentTypologicalTypeId = table.Column<int>(type: "integer", nullable: false),
                    ListOfMonumentsId = table.Column<int>(type: "integer", nullable: false)
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
        }
    }
}
