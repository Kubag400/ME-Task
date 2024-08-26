﻿using FluentResults;
using MediatR;

namespace Server.Models.Functions.Command
{
    public class InsertProductCommand : IRequest<Result>
    {
        public string Name { get; init; }
        public string Code { get; init; }
        public double Price { get; init; }
    }
}
