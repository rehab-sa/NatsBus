using System.Collections.Immutable;
using System.Reflection;

namespace NatsBus;

public record Options(
  int ConnectionConcurrency,
  int ProcessingConcurrency,
  //
  ImmutableArray<Stream> IncomingStreams,
  ImmutableArray<Stream> OutgoingStreams,
  SchedulingStream SchedulingStream,
  //
  ImmutableArray<Handler> MessageHandlers,
  Func<Type, string> GetSubjectFromType,
  Func<string, Type> GetTypeFromSubject,
  //
  int IncomingMaxBatchSize,
  int OutgoingMaxBatchSize
);

public record struct Stream(string Name, ImmutableArray<string> Subjects);

public record struct SchedulingStream(string Name, string SubjectsPrefix);

public record struct Handler(Type MessageType, MethodInfo HandlerMethod);
