using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoManhattan.Application;
using Domain.ValueTypes;

namespace ProyectoManhattan.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Report> Reports { get; set; }

        void IApplicationDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        async Task IApplicationDbContext.SaveChangesAsync()
        {
            await base.SaveChangesAsync();        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().Property(r => r.CalculationTime).HasColumnType("decimal(18,2)");
        }
    }
}
