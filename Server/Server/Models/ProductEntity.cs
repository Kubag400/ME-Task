namespace Server.Models
{
    public class ProductEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Code { get; init; }
        public double Price { get; init; }
    }
}
