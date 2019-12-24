using Microsoft.EntityFrameworkCore.Migrations;

namespace AisMKIT.Migrations
{
    public partial class MediaCorrect3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DictMediaFinSourceId",
                table: "ListOfMedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DictMediaFinSourceId",
                table: "ListOfMedia",
                type: "integer",
                nullable: true);
        }
    }
}
