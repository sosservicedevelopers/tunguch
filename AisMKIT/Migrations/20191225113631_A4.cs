using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibraryIndicators",
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
                    table.PrimaryKey("PK_LibraryIndicators", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryIndicators");
        }
    }
}
