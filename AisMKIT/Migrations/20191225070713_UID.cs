using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class UID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematography_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematography");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematographyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyServices_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematographyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfControlMedia_AspNetUsers_ApplicationUserId1",
                table: "ListOfControlMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCouncilTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfCouncilTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfEduInstituts_AspNetUsers_ApplicationUserId1",
                table: "ListOfEduInstituts");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfEventsTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfEventsTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_AspNetUsers_ApplicationUserId1",
                table: "ListOfMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMediaHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfMediaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMonuments_AspNetUsers_ApplicationUserId1",
                table: "ListOfMonuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMonumetnTypologicalAccessory_AspNetUsers_ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTeleRadio_AspNetUsers_ApplicationUserId1",
                table: "ListOfTeleRadio");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTheatricalHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfTheatricalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourism_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourism");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourismHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourismHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourismServices_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourismServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourismServices_ApplicationUserId1",
                table: "ListOfTourismServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourismHistory_ApplicationUserId1",
                table: "ListOfTourismHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourism_ApplicationUserId1",
                table: "ListOfTourism");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTheatricalHistory_ApplicationUserId1",
                table: "ListOfTheatricalHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTheatrical_ApplicationUserId1",
                table: "ListOfTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTeleRadio_ApplicationUserId1",
                table: "ListOfTeleRadio");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMonuments_ApplicationUserId1",
                table: "ListOfMonuments");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMediaHistory_ApplicationUserId1",
                table: "ListOfMediaHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_ApplicationUserId1",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfEventsTheatrical_ApplicationUserId1",
                table: "ListOfEventsTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfEduInstituts_ApplicationUserId1",
                table: "ListOfEduInstituts");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCouncilTheatrical_ApplicationUserId1",
                table: "ListOfCouncilTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfControlMedia_ApplicationUserId1",
                table: "ListOfControlMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyServices_ApplicationUserId1",
                table: "ListOfCinematographyServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyHistory_ApplicationUserId1",
                table: "ListOfCinematographyHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematography_ApplicationUserId1",
                table: "ListOfCinematography");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTourismServices");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTourismHistory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTourism");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTheatricalHistory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTheatrical");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfTeleRadio");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfMonuments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfMediaHistory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfMedia");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfEventsTheatrical");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfEduInstituts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfCouncilTheatrical");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfControlMedia");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfCinematographyServices");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfCinematographyHistory");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ListOfCinematography");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTourismServices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTourismHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTourism",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTheatricalHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTheatrical",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfTeleRadio",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfMonuments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfMediaHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfMedia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfEventsTheatrical",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfEduInstituts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfCouncilTheatrical",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfControlMedia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfCinematographyServices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfCinematographyHistory",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ListOfCinematography",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_ApplicationUserId",
                table: "ListOfTourismServices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_ApplicationUserId",
                table: "ListOfTourismHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_ApplicationUserId",
                table: "ListOfTourism",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_ApplicationUserId",
                table: "ListOfTheatricalHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_ApplicationUserId",
                table: "ListOfTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_ApplicationUserId",
                table: "ListOfTeleRadio",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_ApplicationUserId",
                table: "ListOfMonuments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_ApplicationUserId",
                table: "ListOfMediaHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_ApplicationUserId",
                table: "ListOfMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_ApplicationUserId",
                table: "ListOfEventsTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_ApplicationUserId",
                table: "ListOfEduInstituts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCouncilTheatrical_ApplicationUserId",
                table: "ListOfCouncilTheatrical",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_ApplicationUserId",
                table: "ListOfControlMedia",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_ApplicationUserId",
                table: "ListOfCinematographyServices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_ApplicationUserId",
                table: "ListOfCinematographyHistory",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_ApplicationUserId",
                table: "ListOfCinematography",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematography_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematography",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematographyHistory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyServices_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematographyServices",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfControlMedia_AspNetUsers_ApplicationUserId",
                table: "ListOfControlMedia",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCouncilTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfCouncilTheatrical",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfEduInstituts_AspNetUsers_ApplicationUserId",
                table: "ListOfEduInstituts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfEventsTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfEventsTheatrical",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_AspNetUsers_ApplicationUserId",
                table: "ListOfMedia",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMediaHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfMediaHistory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMonuments_AspNetUsers_ApplicationUserId",
                table: "ListOfMonuments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMonumetnTypologicalAccessory_AspNetUsers_ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTeleRadio_AspNetUsers_ApplicationUserId",
                table: "ListOfTeleRadio",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfTheatrical",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTheatricalHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfTheatricalHistory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourism_AspNetUsers_ApplicationUserId",
                table: "ListOfTourism",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourismHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfTourismHistory",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourismServices_AspNetUsers_ApplicationUserId",
                table: "ListOfTourismServices",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematography_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematography");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematographyHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyServices_AspNetUsers_ApplicationUserId",
                table: "ListOfCinematographyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfControlMedia_AspNetUsers_ApplicationUserId",
                table: "ListOfControlMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCouncilTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfCouncilTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfEduInstituts_AspNetUsers_ApplicationUserId",
                table: "ListOfEduInstituts");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfEventsTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfEventsTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMedia_AspNetUsers_ApplicationUserId",
                table: "ListOfMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMediaHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfMediaHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMonuments_AspNetUsers_ApplicationUserId",
                table: "ListOfMonuments");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfMonumetnTypologicalAccessory_AspNetUsers_ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTeleRadio_AspNetUsers_ApplicationUserId",
                table: "ListOfTeleRadio");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTheatrical_AspNetUsers_ApplicationUserId",
                table: "ListOfTheatrical");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTheatricalHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfTheatricalHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourism_AspNetUsers_ApplicationUserId",
                table: "ListOfTourism");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourismHistory_AspNetUsers_ApplicationUserId",
                table: "ListOfTourismHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfTourismServices_AspNetUsers_ApplicationUserId",
                table: "ListOfTourismServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourismServices_ApplicationUserId",
                table: "ListOfTourismServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourismHistory_ApplicationUserId",
                table: "ListOfTourismHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTourism_ApplicationUserId",
                table: "ListOfTourism");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTheatricalHistory_ApplicationUserId",
                table: "ListOfTheatricalHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTheatrical_ApplicationUserId",
                table: "ListOfTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfTeleRadio_ApplicationUserId",
                table: "ListOfTeleRadio");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMonuments_ApplicationUserId",
                table: "ListOfMonuments");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMediaHistory_ApplicationUserId",
                table: "ListOfMediaHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfMedia_ApplicationUserId",
                table: "ListOfMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfEventsTheatrical_ApplicationUserId",
                table: "ListOfEventsTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfEduInstituts_ApplicationUserId",
                table: "ListOfEduInstituts");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCouncilTheatrical_ApplicationUserId",
                table: "ListOfCouncilTheatrical");

            migrationBuilder.DropIndex(
                name: "IX_ListOfControlMedia_ApplicationUserId",
                table: "ListOfControlMedia");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyServices_ApplicationUserId",
                table: "ListOfCinematographyServices");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyHistory_ApplicationUserId",
                table: "ListOfCinematographyHistory");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematography_ApplicationUserId",
                table: "ListOfCinematography");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTourismServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTourismServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTourismHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTourismHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTourism",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTourism",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTheatricalHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTheatricalHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTheatrical",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTheatrical",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfTeleRadio",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfTeleRadio",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfMonumetnTypologicalAccessory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfMonuments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfMonuments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfMediaHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfMediaHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfMedia",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfEventsTheatrical",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfEventsTheatrical",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfEduInstituts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfEduInstituts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfCouncilTheatrical",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfCouncilTheatrical",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfControlMedia",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfControlMedia",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfCinematographyServices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfCinematographyServices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfCinematographyHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfCinematographyHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "ListOfCinematography",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ListOfCinematography",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismServices_ApplicationUserId1",
                table: "ListOfTourismServices",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourismHistory_ApplicationUserId1",
                table: "ListOfTourismHistory",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTourism_ApplicationUserId1",
                table: "ListOfTourism",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatricalHistory_ApplicationUserId1",
                table: "ListOfTheatricalHistory",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTheatrical_ApplicationUserId1",
                table: "ListOfTheatrical",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfTeleRadio_ApplicationUserId1",
                table: "ListOfTeleRadio",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonumetnTypologicalAccessory_ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMonuments_ApplicationUserId1",
                table: "ListOfMonuments",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMediaHistory_ApplicationUserId1",
                table: "ListOfMediaHistory",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMedia_ApplicationUserId1",
                table: "ListOfMedia",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEventsTheatrical_ApplicationUserId1",
                table: "ListOfEventsTheatrical",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfEduInstituts_ApplicationUserId1",
                table: "ListOfEduInstituts",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCouncilTheatrical_ApplicationUserId1",
                table: "ListOfCouncilTheatrical",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfControlMedia_ApplicationUserId1",
                table: "ListOfControlMedia",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyServices_ApplicationUserId1",
                table: "ListOfCinematographyServices",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyHistory_ApplicationUserId1",
                table: "ListOfCinematographyHistory",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematography_ApplicationUserId1",
                table: "ListOfCinematography",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematography_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematography",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematographyHistory",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyServices_AspNetUsers_ApplicationUserId1",
                table: "ListOfCinematographyServices",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfControlMedia_AspNetUsers_ApplicationUserId1",
                table: "ListOfControlMedia",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCouncilTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfCouncilTheatrical",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfEduInstituts_AspNetUsers_ApplicationUserId1",
                table: "ListOfEduInstituts",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfEventsTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfEventsTheatrical",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMedia_AspNetUsers_ApplicationUserId1",
                table: "ListOfMedia",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMediaHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfMediaHistory",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMonuments_AspNetUsers_ApplicationUserId1",
                table: "ListOfMonuments",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfMonumetnTypologicalAccessory_AspNetUsers_ApplicationUserId1",
                table: "ListOfMonumetnTypologicalAccessory",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTeleRadio_AspNetUsers_ApplicationUserId1",
                table: "ListOfTeleRadio",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTheatrical_AspNetUsers_ApplicationUserId1",
                table: "ListOfTheatrical",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTheatricalHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfTheatricalHistory",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourism_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourism",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourismHistory_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourismHistory",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfTourismServices_AspNetUsers_ApplicationUserId1",
                table: "ListOfTourismServices",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
