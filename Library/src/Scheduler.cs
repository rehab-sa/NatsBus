using Microsoft.Extensions.Options;

namespace NatsBus;

internal sealed class Scheduler(IOptions<Options> options, Balancer balancer)
  : IStage
{
  public async Task InvokeAsync(
    Context context,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }
}
