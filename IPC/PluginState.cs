using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Helpers;

namespace LociApi.IPC;

/// <inheritdoc cref="ILociApiBase.ApiVersion"/>
public sealed class ApiVersion(IDalamudPluginInterface pi)
    : FuncSubscriber<(int, int)>(pi, Label)
{
    public const string Label = $"Loci.{nameof(ApiVersion)}";

    public new (int Major, int Minor) Invoke()
        => base.Invoke();

    public static FuncProvider<(int, int)> Provider(IDalamudPluginInterface pi, ILociApiBase api)
        => new(pi, Label, () => api.ApiVersion);
}

/// <summary>
///   Triggered when the Loci API is initialized and ready.
/// </summary>
public static class Initialized
{
    public const string Label = $"Loci.{nameof(Initialized)}";

    public static EventSubscriber Subscriber(IDalamudPluginInterface pi, params Action[] actions)
        => new EventSubscriber(pi, Label, actions);

    public static EventProvider Provider(IDalamudPluginInterface pi)
        => new EventProvider(pi, Label);
}

/// <summary>
///   Triggered when the Loci API is fully disposed and unavailable.
/// </summary>
public static class Disposed
{
    public const string Label = $"Loci.{nameof(Disposed)}";

    public static EventSubscriber Subscriber(IDalamudPluginInterface pi, params Action[] actions)
        => new EventSubscriber(pi, Label, actions);

    public static EventProvider Provider(IDalamudPluginInterface pi)
        => new EventProvider(pi, Label);
}
