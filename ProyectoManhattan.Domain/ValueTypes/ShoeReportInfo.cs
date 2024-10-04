using Domain.Entities;

namespace Domain.ValueTypes 
{
    public class ShoeReportInfo 
    {
        public int? Id { get; set; }
        public int? ShoeId { get; set; }
        public string? Ean { get; set; }
        public string? Matnr { get; set; }
        public string? Reference { get; set; }
        public string? BrandSapName { get; set; }
        public int Size { get; set; }
        public int Parking { get; set; }
        public int Total { get; set; }
        public int Missing { get; set; }
        public int Surplus { get; set; }

        public ShoeReportInfo(){}
        public ShoeReportInfo (Shoe shoe, int parking, int total, int missing, int surplus)
        {
            ShoeId = shoe.Id;
            Ean = shoe.Ean;
            Matnr = shoe.Matnr;
            Reference = shoe.Reference;
            BrandSapName = shoe.BrandSapName;
            Size = shoe.Size;
            Parking = parking;
            Total = total;
            Missing = missing;
            Surplus = surplus;
        }
    }
}