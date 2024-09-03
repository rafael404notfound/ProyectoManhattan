using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class EanAndUnecoDto
    {
        public string Ean { get; set; }
        public string Uneco { get; set; }

        public EanAndUnecoDto(string ean, string uneco)
        {
            Ean = ean;
            Uneco = uneco;
        }
    }
}
