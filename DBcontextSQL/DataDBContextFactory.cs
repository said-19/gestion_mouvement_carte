using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GestionMouvementCarte.DBcontextSQL
{
    public class DataDBContextFactory : IDesignTimeDbContextFactory<DataDBContext>
    {
        public DataDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataDBContext>();

            // Charger la configuration (par exemple, depuis appsettings.json)
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Tis");

            optionsBuilder.UseSqlServer(connectionString);

            return new DataDBContext(optionsBuilder.Options);
        }
    }
}
