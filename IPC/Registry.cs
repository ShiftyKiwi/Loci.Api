using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Enums;
using LociApi.Helpers;

namespace LociApi.Ipc;

/// <inheritdoc cref="ILociApiRegistry.RegisterByPtr" />
public sealed class RegisterByPtr(IDalamudPluginInterface pi) : FuncSubscriber<nint, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RegisterByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RegisterByPtr"u8;

    /// <inheritdoc cref="ILociApiRegistry.RegisterByPtr" />
    public new LociApiEc Invoke(nint address, string hostLabel)
    {
        return (LociApiEc)base.Invoke(address, hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<nint, string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<IntPtr, string, int>(pi, Label, (a, b) => (int)api.RegisterByPtr(a, b));
    }
}

/// <inheritdoc cref="ILociApiRegistry.RegisterByName" />
public sealed class RegisterByName(IDalamudPluginInterface pi) : FuncSubscriber<string, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RegisterByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RegisterByName"u8;

    /// <inheritdoc cref="ILociApiRegistry.RegisterByName" />
    public LociApiEc Invoke(string charaNameWorld, string hostLabel)
    {
        return (LociApiEc)base.Invoke(charaNameWorld, string.Empty, hostLabel);
    }

    /// <inheritdoc cref="ILociApiRegistry.RegisterByName" />
    public new LociApiEc Invoke(string charaName, string buddyName, string hostLabel)
    {
        return (LociApiEc)base.Invoke(charaName, buddyName, hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<string, string, string, int>(pi, Label, (a, b, c) => (int)api.RegisterByName(a, b, c));
    }
}

/// <inheritdoc cref="ILociApiRegistry.UnregisterByPtr" />
public sealed class UnregisterByPtr(IDalamudPluginInterface pi) : FuncSubscriber<nint, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnregisterByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnregisterByPtr"u8;

    /// <inheritdoc cref="ILociApiRegistry.UnregisterByPtr" />
    public new LociApiEc Invoke(nint address, string hostLabel)
    {
        return (LociApiEc)base.Invoke(address, hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<nint, string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<IntPtr, string, int>(pi, Label, (a, b) => (int)api.UnregisterByPtr(a, b));
    }
}

/// <inheritdoc cref="ILociApiRegistry.UnregisterByName" />
public sealed class UnregisterByName(IDalamudPluginInterface pi) : FuncSubscriber<string, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnregisterByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnregisterByName"u8;

    /// <inheritdoc cref="ILociApiRegistry.UnregisterByName" />
    public LociApiEc Invoke(string charaNameWorld, string hostLabel)
    {
        return (LociApiEc)base.Invoke(charaNameWorld, string.Empty, hostLabel);
    }

    /// <inheritdoc cref="ILociApiRegistry.UnregisterByName" />
    public new LociApiEc Invoke(string charaName, string buddyName, string hostLabel)
    {
        return (LociApiEc)base.Invoke(charaName, buddyName, hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<string, string, string, int>(pi, Label, (a, b, c) => (int)api.UnregisterByName(a, b, c));
    }
}

/// <inheritdoc cref="ILociApiRegistry.UnregisterAll" />
public sealed class UnregisterAll(IDalamudPluginInterface pi) : FuncSubscriber<string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnregisterAll)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnregisterAll"u8;

    /// <inheritdoc cref="ILociApiRegistry.UnregisterAll" />
    public new int Invoke(string hostLabel)
    {
        return base.Invoke(hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<string, int>(pi, Label, api.UnregisterAll);
    }
}

/// <inheritdoc cref="ILociApiRegistry.GetHostsByPtr" />
public sealed class GetHostsByPtr(IDalamudPluginInterface pi) : FuncSubscriber<nint, List<string>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetHostsByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetHostsByPtr"u8;

    /// <inheritdoc cref="ILociApiRegistry.GetHostsByPtr" />
    public new List<string> Invoke(nint address)
    {
        return base.Invoke(address);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<nint, List<string>> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<IntPtr, List<string>>(pi, Label, api.GetHostsByPtr);
    }
}

/// <inheritdoc cref="ILociApiRegistry.GetHostsByName" />
public sealed class GetHostsByName(IDalamudPluginInterface pi) : FuncSubscriber<string, string, List<string>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetHostsByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetHostsByName"u8;

    /// <inheritdoc cref="ILociApiRegistry.GetHostsByName" />
    public List<string> Invoke(string charaNameWorld)
    {
        return base.Invoke(charaNameWorld, string.Empty);
    }

    /// <inheritdoc cref="ILociApiRegistry.GetHostsByName" />
    public new List<string> Invoke(string charaName, string buddyName)
    {
        return base.Invoke(charaName, buddyName);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, string, List<string>> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<string, string, List<string>>(pi, Label, api.GetHostsByName);
    }
}

/// <inheritdoc cref="ILociApiRegistry.GetHostActorCount" />
public sealed class GetHostActorCount(IDalamudPluginInterface pi) : FuncSubscriber<string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetHostActorCount)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetHostActorCount"u8;

    /// <inheritdoc cref="ILociApiRegistry.GetHostActorCount" />
    public new int Invoke(string hostLabel)
    {
        return base.Invoke(hostLabel);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, int> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new FuncProvider<string, int>(pi, Label, api.GetHostActorCount);
    }
}

/// <inheritdoc cref="ILociApiRegistry.ActorHostsChanged" />
public static class ActorHostsChanged
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ActorHostsChanged)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ActorHostsChanged"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<nint, string> Subscriber(IDalamudPluginInterface pi, params Action<nint, string>[] actions)
    {
        return new EventSubscriber<IntPtr, string>(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider<nint, string> Provider(IDalamudPluginInterface pi, ILociApiRegistry api)
    {
        return new EventProvider<IntPtr, string>(pi, Label, (t => api.ActorHostsChanged += t, t => api.ActorHostsChanged -= t));
    }
}
