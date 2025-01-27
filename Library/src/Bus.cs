namespace NatsBus;

public interface IBus
{
  void Begin(
    Func<CancellationToken, Task> beginPersistence,
    string causationId,
    string? correlationId,
    string? conversationId
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

internal sealed class Bus(OutgoingPipeline outgoingPipeline) : IBus
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
    throw new NotImplementedException();
  }

  public void Request(object message)
  {
    throw new NotImplementedException();
  }

  public void Reply(object message)
  {
    throw new NotImplementedException();
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
