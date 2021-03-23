using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class DefaultDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {
            
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var config = builder.Build();


            string connection = config.GetConnectionString("DefaultContext");
            DbContextOptionsBuilder<DefaultContext> optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
            //optionsBuilder.UseSqlServer(connection, b => b.MigrationsAssembly("ModelAfpa2020"))
            //optionsBuilder.UseMySQL(connection)
            optionsBuilder.UseSqlServer(connection)
            .UseLoggerFactory(DefaultContext.Consignation)
            .EnableServiceProviderCaching(false);
            return new DefaultContext(optionsBuilder.Options);
        }
    }
}
