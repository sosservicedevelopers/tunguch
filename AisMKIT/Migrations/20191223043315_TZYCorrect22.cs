using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class TZYCorrect22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReregistrationDate",
                table: "ListOfTheatrical",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactiveDate",
                table: "ListOfTheatrical",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateTable(
                name: "ListOfTheatricalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfTheatricalId = table.Column<int>(nullable: false),
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
                    ReregistrationDate = table.Column<DateTime>(nullable: true),
                    DeactiveDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTheatricalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfTheatricalHistory_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfTheatricalHistory_DictLegalForm_DictLegalFormId",
                        column: x => x.DictLegalFormId,
                        principalTable: "DictLegalForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_DictFinSourceId",
                table: "ListOfTheatricalHistory",
                column: "DictFinSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_DictLegalFormId",
                table: "ListOfTheatricalHistory",
                column: "DictLegalFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfTheatricalHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReregistrationDate",
                table: "ListOfTheatrical",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeactiveDate",
                table: "ListOfTheatrical",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
