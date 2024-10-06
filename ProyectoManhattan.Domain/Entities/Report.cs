using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.ValueTypes;

namespace Domain.Entities 
{
    public class Report 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        //[DataType("decimal(18,5)")]
        public decimal CalculationTime { get; set; } 
        public bool IsFinished { get; set; } 
        public string? Base64Pdf { get; set; }
        public List<BrandReportInfo> BrandReportInfos { get; set; } = new List<BrandReportInfo>();
    }
}