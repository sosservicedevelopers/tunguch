using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class TZY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DictLangMediaTypeId",
                table: "ListOfMediaHistory");

            migrationBuilder.CreateTable(
                name: "DictTheatricalHall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameKyrg = table.Column<string>(nullable: true),
                    NameRus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictTheatricalHall", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfTheatrical",
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
                    LastNameOfArtsDirector = table.Column<string>(nullable: true),
                    FirstNameOfArtsDirector = table.Column<string>(nullable: true),
                    PatronicNameOfArtsDirector = table.Column<string>(nullable: true),
                    NumEmployees = table.Column<int>(nullable: false),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    ReregistrationDate = table.Column<DateTime>(nullable: false),
                    DeactiveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTheatrical_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatrical_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCouncilTheatrical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
                    LastNameOfArts = table.Column<string>(nullable: true),
                    FirstNameOfArts = table.Column<string>(nullable: true),
                    PatronicNameOfArts = table.Column<string>(nullable: true),
                    DateInArtCouncil = table.Column<DateTime>(nullable: false),
                    DateOutArtCouncil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCouncilTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCouncilTheatrical_ListOfTheatrical_ListOfTheatricalId",
                        column: x => x.ListOfTheatricalId,
                        principalTable: "ListOfTheatrical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListOfEventsTheatrical",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true),
                    Month = table.Column<string>(nullable: true),
                    DayOfMonth = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    NameOfEvent = table.Column<string>(nullable: true),
                    DictTheatricalHallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfEventsTheatrical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfEventsTheatrical_DictTheatricalHall_DictTheatricalHal~",
                        column: x => x.DictTheatricalHallId,
                        principalTable: "DictTheatricalHall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfEventsTheatrical_ListOfTheatrical_ListOfTheatricalId",
                        column: x => x.ListOfTheatricalId,
                        principalTable: "ListOfTheatrical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCouncilTheatrical_ListOfTheatricalId",
                table: "ListOfCouncilTheatrical",
                column: "ListOfTheatricalId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_DictTheatricalHallId",
                table: "ListOfEventsTheatrical",
                column: "DictTheatricalHallId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_ListOfTheatricalId",
                table: "ListOfEventsTheatrical",
                column: "ListOfTheatricalId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_DictFinSourceId",
                table: "ListOfTheatrical",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_DictLegalFormId",
                table: "ListOfTheatrical",
                column: "DictLegalFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfCouncilTheatrical");

            migrationBuilder.DropTable(
                name: "ListOfEventsTheatrical");

            migrationBuilder.DropTable(
                name: "DictTheatricalHall");

            migrationBuilder.DropTable(
                name: "ListOfTheatrical");

            migrationBuilder.AddColumn<int>(
                name: "DictLangMediaTypeId",
                table: "ListOfMediaHistory",
                type: "integer",
                nullable: true);
        }
    }
}
