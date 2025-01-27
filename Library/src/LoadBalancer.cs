using Microsoft.Extensions.Options;
using NATS.Client.Core;
using NATS.Client.JetStream;

namespace NatsBus;

internal sealed class LoadBalancer(IOptions<Options> options)
{
  private INatsConnection[]? _connections = null;
  private INatsJSContext[]? _jsContexts = null;
  private INatsJSConsumer[]? _jsConsumers = null;
  private INatsJSConsumer[]? _jsSchedulingConsumers = null;

  private int _jsContextsCounter = -1;
  private int _jsConsumersCounter = -1;
  private int _jsSchedulingConsumersCounter = -1;

  public async Task Connect(CancellationToken cancellationToken)
  {
    if (_connections is not null)
    {
      throw new InvalidOperationException();
    }

    _connections =
    [
      .. new NatsConnectionPool(
        options.Value.ConnectionConcurrency
      ).GetConnections(),
    ];

    var jsContextFactory = new NatsJSContextFactory();

    _jsContexts = [.. _connections.Select(jsContextFactory.CreateContext)];

    // TODO Initialize outgoing and scheduling streams

    _jsConsumers = await Task.WhenAll(
        options.Value.IncomingStreams.SelectMany(stream =>
          _jsContexts.Select(jsContext =>
            jsContext
              .CreateOrUpdateConsumerAsync(
                stream.Name,
                new() { FilterSubjects = stream.Subjects },
                cancellationToken
              )
              .AsTask()
          )
        )
      )
      .ConfigureAwait(false);

    _jsSchedulingConsumers = await Task.WhenAll(
        _jsContexts.Select(jsContext =>
          jsContext
            .CreateOrUpdateConsumerAsync(
              options.Value.SchedulingStream.Name,
              new()
              {
                FilterSubject =
                  $"{options.Value.SchedulingStream.SubjectsPrefix}.*",
              },
              cancellationToken
            )
            .AsTask()
        )
      )
      .ConfigureAwait(false);
  }

  public INatsJSContext GetNextJsContext()
  {
    var jsContextIndex =
      Math.Abs(Interlocked.Increment(ref _jsContextsCounter))
      % _jsContexts!.Length;

    return _jsContexts[jsContextIndex];
  }

  public INatsJSConsumer GetNextJsConsumer()
  {
    var jsConsumerIndex =
      Math.Abs(Interlocked.Increment(ref _jsConsumersCounter))
      % _jsConsumers!.Length;

    return _jsConsumers[jsConsumerIndex];
  }

  public INatsJSConsumer GetNextJsSchedulingConsumer()
  {
    var jsSchedulingConsumerIndex =
      Math.Abs(Interlocked.Increment(ref _jsSchedulingConsumersCounter))
      % _jsSchedulingConsumers!.Length;

    return _jsSchedulingConsumers[jsSchedulingConsumerIndex];
  }
}
