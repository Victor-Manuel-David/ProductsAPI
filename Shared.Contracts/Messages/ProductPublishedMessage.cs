namespace Shared.Contracts.Messages;

public record ProductPublishedMessage(
    string ExternalId,
    string Name,
    decimal Price,
    string Currency,
    DateTime FetchedAtUtc,
    string CorrelationId,
    string Source
);
