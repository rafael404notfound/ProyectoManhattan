using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoeModel
    {
        public int? Id { get; set; }
        public string? Uneco { get; set; }
        public string? Family { get; set; }
        public string? Model { get; set; }
        public string? RefWithOutSize { get; set; }
        public string? BrandSapName { get; set; }  
        public List<Shoe> Sizes { get; set; } = new List<Shoe>();
    }
}
