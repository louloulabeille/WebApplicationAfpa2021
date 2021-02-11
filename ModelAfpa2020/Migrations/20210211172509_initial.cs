using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelAfpa2020.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etablissement",
                columns: table => new
                {
                    IdEtablissement = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    DesignationEtablissement = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ComplementIdentificationEtablissement = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    NumeroNomVoieEtablissement = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ComplementAdresseEtablissement = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CodePostalEtablissement = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    VilleEtablissement = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    IdEtablissementRattachement = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissement_1", x => x.IdEtablissement);
                    table.ForeignKey(
                        name: "FK_Etablissement_Etablissement",
                        column: x => x.IdEtablissementRattachement,
                        principalTable: "Etablissement",
                        principalColumn: "IdEtablissement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OffreFormation",
                columns: table => new
                {
                    IdOffreFormation = table.Column<int>(type: "int", nullable: false),
                    IdEtablissement = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    DateDebutOffreFormation = table.Column<DateTime>(type: "date", nullable: false),
                    DateFinOffreFormation = table.Column<DateTime>(type: "date", nullable: false),
                    IdPersonne = table.Column<int>(type: "int", nullable: true),
                    IdProduitFormation = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffreFormation", x => new { x.IdOffreFormation, x.IdEtablissement });
                    table.ForeignKey(
                        name: "FK_OffreFormation_Etablissement",
                        column: x => x.IdEtablissement,
                        principalTable: "Etablissement",
                        principalColumn: "IdEtablissement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etablissement_IdEtablissementRattachement",
                table: "Etablissement",
                column: "IdEtablissementRattachement");

            migrationBuilder.CreateIndex(
                name: "IX_OffreFormation_IdEtablissement",
                table: "OffreFormation",
                column: "IdEtablissement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OffreFormation");

            migrationBuilder.DropTable(
                name: "Etablissement");
        }
    }
}
