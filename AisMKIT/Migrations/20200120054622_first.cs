using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AisMKIT.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyCertificates_DictCinemaRegiser_DictCine~",
                table: "ListOfCinematographyCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCinematographyCertificates_DictCountry_DictCountryId",
                table: "ListOfCinematographyCertificates");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyCertificates_DictCinemaRegiserId",
                table: "ListOfCinematographyCertificates");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCinematographyCertificates_DictCountryId",
                table: "ListOfCinematographyCertificates");

            migrationBuilder.DropColumn(
                name: "DictCinemaRegiserId",
                table: "ListOfCinematographyCertificates");

            migrationBuilder.DropColumn(
                name: "DictCountryId",
                table: "ListOfCinematographyCertificates");

           
            migrationBuilder.AddColumn<decimal>(
                name: "FromCIS",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FromForeign",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossValueAdded",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InvestmentsTourismSector",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RevenuesFromTransportTourists",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SanatoriumResortActivities",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ServicesShortTermResidence",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ShareOfTourismInGDP",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxRevenue",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TheNumCitizensfromNearAndFar",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TourismTetailSales",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TravelAgencyServices",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TurnoverPreparedFood",
                table: "ListOfTourismIndicator",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CinemaCountries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfCinematographyCertificatesId = table.Column<int>(nullable: true),
                    DictCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaCountries_DictCountry_DictCountryId",
                        column: x => x.DictCountryId,
                        principalTable: "DictCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaCountries_ListOfCinematographyCertificates_ListOfCine~",
                        column: x => x.ListOfCinematographyCertificatesId,
                        principalTable: "ListOfCinematographyCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRegisers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListOfCinematographyCertificatesId = table.Column<int>(nullable: true),
                    DictCinemaRegiserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRegisers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaRegisers_DictCinemaRegiser_DictCinemaRegiserId",
                        column: x => x.DictCinemaRegiserId,
                        principalTable: "DictCinemaRegiser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CinemaRegisers_ListOfCinematographyCertificates_ListOfCinem~",
                        column: x => x.ListOfCinematographyCertificatesId,
                        principalTable: "ListOfCinematographyCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaCountries_DictCountryId",
                table: "CinemaCountries",
                column: "DictCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaCountries_ListOfCinematographyCertificatesId",
                table: "CinemaCountries",
                column: "ListOfCinematographyCertificatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRegisers_DictCinemaRegiserId",
                table: "CinemaRegisers",
                column: "DictCinemaRegiserId");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRegisers_ListOfCinematographyCertificatesId",
                table: "CinemaRegisers",
                column: "ListOfCinematographyCertificatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaCountries");

            migrationBuilder.DropTable(
                name: "CinemaRegisers");

            migrationBuilder.DropColumn(
                name: "FromCIS",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "FromForeign",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "GrossValueAdded",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "InvestmentsTourismSector",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "RevenuesFromTransportTourists",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "SanatoriumResortActivities",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "ServicesShortTermResidence",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "ShareOfTourismInGDP",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "TaxRevenue",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "TheNumCitizensfromNearAndFar",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "TourismTetailSales",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "TravelAgencyServices",
                table: "ListOfTourismIndicator");

            migrationBuilder.DropColumn(
                name: "TurnoverPreparedFood",
                table: "ListOfTourismIndicator");

            migrationBuilder.AlterColumn<string>(
                name: "VolumeOfServicesForImport",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "VolumeOfServicesForExport",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "SummOfPrivateDomesticInvest",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "SummOfInvestFromBudget",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "SummOfForeignInvest",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "OutTurist",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "InTurist",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "GDP",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "AverageMonthSalary",
                table: "ListOfTourismIndicator",
                type: "text",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "DictCinemaRegiserId",
                table: "ListOfCinematographyCertificates",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictCountryId",
                table: "ListOfCinematographyCertificates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictCinemaRegiserId",
                table: "ListOfCinematographyCertificates",
                column: "DictCinemaRegiserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCinematographyCertificates_DictCountryId",
                table: "ListOfCinematographyCertificates",
                column: "DictCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyCertificates_DictCinemaRegiser_DictCine~",
                table: "ListOfCinematographyCertificates",
                column: "DictCinemaRegiserId",
                principalTable: "DictCinemaRegiser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCinematographyCertificates_DictCountry_DictCountryId",
                table: "ListOfCinematographyCertificates",
                column: "DictCountryId",
                principalTable: "DictCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
