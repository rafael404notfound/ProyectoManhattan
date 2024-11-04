using Domain.Entities;

namespace ProyectoManahttan.Domain.ValueTypes
{
    public class PendingReport
    {
        public List<Brand> Brands {get; set; }
        public string ReportName { get; set; }
        public Report Result { get; set; }
    }
}
