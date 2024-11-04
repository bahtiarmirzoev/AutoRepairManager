using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Microsoft.Extensions.Configuration;
using AutoRepairManagerApp.Infrastructure.Repositories.EfCore.DbContexts;

namespace ToshokanApp.Infrastructure.Repositories.EfCore.DbContexts;

public class AutoRepairDbContextFactory : IDesignTimeDbContextFactory<AutoRepairDbContext>
{
    public AutoRepairDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var builder = new DbContextOptionsBuilder<AutoRepairDbContext>();
        var connectionString = configuration.GetConnectionString("MsSql");

        builder.UseSqlServer(connectionString);

        return new AutoRepairDbContext(builder.Options);
    }
}
