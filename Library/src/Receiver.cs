using Microsoft.Extensions.Options;

namespace NatsBus;

internal sealed class Receiver(
  IOptions<Options> options,
  Balancer balancer,
  IServiceProvider serviceProvider
) : IStage
{
  public async Task InvokeAsync(
    Context context,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }
}
