namespace NatsBus;

internal interface IStage
{
  Task InvokeAsync(Context context, CancellationToken cancellationToken);
}
