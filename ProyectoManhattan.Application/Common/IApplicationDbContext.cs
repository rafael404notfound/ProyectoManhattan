using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProyectoManhattan.Application
{
    public interface IApplicationDbContext 
    {
        DbSet<Brand> Brands { get; }
        DbSet<Report> Reports {get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
