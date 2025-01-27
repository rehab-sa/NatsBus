namespace NatsBus;

internal sealed class IncomingPipeline(
  LoadBalancer loadBalancer,
  OutgoingPipeline outgoingPipeline,
  IServiceProvider serviceProvider
)
{
  public async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
