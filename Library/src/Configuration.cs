using Microsoft.Extensions.DependencyInjection;

namespace NatsBus;

internal static class Configuration
{
  public static IServiceCollection AddBus(
    this IServiceCollection services,
    Action<Options> configureOptions
  )
  {
    return services
      .Configure(configureOptions)
      .AddScoped<IOutbox, Outbox>()
      .AddHostedService<Service>()
      .AddSingleton<Balancer>()
      .AddSingleton<IncomingPipeline>()
      .AddSingleton<Receiver>()
      .AddSingleton<Processor>()
      .AddSingleton<Acknowledger>()
      .AddSingleton<OutgoingPipeline>()
      .AddSingleton<Scheduler>()
      .AddSingleton<Persister>()
      .AddSingleton<Sender>();
  }
}
