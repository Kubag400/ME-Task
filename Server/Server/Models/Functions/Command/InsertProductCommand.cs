using FluentResults;
using MediatR;

namespace Server.Models.Functions.Command
{
    public class InsertProductCommand : IRequest<Result>
    {
        public required string Name { get; init; }
        public required string Code { get; init; }
        public double Price { get; init; }
    }
}
