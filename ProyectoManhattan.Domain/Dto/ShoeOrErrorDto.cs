using Domain.Entities;

namespace Domain.Dto
{
    public class ShoeOrErrorDto
    {
        public Shoe? Shoe { get; set; }
        public string? Error { get; set; }
    }
}
