using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Dto
{
    public class CalculateMissingShoesDto
    {
        public List<ShoeModel> ScannedShoeModels { get; set; } = new List<ShoeModel>();
        public List<ShoeModel> MissingShoeModels { get; set; } = new List<ShoeModel>();
        public List<ShoeModel> TotalShoeModels { get; set; } = new List<ShoeModel>();
        public List<ShoeModel> SurplusShoeModels { get; set; } = new List<ShoeModel>();
        public bool ScannedAtParking { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
