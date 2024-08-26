namespace Server.Models
{
    public class ProductRequest
    {
        public required string Name { get; init; }
        public required string Code { get; init; }
        public double Price { get; init; }
    }
}
