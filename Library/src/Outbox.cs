namespace NatsBus;

public interface IOutbox
{
  void Begin(
    Func<CancellationToken, Task> beginPersistence,
    string causationId,
    string correlationId,
    string conversationId
  );
  void Commit(Func<CancellationToken, Task> commitPersistence);
  void Rollback(Func<CancellationToken, Task> rollbackPersistence);
  void Publish(object message);
  void Request(object message);
  void Reply(object message);
  Task PublishAsync(object message, CancellationToken cancellationToken);
  Task RequestAsync(object message, CancellationToken cancellationToken);
  Task ReplyAsync(object message, CancellationToken cancellationToken);
  Task ExtendAsync(TimeSpan duration, CancellationToken cancellationToken);
}

internal sealed class Outbox(OutgoingPipeline pipeline) : IOutbox
{
  private readonly List<object> _messages = [];

  public void Begin(
    Func<CancellationToken, Task> beginPersistence,
    string causationId,
    string correlationId,
    string conversationId
  )
  {
    throw new NotImplementedException();
  }

  public void Commit(Func<CancellationToken, Task> commitPersistence)
  {
    throw new NotImplementedException();
  }

  public void Rollback(Func<CancellationToken, Task> rollbackPersistence)
  {
    throw new NotImplementedException();
  }

  public void Publish(object message)
  {
    _messages.Add(message);
  }

  public void Request(object message)
  {
    _messages.Add(message);
  }

  public void Reply(object message)
  {
    _messages.Add(message);
  }

  public async Task PublishAsync(
    object message,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }

  public async Task RequestAsync(
    object message,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }

  public async Task ReplyAsync(
    object message,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }

  public async Task ExtendAsync(
    TimeSpan duration,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }
}
