using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Helpers;

namespace LociApi.Ipc;

/// <inheritdoc cref="ILociApiBase.ApiVersion" />
public sealed class ApiVersion(IDalamudPluginInterface pi)
    : FuncSubscriber<(int, int)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApiVersion)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApiVersion"u8;

    /// <inheritdoc cref="ILociApiBase.ApiVersion" />
    public new (int Major, int Minor) Invoke()
    {
        return base.Invoke();
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<(int, int)> Provider(IDalamudPluginInterface pi, ILociApiBase api)
    {
        return new FuncProvider<(int, int)>(pi, Label, () => api.ApiVersion);
    }
}

/// <inheritdoc cref="ILociApiBase.IsEnabled" />
public sealed class IsEnabled(IDalamudPluginInterface pi)
    : FuncSubscriber<bool>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(IsEnabled)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.IsEnabled"u8;

    /// <inheritdoc cref="ILociApiBase.IsEnabled" />
    public new bool Invoke()
    {
        return base.Invoke();
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<bool> Provider(IDalamudPluginInterface pi, ILociApiBase api)
    {
        return new FuncProvider<bool>(pi, Label, () => api.IsEnabled);
    }
}

/// <inheritdoc cref="ILociApiBase.EnabledStateChanged" />
public static class EnabledStateChanged
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(EnabledStateChanged)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.EnabledStateChanged"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<bool> Subscriber(IDalamudPluginInterface pi, params Action<bool>[] actions)
    {
        return new EventSubscriber<bool>(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider<bool> Provider(IDalamudPluginInterface pi, ILociApiBase api)
    {
        return new EventProvider<bool>(pi, Label, (t => api.EnabledStateChanged += t, t => api.EnabledStateChanged -= t));
    }
}

/// <summary> Triggered when the Loci API has finished initializing and ready. </summary>
public static class Ready
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(Ready)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.Ready"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber Subscriber(IDalamudPluginInterface pi, params Action[] actions)
    {
        return new EventSubscriber(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider Provider(IDalamudPluginInterface pi)
    {
        return new EventProvider(pi, Label);
    }
}

/// <summary> Triggered when the Loci API is fully disposed and unavailable. </summary>
public static class Disposed
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(Disposed)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.Disposed"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber Subscriber(IDalamudPluginInterface pi, params Action[] actions)
    {
        return new EventSubscriber(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider Provider(IDalamudPluginInterface pi)
    {
        return new EventProvider(pi, Label);
    }
}
