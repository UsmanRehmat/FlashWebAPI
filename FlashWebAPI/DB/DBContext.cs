using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace FlashWebAPI.DB
{
    public class DBContext : DbContext
    {
        string connectionString = string.Empty;
        public DBContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration["Logging:Data:DefaultConnection:ConnectionString"]; 
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.InDoorAssemblyLine> InDoorAssemblyLines { get; set; }
        public DbSet<Models.OutDoorAssemblyLine> OutDoorAssemblyLines { get; set; }
        public DbSet<Models.QualityTest> QualityTests { get; set; }
        public DbSet<Models.StationFaults> StationFaults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);

        }

    }
}
