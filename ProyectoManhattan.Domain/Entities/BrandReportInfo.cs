using Domain.Entities;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public class BrandReportInfo
    {   
        public int? Id { get; set; }
        public int? BrandId { get; set; }
        public string? SapName { get; set; }
        public string? DisplayName { get; set; }
        public string? Uneco { get; set; }
        public List<ShoeModelReportInfo> ShoeModelReportInfos { get; set; } = new List<ShoeModelReportInfo>();

        public BrandReportInfo(){}
        public BrandReportInfo(Brand brand)
        {
            BrandId = brand.Id;
            SapName = brand.SapName;
            DisplayName = brand.DisplayName;
            Uneco = brand.Uneco;
        }
    }
}