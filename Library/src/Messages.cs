using System.Collections.Immutable;

namespace NatsBus;

public record struct IncomingMessage(
  string Id,
  string CausationId,
  string CorrelationId,
  string ConversationId,
  ImmutableArray<byte> SequenceNumbers,
  string Content
);

public record struct OutgoingMessage(
  string Id,
  string CausationId,
  string CorrelationId,
  string ConversationId,
  ImmutableArray<byte> SequenceNumbers,
  DateTimeOffset Timing,
  string Content
);

internal record struct SchedulingMessage(
  string Id,
  string CausationId,
  DateTimeOffset Timing // TODO Check if DateTime is better or even NodaTime
);

public record struct ProcessedMessage(
  string Id,
  string CorrelationId,
  ImmutableArray<byte> SequenceNumbers
);
