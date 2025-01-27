namespace NatsBus;

public interface IOutbox
{
  Task<IEnumerable<OutgoingMessage>> GetOutgoingMessagesAsync(
    string causationId,
    DateTimeOffset timing,
    CancellationToken cancellationToken
  );

  Task<ProcessedMessage> GetProcessedMessageAsync(
    string correlationId,
    CancellationToken cancellationToken
  );

  Task InsertOutgoingMessagesAsync(
    IEnumerable<OutgoingMessage> messages,
    CancellationToken cancellationToken
  );

  Task DeleteOutgoingMessagesAsync(
    IEnumerable<OutgoingMessage> messages,
    CancellationToken cancellationToken
  );

  Task InsertOrUpdateProcessedMessageAsync(
    ProcessedMessage message,
    CancellationToken cancellationToken
  );
}
