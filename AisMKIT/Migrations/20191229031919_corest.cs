using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class corest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ListOfCinematographyDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRus = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCinematographyDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCinematographyDocuments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListOfEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictTypeOfKMMId = table.Column<int>(nullable: false),
                    DistLocId = table.Column<int>(nullable: false),
                    EventTopic = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<string>(nullable: true),
                    DictInitiatorOfProjId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfEvents_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListOfEvents_DictInitiatorOfProj_DictInitiatorOfProjId",
                        column: x => x.DictInitiatorOfProjId,
                        principalTable: "DictInitiatorOfProj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfEvents_DictTypeOfKMM_DictTypeOfKMMId",
                        column: x => x.DictTypeOfKMMId,
                        principalTable: "DictTypeOfKMM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfEvents_DictLoc_DistLocId",
                        column: x => x.DistLocId,
                        principalTable: "DictLoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyDocuments_ApplicationUserId",
                table: "ListOfCinematographyDocuments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEvents_ApplicationUserId",
                table: "ListOfEvents",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEvents_DictInitiatorOfProjId",
                table: "ListOfEvents",
                column: "DictInitiatorOfProjId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEvents_DictTypeOfKMMId",
                table: "ListOfEvents",
                column: "DictTypeOfKMMId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEvents_DistLocId",
                table: "ListOfEvents",
                column: "DistLocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfCinematographyDocuments");

            migrationBuilder.DropTable(
                name: "ListOfEvents");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ListOfTourismIndicator");
        }
    }
}
