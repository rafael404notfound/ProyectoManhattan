using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Shoe
    {
        public int? Id { get; set; }
        public string? Ean { get; set; }
        public string? Matnr { get; set; }
        public string? Reference { get; set; }
        public string? BrandSapName { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
    }
}
