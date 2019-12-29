using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class corests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfMonumentsProtObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    NameKyrg = table.Column<string>(nullable: true),
                    DictDistrictId = table.Column<int>(nullable: true),
                    LegalAddress = table.Column<string>(nullable: true),
                    DictFinSourceId = table.Column<int>(nullable: true),
                    LastNameDirector = table.Column<string>(nullable: true),
                    FirstNameDirector = table.Column<string>(nullable: true),
                    PatronicNameDirector = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true),
                    LegalDocs = table.Column<string>(nullable: true),
                    Ploshad = table.Column<string>(nullable: true),
                    CurrentStatus = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMonumentsProtObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMonumentsProtObjects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonumentsProtObjects_DictDistrict_DictDistrictId",
                        column: x => x.DictDistrictId,
                        principalTable: "DictDistrict",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfMonumentsProtObjects_DictFinSource_DictFinSourceId",
                        column: x => x.DictFinSourceId,
                        principalTable: "DictFinSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumentsProtObjects_ApplicationUserId",
                table: "ListOfMonumentsProtObjects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumentsProtObjects_DictDistrictId",
                table: "ListOfMonumentsProtObjects",
                column: "DictDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumentsProtObjects_DictFinSourceId",
                table: "ListOfMonumentsProtObjects",
                column: "DictFinSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfMonumentsProtObjects");
        }
    }
}
