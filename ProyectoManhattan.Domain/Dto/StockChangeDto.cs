using Domain.Dto;
using Domain.ValueTypes;

namespace Domain.Dto{
    public class StockChangeDto{
        public List<EanAndUnecoDto> EanAndUnecoDtos { get; set; } = new List<EanAndUnecoDto>();
        public Operation Operation { get; set; }
    }
}