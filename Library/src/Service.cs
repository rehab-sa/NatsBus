using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace NatsBus;

internal sealed class Service(
  IOptions<Options> options,
  Balancer balancer,
  IncomingPipeline pipeline
) : BackgroundService
{
  protected override async Task ExecuteAsync(
    CancellationToken cancellationToken
  )
  {
    await balancer.Connect(cancellationToken).ConfigureAwait(false);

    var tasks = Enumerable
      .Range(0, options.Value.ProcessingConcurrency)
      .Select(_ => pipeline.ExecuteAsync(cancellationToken))
      .ToArray();

    await Task.WhenAll(tasks).ConfigureAwait(false);
  }
}
