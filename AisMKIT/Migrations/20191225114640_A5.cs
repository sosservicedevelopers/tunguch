using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryIndicators");

            migrationBuilder.DropTable(
                name: "TourismIndicator");

            migrationBuilder.CreateTable(
                name: "ListOfLibraryIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryName = table.Column<string>(nullable: true),
                    AddressData = table.Column<string>(nullable: true),
                    TotalArea = table.Column<float>(nullable: false),
                    SeatLanding = table.Column<string>(nullable: true),
                    EmerCapLib = table.Column<string>(nullable: true),
                    SpecAdapLib = table.Column<string>(nullable: true),
                    OverhaulMade = table.Column<string>(nullable: true),
                    Redecorated = table.Column<string>(nullable: true),
                    Computers = table.Column<int>(nullable: false),
                    InternetConnection = table.Column<int>(nullable: false),
                    ComputersForUsers = table.Column<int>(nullable: false),
                    UserConnection = table.Column<int>(nullable: false),
                    UsersLib = table.Column<int>(nullable: false),
                    RecRetTotal = table.Column<int>(nullable: false),
                    TotalNumOfEx = table.Column<int>(nullable: false),
                    CopKyrg = table.Column<int>(nullable: false),
                    EventsLib = table.Column<int>(nullable: false),
                    Librarians = table.Column<int>(nullable: false),
                    DegEducation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfLibraryIndicators", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfLibraryIndicators");

            migrationBuilder.CreateTable(
                name: "LibraryIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Computers = table.Column<int>(type: "int", nullable: false),
                    ComputersForUsers = table.Column<int>(type: "int", nullable: false),
                    CopKyrg = table.Column<int>(type: "int", nullable: false),
                    DegEducation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmerCapLib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventsLib = table.Column<int>(type: "int", nullable: false),
                    InternetConnection = table.Column<int>(type: "int", nullable: false),
                    Librarians = table.Column<int>(type: "int", nullable: false),
                    LibraryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverhaulMade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecRetTotal = table.Column<int>(type: "int", nullable: false),
                    Redecorated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatLanding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecAdapLib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalArea = table.Column<float>(type: "real", nullable: false),
                    TotalNumOfEx = table.Column<int>(type: "int", nullable: false),
                    UserConnection = table.Column<int>(type: "int", nullable: false),
                    UsersLib = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryIndicators", x => x.Id);
                });

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
