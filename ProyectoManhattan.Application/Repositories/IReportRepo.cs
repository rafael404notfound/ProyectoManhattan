using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoManhattan.Application
{
    public interface IReportRepo
    {
        public void Create(Report entity);
        public Task Delete(int id);
        public Task<Report> Get(int id);
        public IQueryable<Report> GetAll();
        public Task Update(Report brand);
    }
}
