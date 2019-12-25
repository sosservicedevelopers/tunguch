using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class DefaultConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourismIndicator");

            migrationBuilder.CreateTable(
                name: "ListOfTourismIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(nullable: true),
                    GDP = table.Column<string>(nullable: true),
                    InTurist = table.Column<double>(nullable: false),
                    OutTurist = table.Column<double>(nullable: false),
                    VolumeOfServicesForExport = table.Column<double>(nullable: false),
                    VolumeOfServicesForImport = table.Column<double>(nullable: false),
                    SummOfInvestFromBudget = table.Column<double>(nullable: false),
                    SummOfPrivateDomesticInvest = table.Column<double>(nullable: false),
                    SummOfForeignInvest = table.Column<double>(nullable: false),
                    AverageMonthSalary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfTourismIndicator", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfTourismIndicator");

            migrationBuilder.CreateTable(
                name: "TourismIndicator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageMonthSalary = table.Column<double>(type: "float", nullable: false),
                    GDP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InTurist = table.Column<double>(type: "float", nullable: false),
                    OutTurist = table.Column<double>(type: "float", nullable: false),
                    SummOfForeignInvest = table.Column<double>(type: "float", nullable: false),
                    SummOfInvestFromBudget = table.Column<double>(type: "float", nullable: false),
                    SummOfPrivateDomesticInvest = table.Column<double>(type: "float", nullable: false),
                    VolumeOfServicesForExport = table.Column<double>(type: "float", nullable: false),
                    VolumeOfServicesForImport = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourismIndicator", x => x.Id);
                });
        }
    }
}
