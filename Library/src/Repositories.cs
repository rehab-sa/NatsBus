namespace NatsBus;

public interface IOutgoingMessagesRepository
{
  Task<IEnumerable<OutgoingMessage>> GetBatchAsync(
    string id,
    CancellationToken cancellationToken
  );

  Task InsertBatchAsync(
    IEnumerable<OutgoingMessage> messages,
    CancellationToken cancellationToken
  );

  Task UpdateAsync(
    OutgoingMessage message,
    CancellationToken cancellationToken
  );

  Task DeleteAsync(
    OutgoingMessage message,
    CancellationToken cancellationToken
  );
}

public interface IProcessedMessagesRepository
{
  Task<ProcessedMessage> GetAsync(CancellationToken cancellationToken);

  Task InsertOrUpdateAsync(
    ProcessedMessage message,
    CancellationToken cancellationToken
  );
}
