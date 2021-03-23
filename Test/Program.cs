using DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using ModelAfpa;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json"); ;

            var config = builder.Build();

            string connection = config.GetConnectionString("DefaultContext");
            DbContextOptionsBuilder optionsBulder = new DbContextOptionsBuilder();
            optionsBulder.UseSqlServer(connection)
                .UseLoggerFactory(DefaultContext.Consignation);

            using (DefaultContext context = new DefaultContext(optionsBulder.Options))
            {
                var query = context.etablissements.ToList();
                foreach (Etablissement item in query )
                {
                    Console.WriteLine(item.DesignationEtablissement + " " + item.VilleEtablissement);
                }
            }
        }
    }
}
