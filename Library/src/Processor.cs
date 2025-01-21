using Microsoft.Extensions.Options;

namespace NatsBus;

internal sealed class Processor(
  IOptions<Options> options,
  IServiceProvider serviceProvider
) : IStage
{
  public async Task InvokeAsync(
    Context context,
    CancellationToken cancellationToken
  ) => throw new NotImplementedException();
}
