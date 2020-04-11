using System;

namespace Domain.Aggregates
{
    public interface IAggregates
    {
        Guid Id { get; }
        int Version { get; }
    }
}