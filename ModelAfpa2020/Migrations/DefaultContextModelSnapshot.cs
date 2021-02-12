﻿// <auto-generated />
using System;
using DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ModelAfpa2020.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "French_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelAfpa.Etablissement", b =>
                {
                    b.Property<string>("IdEtablissement")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength(true);

                    b.Property<string>("CodePostalEtablissement")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength(true);

                    b.Property<string>("ComplementAdresseEtablissement")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ComplementIdentificationEtablissement")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DesignationEtablissement")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("IdEtablissementRattachement")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength(true);

                    b.Property<string>("NumeroNomVoieEtablissement")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VilleEtablissement")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdEtablissement")
                        .HasName("PK_Etablissement_1");

                    b.HasIndex("IdEtablissementRattachement");

                    b.ToTable("Etablissement");
                });

            modelBuilder.Entity("ModelAfpa.OffreFormation", b =>
                {
                    b.Property<int>("IdOffreFormation")
                        .HasColumnType("int");

                    b.Property<string>("IdEtablissement")
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength(true);

                    b.Property<DateTime>("DateDebutOffreFormation")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateFinOffreFormation")
                        .HasColumnType("date");

                    b.Property<int?>("IdPersonne")
                        .HasColumnType("int");

                    b.Property<string>("IdProduitFormation")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .IsFixedLength(true);

                    b.HasKey("IdOffreFormation", "IdEtablissement");

                    b.HasIndex("IdEtablissement");

                    b.ToTable("OffreFormation");
                });

            modelBuilder.Entity("ModelAfpa.Utilisateur", b =>
                {
                    b.Property<int>("IdUtilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Logging")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Passworld")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("IdUtilisateur");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("ModelAfpa.Etablissement", b =>
                {
                    b.HasOne("ModelAfpa.Etablissement", "IdEtablissementRattachementNavigation")
                        .WithMany("InverseIdEtablissementRattachementNavigation")
                        .HasForeignKey("IdEtablissementRattachement")
                        .HasConstraintName("FK_Etablissement_Etablissement");

                    b.Navigation("IdEtablissementRattachementNavigation");
                });

            modelBuilder.Entity("ModelAfpa.OffreFormation", b =>
                {
                    b.HasOne("ModelAfpa.Etablissement", "IdEtablissementNavigation")
                        .WithMany("OffreFormations")
                        .HasForeignKey("IdEtablissement")
                        .HasConstraintName("FK_OffreFormation_Etablissement")
                        .IsRequired();

                    b.Navigation("IdEtablissementNavigation");
                });

            modelBuilder.Entity("ModelAfpa.Etablissement", b =>
                {
                    b.Navigation("InverseIdEtablissementRattachementNavigation");

                    b.Navigation("OffreFormations");
                });
#pragma warning restore 612, 618
        }
    }
}
