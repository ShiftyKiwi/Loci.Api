using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Enums;
using LociApi.Helpers;

namespace LociApi.Ipc;

/// <inheritdoc cref="ILociApiStatuses.GetStatusInfo"/>
public sealed class GetStatusInfo(IDalamudPluginInterface pi)
    : FuncSubscriber<Guid, (LociApiEc, LociStatusInfo)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetStatusInfo)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetStatusInfo"u8;

    /// <inheritdoc cref="ILociApiStatuses.GetStatusInfo"/>
    public new (LociApiEc, LociStatusInfo) Invoke(Guid guid)
        => base.Invoke(guid);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (LociApiEc, LociStatusInfo)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.GetStatusInfo);
}

/// <inheritdoc cref="ILociApiStatuses.GetStatusInfoList"/>
public sealed class GetStatusInfoList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociStatusInfo>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetStatusInfoList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetStatusInfoList"u8;

    /// <inheritdoc cref="ILociApiStatuses.GetStatusInfoList"/>
    public new List<LociStatusInfo> Invoke()
        => base.Invoke();

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociStatusInfo>> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.GetStatusInfoList);
}

/// <inheritdoc cref="ILociApiStatuses.GetStatusSummary"/>
public sealed class GetStatusSummary(IDalamudPluginInterface pi)
    : FuncSubscriber<Guid, (LociApiEc, LociStatusSummary)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetStatusSummary)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetStatusSummary"u8;

    /// <inheritdoc cref="ILociApiStatuses.GetStatusSummary"/>
    public new (LociApiEc, LociStatusSummary) Invoke(Guid guid)
        => base.Invoke(guid);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (LociApiEc, LociStatusSummary)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.GetStatusSummary);
}

/// <inheritdoc cref="ILociApiStatuses.GetStatusSummaryList"/>
public sealed class GetStatusSummaryList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociStatusSummary>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetStatusSummaryList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetStatusSummaryList"u8;

    /// <inheritdoc cref="ILociApiStatuses.GetStatusSummaryList"/>
    public new List<LociStatusSummary> Invoke()
        => base.Invoke();

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociStatusSummary>> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.GetStatusSummaryList);
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatus"/>
public sealed class ApplyStatus(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatus)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatus"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatus"/>
    public new LociApiEc Invoke(Guid statusId, uint key = 0)
        => (LociApiEc)base.Invoke(statusId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.ApplyStatus(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatuses"/>
public sealed class ApplyStatuses(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatuses)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatuses"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, 0);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.ApplyStatuses(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusInfo"/>
public sealed class ApplyStatusInfo(IDalamudPluginInterface pi) : FuncSubscriber<LociStatusInfo, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusInfo)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusInfo"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusInfo"/>
    public new LociApiEc Invoke(LociStatusInfo statusInfo, uint key = 0)
        => (LociApiEc)base.Invoke(statusInfo, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<LociStatusInfo, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.ApplyStatusInfo(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusInfos"/>
public sealed class ApplyStatusInfos(IDalamudPluginInterface pi) : FuncSubscriber<List<LociStatusInfo>, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusInfos)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusInfos"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusInfos"/>
    public new LociApiEc Invoke(List<LociStatusInfo> statusInfos, uint key = 0)
        => (LociApiEc)base.Invoke(statusInfos, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociStatusInfo>, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.ApplyStatusInfos(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusByPtr"/>
public sealed class ApplyStatusByPtr(IDalamudPluginInterface pi) : FuncSubscriber<Guid, nint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusByPtr"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusByPtr"/>
    public new LociApiEc Invoke(Guid statusId, nint address)
        => (LociApiEc)base.Invoke(statusId, address);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, nint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.ApplyStatusByPtr(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusesByPtr"/>
public sealed class ApplyStatusesByPtr(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, nint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusesByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusesByPtr"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusesByPtr"/>
    public LociApiEc Invoke(List<Guid> statusIds, nint address, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, address);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, nint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.ApplyStatusesByPtr(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusByName"/>
public sealed class ApplyStatusByName(IDalamudPluginInterface pi) : FuncSubscriber<Guid, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusByName"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusByName"/>
    public LociApiEc Invoke(Guid statusId, string charaNameWorld)
        => (LociApiEc)base.Invoke(statusId, charaNameWorld, string.Empty);

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusByName"/>
    public new LociApiEc Invoke(Guid statusId, string charaName, string buddyName)
        => (LociApiEc)base.Invoke(statusId, charaName, buddyName);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b, c) => (int)api.ApplyStatusByName(a, b, c));
}

/// <inheritdoc cref="ILociApiStatuses.ApplyStatusesByName"/>
public sealed class ApplyStatusesByName(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, string, string, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ApplyStatusesByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ApplyStatusesByName"u8;

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusesByName"/>
    public LociApiEc Invoke(List<Guid> statusIds, string charaNameWorld, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, charaNameWorld, string.Empty);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiStatuses.ApplyStatusesByName"/>
    public LociApiEc Invoke(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, charaName, buddyName);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, string, string, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b, c) =>
        {
            var ec = api.ApplyStatusesByName(a, b, c, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatus"/>
public sealed class RemoveStatus(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatus)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatus"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatus"/>
    public new LociApiEc Invoke(Guid statusId, uint key = 0)
        => (LociApiEc)base.Invoke(statusId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.RemoveStatus(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatuses"/>
public sealed class RemoveStatuses(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatuses)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatuses"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, 0);
        return (LociApiEc)ec;
    }

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.RemoveStatuses(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatusByPtr"/>
public sealed class RemoveStatusByPtr(IDalamudPluginInterface pi) : FuncSubscriber<Guid, nint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatusByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatusByPtr"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusByPtr"/>
    public new LociApiEc Invoke(Guid statusId, nint ptr)
        => (LociApiEc)base.Invoke(statusId, ptr);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, nint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.RemoveStatusByPtr(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatusesByPtr"/>
public sealed class RemoveStatusesByPtr(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, nint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatusesByPtr)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatusesByPtr"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusesByPtr"/>
    public LociApiEc Invoke(List<Guid> statusIds, nint ptr, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, ptr);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, nint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.RemoveStatusesByPtr(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatusByName"/>
public sealed class RemoveStatusByName(IDalamudPluginInterface pi) : FuncSubscriber<Guid, string, string, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatusByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatusByName"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusByName"/>
    public LociApiEc Invoke(Guid statusId, string charaNameWorld)
        => (LociApiEc)base.Invoke(statusId, charaNameWorld, string.Empty);

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusByName"/>
    public new LociApiEc Invoke(Guid statusId, string charaName, string buddyName)
        => (LociApiEc)base.Invoke(statusId, charaName, buddyName);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, string, string, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b, c) => (int)api.RemoveStatusByName(a, b, c));
}

/// <inheritdoc cref="ILociApiStatuses.RemoveStatusesByName"/>
public sealed class RemoveStatusesByName(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, string, string, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(RemoveStatusesByName)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.RemoveStatusesByName"u8;

    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusesByName"/>
    public LociApiEc Invoke(List<Guid> statusIds, string charaNameWorld, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, charaNameWorld, string.Empty);
        return (LociApiEc)ec;
    }


    /// <inheritdoc cref="ILociApiStatuses.RemoveStatusesByName"/>
    public LociApiEc Invoke(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, charaName, buddyName);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, string, string, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b, c) =>
        {
            var ec = api.RemoveStatusesByName(a, b, c, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.CanLock"/>
public sealed class CanLock(IDalamudPluginInterface pi) : FuncSubscriber<Guid, bool>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(CanLock)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.CanLock"u8;

    /// <inheritdoc cref="ILociApiStatuses.CanLock"/>
    public new bool Invoke(Guid statusId)
        => base.Invoke(statusId);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, bool> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.CanLock);
}

/// <inheritdoc cref="ILociApiStatuses.LockStatus"/>
public sealed class LockStatus(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(LockStatus)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.LockStatus"u8;

    /// <inheritdoc cref="ILociApiStatuses.LockStatus"/>
    public new LociApiEc Invoke(Guid statusId, uint key)
        => (LociApiEc)base.Invoke(statusId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.LockStatus(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.LockStatuses"/>
public sealed class LockStatuses(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(LockStatuses)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.LockStatuses"u8;

    /// <inheritdoc cref="ILociApiStatuses.LockStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.LockStatuses(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.UnlockStatus"/>
public sealed class UnlockStatus(IDalamudPluginInterface pi) : FuncSubscriber<Guid, uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnlockStatus)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnlockStatus"u8;

    /// <inheritdoc cref="ILociApiStatuses.UnlockStatus"/>
    public new LociApiEc Invoke(Guid statusId, uint key = 0)
        => (LociApiEc)base.Invoke(statusId, key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) => (int)api.UnlockStatus(a, b));
}

/// <inheritdoc cref="ILociApiStatuses.UnlockStatuses"/>
public sealed class UnlockStatuses(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, uint, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnlockStatuses)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnlockStatuses"u8;

    /// <inheritdoc cref="ILociApiStatuses.UnlockStatuses"/>
    public LociApiEc Invoke(List<Guid> statusIds, uint key, out List<Guid> failed)
    {
        (var ec, failed) = base.Invoke(statusIds, key);
        return (LociApiEc)ec;
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, uint, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, (a, b) =>
        {
            var ec = api.UnlockStatuses(a, b, out var failed);
            return ((int)ec, failed);
        });
}

/// <inheritdoc cref="ILociApiStatuses.UnlockAll"/>
public sealed class UnlockAll(IDalamudPluginInterface pi) : FuncSubscriber<uint, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(UnlockAll)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.UnlockAll"u8;

    /// <inheritdoc cref="ILociApiStatuses.UnlockAll"/>
    public new int Invoke(uint key)
        => base.Invoke(key);

    /// <summary> Create a provider. </summary>
    public static FuncProvider<uint, int> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.UnlockAll);
}

/// <inheritdoc cref="ILociApiStatuses.StatusUpdated"/>
public static class StatusUpdated
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(StatusUpdated)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.StatusUpdated"u8;
    
    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<Guid, bool> Subscriber(IDalamudPluginInterface pi, params Action<Guid, bool>[] actions)
        => new(pi, Label, actions);
    /// <summary> Create a provider. </summary>
    public static EventProvider<Guid, bool> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, t => api.StatusUpdated += t.Invoke, t => api.StatusUpdated -= t.Invoke);
}

/// <inheritdoc cref="ILociApiStatuses.ChainTriggerHit"/>
public static class ChainTriggerHit
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(ChainTriggerHit)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.ChainTriggerHit"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<nint, Guid, ChainTrigger, ChainType, Guid> Subscriber(IDalamudPluginInterface pi, params Action<nint, Guid, ChainTrigger, ChainType, Guid>[] actions)
        => new(pi, Label, actions);

    /// <summary> Create a provider. </summary>
    public static EventProvider<nint, Guid, ChainTrigger, ChainType, Guid> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, t => api.ChainTriggerHit += t.Invoke, t => api.ChainTriggerHit -= t.Invoke);
}
