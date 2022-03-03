using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TruckRegister.Domain.Entities;

namespace TruckRegister.Repository.Data
{
    public class ApplicationContext : DbContext
    {
        private IConfiguration _configuration;
        private const string _defaultConnection = "DefaultConnection";

        public ApplicationContext(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration Configuration) : base(options)
        {
            _configuration = Configuration;
        }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(_configuration.GetConnectionString(_defaultConnection))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}