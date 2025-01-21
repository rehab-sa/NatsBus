using System.Collections.Immutable;

namespace NatsBus;

internal record struct IncomingMessage(string Id, string Content);

public record struct OutgoingMessage(string Id, string Content);

internal record struct DeserializedMessage(string Id, object Content);

public record struct ProcessedMessage(
  string Id,
  string CorrelationId,
  ImmutableArray<byte> SequenceNumbers
);

internal record struct SchedulingMessage(
  string Id,
  string BatchId,
  DateTimeOffset Timing // TODO Check if DateTime is better or even NodaTime
);
