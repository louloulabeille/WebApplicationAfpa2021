using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModelAfpa;
using System.IO;


namespace DataContext
{
    public class DefaultContext : DbContext
    {

        protected DefaultContext()
        {
        }
        public DefaultContext(DbContextOptions options) : base(options)
        {
        }
        public static readonly ILoggerFactory Consignation = LoggerFactory.Create(builder =>
        {
            builder.AddFilter("DbLoggerCategory.Database.Command.Name",
                LogLevel.Information);
            builder.AddDebug();
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

                var config = builder.Build();

                string connection = config.GetConnectionString("DefaultContext");
                //optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("ModelAfpa2020"))
                optionsBuilder.UseSqlServer(connection)
                .UseLoggerFactory(Consignation)
                .EnableServiceProviderCaching(false);
            }
        }

        public DbSet<Etablissement> etablissements { get; set; }
        public DbSet<OffreFormation> offreFormations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");
            modelBuilder.Entity<Etablissement>(entity =>
            {
                entity.HasKey(e => e.IdEtablissement)
                    .HasName("PK_Etablissement_1");

                entity.ToTable("Etablissement");

                entity.Property(e => e.IdEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CodePostalEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ComplementAdresseEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementIdentificationEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationEtablissement)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdEtablissementRattachement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NumeroNomVoieEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VilleEtablissement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEtablissementRattachementNavigation)
                    .WithMany(p => p.InverseIdEtablissementRattachementNavigation)
                    .HasForeignKey(d => d.IdEtablissementRattachement)
                    .HasConstraintName("FK_Etablissement_Etablissement");
            });

            modelBuilder.Entity<OffreFormation>(entity =>
            {
                entity.HasKey(e => new { e.IdOffreFormation, e.IdEtablissement });

                entity.ToTable("OffreFormation");

                entity.Property(e => e.IdEtablissement)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateDebutOffreFormation).HasColumnType("date");

                entity.Property(e => e.DateFinOffreFormation).HasColumnType("date");

                entity.Property(e => e.IdProduitFormation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdEtablissementNavigation)
                    .WithMany(p => p.OffreFormations)
                    .HasForeignKey(d => d.IdEtablissement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OffreFormation_Etablissement");

                //entity.HasOne(d => d.IdPersonneNavigation)
                //    .WithMany(p => p.OffreFormations)
                //    .HasForeignKey(d => d.IdPersonne)
                //    .HasConstraintName("FK_OffreFormation_Formateur");

                //entity.HasOne(d => d.IdProduitFormationNavigation)
                //    .WithMany(p => p.OffreFormations)
                //    .HasForeignKey(d => d.IdProduitFormation)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OffreFormation_ProduitDeFormation");
            });
        }
    }
}
