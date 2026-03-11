using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///   Events are a future component of Loci that allows statuses and presets to be
///   applied under various conditions. This interface contains all calls associated with it.
/// </summary>
public interface ILociApiEvents
{
    #region Aquisition
    /// <summary>
    ///   Obtain a list of all created LociEvents.
    /// </summary>
    /// <returns> all LociEvents stored into a dictionary of KeyValuePairs using their GUID and title. </returns>
    public Dictionary<Guid, string> GetEventList();

    /// <summary>
    ///   Obtains the details of a LociEvent when provided a valid event <paramref name="guid"/>.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> identifier of the event to look up.</param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociEventInfo) GetEventInfo(Guid guid);

    /// <returns> The list of EventInfo tuples for all created LociEvents. </returns>
    public List<LociEventInfo> GetEventInfoList();

    /// <summary>
    ///   Obtains the summary tuple for a LociEvent, provided a valid event <paramref name="guid"/>.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> identifier of the event to look up.</param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociEventSummary) GetEventSummary(Guid guid);

    /// <returns> The list of EventSummary tuples for all created LociEvents. </returns>
    public List<LociEventSummary> GetEventSummaryList();

    #endregion Aquisition

    // Creates a LociEvent with the given name and type.
    // Returns the GUID of the created event, if successful.
    // eventData, the compressed form of an event can be provided, but if not required.
    public Guid CreateEvent(string eventName, string eventData, LociEventType eventType);

    // Deletes an event given the provided eventId.
    // Returns Success, DataNotFound, DataInvalid.
    public LociApiEc DeleteEvent(Guid eventId);

    // Sets the enabled state of an event, allowing it to be monitored for satisfying conditions.
    public LociApiEc SetEventState(Guid eventId, bool newState);
    public LociApiEc SetEventStates(List<Guid> eventIds, bool newState, out List<Guid> failed);


    public event EventUpdatedDelegate? EventUpdated;

    // Fires whenever an event moved locations in the CKFS. Provides the new path.
    // (Can revise to handle in bulk or change to be a generic action without params to act as a notifier
    public event Action<Guid, string, string>? EventPathMoved;
}
