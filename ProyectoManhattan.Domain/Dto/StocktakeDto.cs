using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class StocktakeDto
    {
        public string? Name { get; set; }
        public string? Uneco { get; set; }
        public List<EanAndUnecoDto> eanAndUnecoDtos { get; set; } = new List<EanAndUnecoDto>();
    }
}
