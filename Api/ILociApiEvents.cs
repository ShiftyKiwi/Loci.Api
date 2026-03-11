using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///     Events are a future component of Loci that allows statuses and presets to be applied under various conditions. This interface contains all calls
///     associated with it.
/// </summary>
public interface ILociApiEvents
{
    /// <summary> Creates a LociEvent with the given name and type. </summary>
    /// <returns> Returns the GUID of the created event, if successful. </returns>
    /// <remarks> eventData, the compressed form of an event can be provided, but if not required. </remarks>
    public Guid CreateEvent(string eventName, string eventData, LociEventType eventType);

    /// <summary> Deletes an event given the provided eventId. </summary>
    /// <returns> <see cref="LociApiEc" /> Success, DataNotFound, DataInvalid. </returns>
    public LociApiEc DeleteEvent(Guid eventId);

    /// <summary> Sets the enabled state of an event, allowing it to be monitored for satisfying conditions. </summary>
    /// <returns> <see cref="LociApiEc" />A potential error code or Success. </returns>
    public LociApiEc SetEventState(Guid eventId, bool newState);

    /// <summary> Set multiple event states simultaneously. </summary>
    /// <param name="eventIds"> List of event ids to change </param>
    /// <param name="newState"> the state to change them to </param>
    /// <param name="failed"> Any events that failed to change will be returned here. </param>
    /// <returns> <see cref="LociApiEc" />A potential error code or Success. </returns>
    public LociApiEc SetEventStates(List<Guid> eventIds, bool newState, out List<Guid> failed);


    /// <summary> Fired when an event is updated. </summary>
    public event EventUpdatedDelegate? EventUpdated;

    // (Can revise to handle in bulk or change to be a generic action without params to act as a notifier
    /// <summary> Fired when an event item is moved. </summary>
    public event Action<Guid, string, string>? EventPathMoved;

    #region Aquisition

    /// <summary> Obtain a list of all created LociEvents. </summary>
    /// <returns> all LociEvents stored into a dictionary of KeyValuePairs using their GUID and title. </returns>
    public Dictionary<Guid, string> GetEventList();

    /// <summary> Obtains the details of a LociEvent when provided a valid event <paramref name="guid" />. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the event to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociEventInfo) GetEventInfo(Guid guid);

    /// <returns> The list of EventInfo tuples for all created LociEvents. </returns>
    public List<LociEventInfo> GetEventInfoList();

    /// <summary> Obtains the summary tuple for a LociEvent, provided a valid event <paramref name="guid" />. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the event to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociEventSummary) GetEventSummary(Guid guid);

    /// <summary> Obtains a list of LociEventSummary objects for every event. </summary>
    /// <returns> The list of EventSummary tuples for all created LociEvents. </returns>
    public List<LociEventSummary> GetEventSummaryList();

    #endregion Aquisition
}
