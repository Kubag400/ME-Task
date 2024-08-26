namespace Server.Models
{
    public class ProductEntity
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Code { get; init; }
        public double Price { get; init; }
    }
}
