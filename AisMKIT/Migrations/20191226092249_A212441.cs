using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class A212441 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictInitiatorOfProj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictInitiatorOfProj", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictLoc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictLoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DictTypeOfKMM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictTypeOfKMM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCultEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DictTypeOfKMMId = table.Column<int>(nullable: false),
                    DistLocId = table.Column<int>(nullable: false),
                    EventTopic = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<string>(nullable: true),
                    DictInitiatorOfProjId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfCultEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfCultEvents_DictInitiatorOfProj_DictInitiatorOfProjId",
                        column: x => x.DictInitiatorOfProjId,
                        principalTable: "DictInitiatorOfProj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCultEvents_DictTypeOfKMM_DictTypeOfKMMId",
                        column: x => x.DictTypeOfKMMId,
                        principalTable: "DictTypeOfKMM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListOfCultEvents_DictLoc_DistLocId",
                        column: x => x.DistLocId,
                        principalTable: "DictLoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultEvents_DictInitiatorOfProjId",
                table: "ListOfCultEvents",
                column: "DictInitiatorOfProjId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultEvents_DictTypeOfKMMId",
                table: "ListOfCultEvents",
                column: "DictTypeOfKMMId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCultEvents_DistLocId",
                table: "ListOfCultEvents",
                column: "DistLocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListOfCultEvents");

            migrationBuilder.DropTable(
                name: "DictInitiatorOfProj");

            migrationBuilder.DropTable(
                name: "DictTypeOfKMM");

            migrationBuilder.DropTable(
                name: "DictLoc");
        }
    }
}
