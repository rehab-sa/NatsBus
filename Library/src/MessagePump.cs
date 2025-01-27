using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace NatsBus;

internal sealed class MessagePump(
  IOptions<Options> options,
  LoadBalancer loadBalancer,
  IncomingPipeline incomingPipeline
) : BackgroundService
{
  protected override async Task ExecuteAsync(
    CancellationToken cancellationToken
  )
  {
    await loadBalancer.Connect(cancellationToken).ConfigureAwait(false);

    var tasks = Enumerable
      .Range(0, options.Value.ProcessingConcurrency)
      .Select(async _ =>
      {
        while (!cancellationToken.IsCancellationRequested)
        {
          await incomingPipeline.ExecuteAsync(cancellationToken);
        }
      })
      .ToArray();

    await Task.WhenAll(tasks).ConfigureAwait(false);
  }
}
