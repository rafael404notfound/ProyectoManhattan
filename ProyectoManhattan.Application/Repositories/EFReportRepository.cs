using Domain.Entities;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System.Linq;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace ProyectoManhattan.Application
{
    public class EFReportRepository : IReportRepo
    {
        IApplicationDbContext DbContext;
        public EFReportRepository(IApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(Report entity)
        {
            
            DbContext.Reports.Add(entity);
            DbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var report = DbContext.Reports.Include(r => r.BrandReportInfos).ThenInclude(bri => bri.ShoeModelReportInfos).ThenInclude(s => s.ShoeReportInfos)
                .FirstOrDefault(bri => bri.Id == id);
            DbContext.Reports.Remove(report);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Report> Get(int id)
        {
            return await DbContext.Reports.Include(r => r.BrandReportInfos).ThenInclude(bri => bri.ShoeModelReportInfos).ThenInclude(s => s.ShoeReportInfos)
                .FirstOrDefaultAsync(b => b.Id == id) ?? new Report();
        }

		public IQueryable<Report> GetAll()
        {
            return DbContext.Reports.Include(r => r.BrandReportInfos).ThenInclude(bri => bri.ShoeModelReportInfos).ThenInclude(s => s.ShoeReportInfos);
        }

        public async Task Update(Report entity)
        {
            DbContext.Reports.Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
