using Domain.Entities;

namespace Domain.Dto
{
    public class StocktakeResultDto
    {
        public Brand? Brand { get; set; }
        public List<string>? Errors { get; set; }
    }
}