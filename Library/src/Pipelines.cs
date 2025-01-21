namespace NatsBus;

internal abstract class Pipeline(IStage[] stages)
{
  public async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    while (!cancellationToken.IsCancellationRequested)
    {
      Context context = new();

      foreach (var stage in stages)
      {
        await stage.InvokeAsync(context, cancellationToken);

        if (cancellationToken.IsCancellationRequested)
        {
          return;
        }
      }
    }
  }
}

internal sealed class IncomingPipeline(
  Receiver receiver,
  Processor processor,
  Acknowledger acknowledger
) : Pipeline([receiver, processor, acknowledger]) { }

internal sealed class OutgoingPipeline(
  Scheduler scheduler,
  Persister persister,
  Sender sender
) : Pipeline([scheduler, persister, sender]) { }
