namespace NatsBus;

internal sealed class OutgoingPipeline(
  LoadBalancer loadBalancer,
  IServiceProvider serviceProvider
)
{
  public async Task ExecuteAsync(
    IEnumerable<OutgoingMessage> outgoingMessages,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }

  public async Task ExecuteAsync(
    SchedulingMessage schedulingMessage,
    CancellationToken cancellationToken
  )
  {
    throw new NotImplementedException();
  }
}
