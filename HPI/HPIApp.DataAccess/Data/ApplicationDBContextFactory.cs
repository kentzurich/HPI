using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;

namespace HPIApp.DataAccess.Data
{
    public class ApplicationDBContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            string hostingEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //appsettings JSON Path depends on where it is saved.
            string JsonFilePath = $"C:\\Users\\kentz\\Documents\\GitHub\\HPI\\HPI\\HPIApp\\appsettings.{hostingEnvironment}.json";
            //Name of project file.
            string MigrationAssembly = "HPIApp.DataAccess";
            //Connection string name in appsettings.json
            string ConnectionString = "DefaultConnection";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(JsonFilePath)
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            var connectionString = configuration.GetConnectionString(ConnectionString);
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(MigrationAssembly));

            return new ApplicationDBContext(builder.Options);
        }
    }
}
