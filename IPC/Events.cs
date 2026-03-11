using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Enums;
using LociApi.Helpers;

namespace LociApi.Ipc;

/// <inheritdoc cref="ILociApiEvents.GetEventList" />
public sealed class GetEventList(IDalamudPluginInterface pi) : FuncSubscriber<Dictionary<Guid, string>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetEventList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetEventList"u8;

    /// <inheritdoc cref="ILociApiEvents.GetEventList" />
    public new Dictionary<Guid, string> Invoke()
    {
        return base.Invoke();
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Dictionary<Guid, string>> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<Dictionary<Guid, string>>(pi, Label, api.GetEventList);
    }
}

/// <inheritdoc cref="ILociApiEvents.GetEventInfo" />
public sealed class GetEventInfo(IDalamudPluginInterface pi) : FuncSubscriber<Guid, (int, LociEventInfo)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetEventInfo)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetEventInfo"u8;

    /// <inheritdoc cref="ILociApiEvents.GetEventInfo" />
    public new (LociApiEc, LociEventInfo) Invoke(Guid guid)
    {
        var (ec, info) = base.Invoke(guid);
        return ((LociApiEc)ec, info);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (int, LociEventInfo)> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<Guid, (int, LociEventInfo)>(pi, Label, a =>
        {
            var (ec, info) = api.GetEventInfo(a);
            return ((int)ec, info);
        });
    }
}

/// <inheritdoc cref="ILociApiEvents.GetEventInfoList" />
public sealed class GetEventInfoList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociEventInfo>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetEventInfoList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetEventInfoList"u8;

    /// <inheritdoc cref="ILociApiEvents.GetEventInfoList" />
    public new List<LociEventInfo> Invoke()
    {
        return base.Invoke();
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociEventInfo>> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<List<LociEventInfo>>(pi, Label, api.GetEventInfoList);
    }
}

/// <inheritdoc cref="ILociApiEvents.GetEventSummary" />
public sealed class GetEventSummary(IDalamudPluginInterface pi) : FuncSubscriber<Guid, (int, LociEventSummary)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetEventSummary)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetEventSummary"u8;

    /// <inheritdoc cref="ILociApiEvents.GetEventSummary" />
    public new (LociApiEc, LociEventSummary) Invoke(Guid guid)
    {
        var (ec, summary) = base.Invoke(guid);
        return ((LociApiEc)ec, summary);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, (int, LociEventSummary)> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<Guid, (int, LociEventSummary)>(pi, Label, a =>
        {
            var (ec, summary) = api.GetEventSummary(a);
            return ((int)ec, summary);
        });
    }
}

/// <inheritdoc cref="ILociApiEvents.GetEventSummaryList" />
public sealed class GetEventSummaryList(IDalamudPluginInterface pi) : FuncSubscriber<List<LociEventSummary>>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(GetEventSummaryList)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.GetEventSummaryList"u8;

    /// <inheritdoc cref="ILociApiEvents.GetEventSummaryList" />
    public new List<LociEventSummary> Invoke()
    {
        return base.Invoke();
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<LociEventSummary>> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<List<LociEventSummary>>(pi, Label, api.GetEventSummaryList);
    }
}

/// <inheritdoc cref="ILociApiEvents.CreateEvent" />
public sealed class CreateEvent(IDalamudPluginInterface pi) : FuncSubscriber<string, string, LociEventType, Guid>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(CreateEvent)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.CreateEvent"u8;

    /// <inheritdoc cref="ILociApiEvents.CreateEvent" />
    public new Guid Invoke(string eventName, string eventData, LociEventType eventType)
    {
        return base.Invoke(eventName, eventData, eventType);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<string, string, LociEventType, Guid> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<string, string, LociEventType, Guid>(pi, Label, api.CreateEvent);
    }
}

/// <inheritdoc cref="ILociApiEvents.DeleteEvent" />
public sealed class DeleteEvent(IDalamudPluginInterface pi) : FuncSubscriber<Guid, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(DeleteEvent)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.DeleteEvent"u8;

    /// <inheritdoc cref="ILociApiEvents.DeleteEvent" />
    public new LociApiEc Invoke(Guid eventId)
    {
        return (LociApiEc)base.Invoke(eventId);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, int> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<Guid, int>(pi, Label, a => (int)api.DeleteEvent(a));
    }
}

/// <inheritdoc cref="ILociApiEvents.SetEventState" />
public sealed class SetEventState(IDalamudPluginInterface pi) : FuncSubscriber<Guid, bool, int>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(SetEventState)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.SetEventState"u8;

    /// <inheritdoc cref="ILociApiEvents.SetEventState" />
    public new LociApiEc Invoke(Guid eventId, bool newState)
    {
        return (LociApiEc)base.Invoke(eventId, newState);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<Guid, bool, int> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<Guid, bool, int>(pi, Label, (a, b) => (int)api.SetEventState(a, b));
    }
}

/// <inheritdoc cref="ILociApiEvents.SetEventStates" />
public sealed class SetEventStates(IDalamudPluginInterface pi) : FuncSubscriber<List<Guid>, bool, (int, List<Guid>)>(pi, Label)
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(SetEventStates)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.SetEventStates"u8;

    /// <inheritdoc cref="ILociApiEvents.SetEventStates" />
    public new (LociApiEc, List<Guid>) Invoke(List<Guid> eventIds, bool newState)
    {
        var (ec, failed) = base.Invoke(eventIds, newState);
        return ((LociApiEc)ec, failed);
    }

    /// <summary> Create a provider. </summary>
    public static FuncProvider<List<Guid>, bool, (int, List<Guid>)> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new FuncProvider<List<Guid>, bool, (int, List<Guid>)>(pi, Label, (a, b) =>
        {
            List<Guid> failed;
            var ec = api.SetEventStates(a, b, out failed);
            return ((int)ec, failed);
        });
    }
}

/// <inheritdoc cref="ILociApiEvents.EventUpdated" />
public static class EventUpdated
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(EventUpdated)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.EventUpdated"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<Guid, bool> Subscriber(IDalamudPluginInterface pi, params Action<Guid, bool>[] actions)
    {
        return new EventSubscriber<Guid, bool>(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider<Guid, bool> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new EventProvider<Guid, bool>(pi, Label, t => api.EventUpdated += t.Invoke, t => api.EventUpdated -= t.Invoke);
    }
}

/// <inheritdoc cref="ILociApiEvents.EventPathMoved" />
public static class EventPathMoved
{
    /// <summary> The label. </summary>
    public const string Label = $"Loci.{nameof(EventPathMoved)}";

    /// <summary> The label as a UTF8 string. </summary>
    public static ReadOnlySpan<byte> LabelU8 => "Loci.EventPathMoved"u8;

    /// <summary> Create a new event subscriber. </summary>
    public static EventSubscriber<Guid, string, string> Subscriber(IDalamudPluginInterface pi, params Action<Guid, string, string>[] actions)
    {
        return new EventSubscriber<Guid, string, string>(pi, Label, actions);
    }

    /// <summary> Create a provider. </summary>
    public static EventProvider<Guid, string, string> Provider(IDalamudPluginInterface pi, ILociApiEvents api)
    {
        return new EventProvider<Guid, string, string>(pi, Label, t => api.EventPathMoved += t.Invoke, t => api.EventPathMoved -= t.Invoke);
    }
}
