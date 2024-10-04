using Domain.Entities;

namespace Domain.ValueTypes 
{
    public class ShoeModelReportInfo 
    {
        public int? Id { get; set; }
        public string? RefWithOutSize { get; set; }
        public int? ShoeModelId { get; set; }
        public string? Uneco { get; set; }
        public string? Family { get; set; }
        public string? Model { get; set; }
        public string? BrandSapName { get; set; }  
        public List<ShoeReportInfo> ShoeReportInfos { get; set; } = new List<ShoeReportInfo>();

        public ShoeModelReportInfo(){}
        public ShoeModelReportInfo(ShoeModel shoeModel, List<ShoeReportInfo> shoeReportInfos)
        {
            RefWithOutSize = shoeModel.RefWithOutSize;
            ShoeModelId = shoeModel.Id;
            Uneco = shoeModel.Uneco;
            Family = shoeModel.Family;
            Model = shoeModel.Model;
            BrandSapName = shoeModel.BrandSapName;
            ShoeReportInfos = shoeReportInfos;
        }
    }
}