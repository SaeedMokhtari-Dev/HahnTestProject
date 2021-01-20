using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Hahn.ApplicationProcess.December2020.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicationProcess.December2020.Data.Persistence
{
    public class HahnContext: DbContext
    {
        public HahnContext(DbContextOptions<HahnContext> options)
            : base(options)
        { }
        
        public DbSet<Employee> Employees;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
        
        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();

            var entries = this.ChangeTracker.Entries<Employee>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                    entry.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}