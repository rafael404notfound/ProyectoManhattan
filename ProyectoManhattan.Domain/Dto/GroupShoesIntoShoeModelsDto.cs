using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class GroupShoesIntoShoeModelsDto
    {
        public List<ShoeModel> ScannedShoeModels { get; set; } = new List<ShoeModel>();
        public List<ShoeModel> TotalShoeModels { get; set; } = new List<ShoeModel>();
    }
}
