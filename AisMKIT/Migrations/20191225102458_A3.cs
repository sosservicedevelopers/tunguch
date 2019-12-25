using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourismIndicator",
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
                    table.PrimaryKey("PK_TourismIndicator", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourismIndicator");
        }
    }
}
