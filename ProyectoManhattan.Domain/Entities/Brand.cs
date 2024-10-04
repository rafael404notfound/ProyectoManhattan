using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand
    {
        public int? Id { get; set; }
        public string? DisplayName { get; set; } = string.Empty;
        public string? SapName { get; set; } = string.Empty;
        public string? Uneco { get; set; }
        public List<ShoeModel> ShoeModels { get; set; } = new List<ShoeModel>();
    }
}
