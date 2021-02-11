using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelAfpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions options) : base(options)
        {
        }

        protected DefaultContext()
        {
        }

        public static readonly ILoggerFactory Consignation = LoggerFactory.Create(builder =>
        {
            builder.AddFilter("DbLoggerCategory.Database.Command.Name",
                LogLevel.Information);
            builder.AddDebug();
            builder.AddConsole();
        });

        public DbSet<Etablissement> etablissements { get; set; }
        public DbSet<OffreFormation> offreFormations { get; set; }
    }
}
