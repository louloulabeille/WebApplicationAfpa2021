using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelAfpa2020.Migrations
{
    public partial class updateModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParagrapheId",
                table: "Reponse",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParagrapheId",
                table: "Reponse");
        }
    }
}
