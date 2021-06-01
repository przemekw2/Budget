// using Core.Entities;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;

using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class BudgetContext : DbContext
    {

        public DbSet<Spend> Spends { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }
        
        private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}