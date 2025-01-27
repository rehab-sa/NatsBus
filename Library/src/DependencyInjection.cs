using Microsoft.Extensions.DependencyInjection;

namespace NatsBus;

internal static class DependencyInjection
{
  public static IServiceCollection AddNatsBus(
    this IServiceCollection services,
    Action<Options> configureOptions
  )
  {
    return services
      .Configure(configureOptions)
      .AddScoped<IBus, Bus>()
      .AddHostedService<MessagePump>()
      .AddSingleton<LoadBalancer>()
      .AddSingleton<IncomingPipeline>()
      .AddSingleton<OutgoingPipeline>();
  }
}
