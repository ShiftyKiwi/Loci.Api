using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Enums;
using LociApi.Helpers;

namespace LociApi.Ipc;

/// <inheritdoc cref="ILociApiPresets.GetPresetInfo"/>
public sealed class GetPresetInfo(IDalamudPluginInterface pi)
    : FuncSubscriber<Guid, (LociApiEc, LociPresetInfo)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetPresetInfo)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetPresetInfo"u8;

    /// <inheritdoc cref="ILociApiPresets.GetPresetInfo"/>
    public new (LociApiEc, LociPresetInfo) Invoke(Guid guid)
        => base.Invoke(guid);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (LociApiEc, LociPresetInfo)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, api.GetPresetInfo);
}

/// <inheritdoc cref="ILociApiPresets.GetPresetInfoList"/>
public sealed class GetPresetInfoList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociPresetInfo>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetPresetInfoList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetPresetInfoList"u8;

    /// <inheritdoc cref="ILociApiPresets.GetPresetInfoList"/>
    public new List<LociPresetInfo> Invoke()
        => base.Invoke();

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociPresetInfo>> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, api.GetPresetInfoList);
}

/// <inheritdoc cref="ILociApiPresets.GetPresetSummary"/>
public sealed class GetPresetSummary(IDalamudPluginInterface pi)
    : FuncSubscriber<Guid, (LociApiEc, LociPresetSummary)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetPresetSummary)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetPresetSummary"u8;

    /// <inheritdoc cref="ILociApiPresets.GetPresetSummary"/>
    public new (LociApiEc, LociPresetSummary) Invoke(Guid guid)
        => base.Invoke(guid);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (LociApiEc, LociPresetSummary)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, api.GetPresetSummary);
}

/// <inheritdoc cref="ILociApiPresets.GetPresetSummaryList"/>
public sealed class GetPresetSummaryList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociPresetSummary>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetPresetSummaryList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetPresetSummaryList"u8;

    /// <inheritdoc cref="ILociApiPresets.GetPresetSummaryList"/>
    public new List<LociPresetSummary> Invoke()
        => base.Invoke();

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociPresetSummary>> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, api.GetPresetSummaryList);
}

/// <inheritdoc cref="ILociApiPresets.ApplyPreset"/>
public sealed class ApplyPreset(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPreset)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPreset"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPreset"/>
    public new LociApiEc Invoke(Guid presetId, uint key = 0)
        => (LociApiEc)base.Invoke(presetId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.ApplyPreset(a, b));
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresets"/>
public sealed class ApplyPresets(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresets)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresets"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresets"/>
    public LociApiEc Invoke(List<Guid> presetIds, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, 0);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiPresets.ApplyPresets"/>
    public LociApiEc Invoke(List<Guid> presetIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.ApplyPresets(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetInfo"/>
public sealed class ApplyPresetInfo(IDalamudPluginInterface pi) : FuncSubscriber<LociPresetInfo, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetInfo)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetInfo"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetInfo"/>
    public new LociApiEc Invoke(LociPresetInfo presetInfo, uint key = 0)
        => (LociApiEc)base.Invoke(presetInfo, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<LociPresetInfo, uint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.ApplyPresetInfo(a, b));
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetInfos"/>
public sealed class ApplyPresetInfos(IDalamudPluginInterface pi) : FuncSubscriber<List<LociPresetInfo>, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetInfos)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetInfos"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetInfos"/>
    public new LociApiEc Invoke(List<LociPresetInfo> presetInfos, uint key = 0)
        => (LociApiEc)base.Invoke(presetInfos, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociPresetInfo>, uint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.ApplyPresetInfos(a, b));
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetByPtr"/>
public sealed class ApplyPresetByPtr(IDalamudPluginInterface pi) : FuncSubscriber<Guid, nint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetByPtr"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetByPtr"/>
    public new LociApiEc Invoke(Guid presetId, nint address)
        => (LociApiEc)base.Invoke(presetId, address);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, nint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.ApplyPresetByPtr(a, b));
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetsByPtr"/>
public sealed class ApplyPresetsByPtr(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, nint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetsByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetsByPtr"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetsByPtr"/>
    public LociApiEc Invoke(List<Guid> presetIds, nint address, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, address);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, nint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.ApplyPresetsByPtr(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetByName"/>
public sealed class ApplyPresetByName(IDalamudPluginInterface pi) : FuncSubscriber<Guid, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetByName"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetByName"/>
    public LociApiEc Invoke(Guid presetId, string charaNameWorld)
        => (LociApiEc)base.Invoke(presetId, charaNameWorld, string.Empty);

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetByName"/>
    public new LociApiEc Invoke(Guid presetId, string charaName, string buddyName)
        => (LociApiEc)base.Invoke(presetId, charaName, buddyName);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b, c) => (int)api.ApplyPresetByName(a, b, c));
}

/// <inheritdoc cref="ILociApiPresets.ApplyPresetsByName"/>
public sealed class ApplyPresetsByName(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, string, string, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyPresetsByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyPresetsByName"u8;

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetsByName"/>
    public LociApiEc Invoke(List<Guid> presetIds, string charaNameWorld, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, charaNameWorld, string.Empty);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiPresets.ApplyPresetsByName"/>
    public LociApiEc Invoke(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, charaName, buddyName);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, string, string, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b, c) =>
        {
            var ec = api.ApplyPresetsByName(a, b, c, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.RemovePreset"/>
public sealed class RemovePreset(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePreset)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePreset"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePreset"/>
    public new LociApiEc Invoke(Guid presetId, uint key = 0)
        => (LociApiEc)base.Invoke(presetId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.RemovePreset(a, b));
}

/// <inheritdoc cref="ILociApiPresets.RemovePresets"/>
public sealed class RemovePresets(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePresets)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePresets"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePresets"/>
    public LociApiEc Invoke(List<Guid> presetIds, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, 0);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiPresets.RemovePresets"/>
    public LociApiEc Invoke(List<Guid> presetIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.RemovePresets(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.RemovePresetByPtr"/>
public sealed class RemovePresetByPtr(IDalamudPluginInterface pi) : FuncSubscriber<Guid, nint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePresetByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePresetByPtr"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePresetByPtr"/>
    public new LociApiEc Invoke(Guid presetId, nint ptr)
        => (LociApiEc)base.Invoke(presetId, ptr);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, nint, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) => (int)api.RemovePresetByPtr(a, b));
}

/// <inheritdoc cref="ILociApiPresets.RemovePresetsByPtr"/>
public sealed class RemovePresetsByPtr(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, nint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePresetsByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePresetsByPtr"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePresetsByPtr"/>
    public LociApiEc Invoke(List<Guid> presetIds, nint ptr, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, ptr);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, nint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.RemovePresetsByPtr(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.RemovePresetByName"/>
public sealed class RemovePresetByName(IDalamudPluginInterface pi) : FuncSubscriber<Guid, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePresetByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePresetByName"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePresetByName"/>
    public LociApiEc Invoke(Guid presetId, string charaNameWorld)
        => (LociApiEc)base.Invoke(presetId, charaNameWorld, string.Empty);

    /// <inheritdoc cref="ILociApiPresets.RemovePresetByName"/>
    public new LociApiEc Invoke(Guid presetId, string charaName, string buddyName)
        => (LociApiEc)base.Invoke(presetId, charaName, buddyName);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b, c) => (int)api.RemovePresetByName(a, b, c));
}

/// <inheritdoc cref="ILociApiPresets.RemovePresetsByName"/>
public sealed class RemovePresetsByName(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, string, string, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemovePresetsByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemovePresetsByName"u8;

    /// <inheritdoc cref="ILociApiPresets.RemovePresetsByName"/>
    public LociApiEc Invoke(List<Guid> presetIds, string charaNameWorld, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, charaNameWorld, string.Empty);
        return (LociApiEc)ec;
    }


    /// <inheritdoc cref="ILociApiPresets.RemovePresetsByName"/>
    public LociApiEc Invoke(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(presetIds, charaName, buddyName);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, string, string, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, (a, b, c) =>
        {
            var ec = api.RemovePresetsByName(a, b, c, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiPresets.PresetUpdated"/>
public static class PresetUpdated
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(PresetUpdated)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.PresetUpdated"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<Guid, bool> Subscriber(IDalamudPluginInterface pi, params Action<Guid, bool>[] actions)
        => new(pi, Label, actions);
    /// <summary> Create a provider. </summary>
    public static EventProvider<Guid, bool> Provider(IDalamudPluginInterface pi, ILociApiPresets api)
        => new(pi, Label, t => api.PresetUpdated += t.Invoke, t => api.PresetUpdated -= t.Invoke);
}

