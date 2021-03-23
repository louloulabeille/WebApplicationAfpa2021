using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelAfpa2020.Migrations
{
    public partial class updateParagraphe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                unique: true,
                filter: "[ParagrapheId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse",
                column: "ParagrapheId",
                principalTable: "Paragraphe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reponse_Paragraphe_ParagrapheId",
                table: "Reponse");

            migrationBuilder.DropIndex(
                name: "IX_Reponse_ParagrapheId",
                table: "Reponse");
        }
    }
}
