using LociApi.Enums;
namespace LociApi.Api;

/// <summary>
///   All related interactions with statuses.
/// </summary>
public interface ILociApiStatuses
{
    #region Aquisition
    /// <summary>
    ///   Obtains the details of a LociStatus when provided a valid status <paramref name="guid"/>.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> identifier of the status to look up.</param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociStatusInfo) GetStatusInfo(Guid guid);

    /// <returns> The list of LociStatusInfo tuples for all created Statuses. </returns>
    public List<LociStatusInfo> GetStatusInfoList();

    /// <summary>
    ///     Obtain the summary tuple for a LociStatus, Containing the ID, FileSystemPath, IconID, Name, and Description.
    /// </summary>
    /// <param name="guid"> The <see cref="Guid"/> identifier of the status to look up.</param>
    /// <returns><see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociStatusSummary) GetStatusSummary(Guid guid);

    /// <returns> The list of LociStatusSummary tuples for all created Statuses. </returns>
    public List<LociStatusSummary> GetStatusSummaryList();

    #endregion Aquisition

    // Should apply regardless of client render state.
    // Applies one or more statuses to the Client by its GUID. This can be locked.
    // Possible EC: Success, NoChange, DataNotFound, DataInvalid, StatusLocked, InvalidKey
    public LociApiEc ApplyStatus(Guid statusId, uint key);
    public LociApiEc ApplyStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    // Should apply regardless of client render state.
    // Applies one or more statuses to the Client by their StatusInfo tuple. This can be locked.
    // Possible EC: Success, NoChange, DataInvalid, StatusLocked, InvalidKey
    public LociApiEc ApplyStatusInfo(LociStatusInfo statusInfo, uint key);
    public LociApiEc ApplyStatusInfos(List<LociStatusInfo> statusInfos, uint key);

    // **Will only apply when pointer target is valid.**
    // Calls can be done to any valid StatusManager by pointer.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, StatusLocked
    public LociApiEc ApplyStatusByPtr(Guid statusId, nint address);
    public LociApiEc ApplyStatusesByPtr(List<Guid> statusIds, nint address, out List<Guid> failed);

    // **Will only apply when render target is valid. Even if it is by name**
    // Applies one or more statuses by GUID to the target player or owned object by name.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, StatusLocked
    public LociApiEc ApplyStatusByName(Guid statusId, string charaName, string buddyName);
    public LociApiEc ApplyStatusesByName(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed);

    // Removes one or more statuses from the Client's StatusManager. Providing a key allows unlock on removal.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, (StatusLocked on single)
    public LociApiEc RemoveStatus(Guid statusId, uint key);
    public LociApiEc RemoveStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    // **Will only remove when pointer target is valid.**
    // Calls can be done to any valid StatusManager by pointer.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, (StatusLocked on single)
    public LociApiEc RemoveStatusByPtr(Guid statusId, nint ptr);
    public LociApiEc RemoveStatusesByPtr(List<Guid> statusIds, nint ptr, out List<Guid> failed);

    // **Will only apply when render target is valid. Even if it is by name**
    // Removes or more statuses by GUID to the target player or owned object by name.
    public LociApiEc RemoveStatusByName(Guid statusId, string charaName, string buddyName);
    public LociApiEc RemoveStatusesByName(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed);

    // All lock calls can be done when the client is in any render state.
    #region Locks

    // Return StatusLocked if already locked, and success if we can lock it.
    public LociApiEc CanLock(Guid statusId);

    // Attempt to lock a single status in the Clients StatusManager by GUID.
    // Fails if already locked or ID is not present in Statuses.
    public LociApiEc LockStatus(Guid statusId, uint key);
    public LociApiEc LockStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    // Attempt to unlock one or more statuses with a provided key.
    // Any that fail to unlock are output to the failed list when done in bulk.
    public LociApiEc UnlockStatus(Guid statusId, uint key);
    public LociApiEc UnlockStatuses(List<Guid> statuses, uint key, out List<Guid> failed);

    // Unlock all statuses locked with by the provided key.
    // Returns the total number of statuses unlocked with that key.
    public int UnlockAll(uint key);

    #endregion Locks

    /// <summary>
    ///   Triggers whenever a saved status is modified within the editor.
    /// </summary>
    public event StatusUpdatedDelegate? StatusUpdated;
    
    /// <summary>
    ///   Occurs whenever a status has its ChainTrigger condition met. <para />
    ///   Provides the GUID of the status, the GUID to be chained, and what type of chain the GUID is.
    /// </summary>
    public event ChainTriggerHitDelegate? ChainTriggerHit;

    // Can add other events here as needed later..
}
