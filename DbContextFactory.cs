using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreTraining
{
    public class ConsoleAppFactory : IDesignTimeDbContextFactory<EFCoreContext>
    {
        public EFCoreContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<EFCoreContext>();
            optionsBuilder
                //.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                //.LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

            return new EFCoreContext(optionsBuilder.Options);
        }
    }

}
