namespace Domain.ValueTypes 
{
    public class WebItem
    {
        public string Reference { get; set; } = string.Empty;
        public List<string> Photos { get; set; } = new List<string>();
    }
}