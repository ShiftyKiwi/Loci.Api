using LociApi.Enums;

namespace LociApi.Api;

/// <summary> All related interactions with statuses. </summary>
public interface ILociApiStatuses
{
    /// <summary>Applies one or more statuses to the Client by its GUID.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, DataInvalid,
    ///     StatusLocked, InvalidKey)
    /// </returns>
    public LociApiEc ApplyStatus(Guid statusId, uint key);

    /// <summary>Applies one or more statuses to the Client by its GUID.</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers to apply</param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <param name="failed">A list of <see cref="Guid" /> identifiers that failed to apply</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, DataInvalid,
    ///     StatusLocked, InvalidKey)
    /// </returns>
    public LociApiEc ApplyStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    // Should apply regardless of the client render state.
    // Applies one or more statuses to the Client by their StatusInfo tuple. This can be locked.
    // Possible EC: Success, NoChange, DataInvalid, StatusLocked, InvalidKey
    /// <summary>Applies one or more statuses to the Client by their StatusInfo tuple.</summary>
    /// <param name="statusInfo">The StatusInfo tuple to apply</param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataInvalid, StatusLocked,
    ///     InvalidKey)
    /// </returns>
    public LociApiEc ApplyStatusInfo(LociStatusInfo statusInfo, uint key);

    /// <summary>Applies one or more statuses to the Client by their StatusInfo tuple.</summary>
    /// <param name="statusInfos">A list of StatusInfo tuples to apply</param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataInvalid, StatusLocked,
    ///     InvalidKey)
    /// </returns>
    public LociApiEc ApplyStatusInfos(List<LociStatusInfo> statusInfos, uint key);


    // **Will only apply when the pointer target is valid.**
    // Calls can be done to any valid StatusManager by the pointer.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, StatusLocked
    /// <summary>Applies one or more statuses to a managed actor via a pointer.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="address">The address of the actor to change.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>This can be called on any valid status manager.</remarks>
    public LociApiEc ApplyStatusByPtr(Guid statusId, nint address);

    /// <summary>Applies one or more statuses to a managed actor via a pointer.</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers to apply.</param>
    /// <param name="address">The address of the actor to change.</param>
    /// <param name="failed">The statuses that failed to apply.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>This can be called on any valid status manager.</remarks>
    public LociApiEc ApplyStatusesByPtr(List<Guid> statusIds, nint address, out List<Guid> failed);

    /// <summary>Applies one or more statuses by GUID to the target player or owned object by name.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>Requires a valid rendered target.</remarks>
    public LociApiEc ApplyStatusByName(Guid statusId, string charaName, string buddyName);

    /// <summary>Applies one or more statuses by GUID to the target player or owned object by name.</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <param name="failed">The statuses that failed to be removed.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>Requires a valid rendered target.</remarks>
    public LociApiEc ApplyStatusesByName(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed);

    /// <summary>Removes one or more statuses from the Client's StatusManager</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="key"> If the status was locked, the correct key must be provided to remove it. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    public LociApiEc RemoveStatus(Guid statusId, uint key);

    /// <summary>Removes one or more statuses from the Client's StatusManager</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="key"> If the status was locked, the correct key must be provided to remove it. </param>
    /// <param name="failed">The statuses that failed to be removed.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    public LociApiEc RemoveStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    // **Will only remove when pointer target is valid.**
    // Calls can be done to any valid StatusManager by pointer.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, (StatusLocked on single)
    /// <summary>Remove one or more statuses via an object's address</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="ptr">The address of the object.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>Any valid status manager can be referenced.</remarks>
    public LociApiEc RemoveStatusByPtr(Guid statusId, nint ptr);

    /// <summary>Remove one or more statuses via an object's address</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="ptr">The address of the object.</param>
    /// <param name="failed">The statuses that failed to be removed.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    /// <remarks>Any valid status manager can be referenced.</remarks>
    public LociApiEc RemoveStatusesByPtr(List<Guid> statusIds, nint ptr, out List<Guid> failed);

    // **Will only apply when render target is valid. Even if it is by name**
    // Removes or more statuses by GUID to the target player or owned object by name.
    /// <summary>Remove one or more statuses by GUID by object name.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    public LociApiEc RemoveStatusByName(Guid statusId, string charaName, string buddyName);

    /// <summary>Remove one or more statuses by GUID by object name.</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <param name="failed">The statuses that failed to be removed.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    public LociApiEc RemoveStatusesByName(List<Guid> statusIds, string charaName, string buddyName, out List<Guid> failed);

    /// <summary> Triggers whenever a saved status is modified within the editor. </summary>
    public event StatusUpdatedDelegate? StatusUpdated;

    /// <summary>Occurs whenever a status has its ChainTrigger condition met.
    ///     <para />
    ///     Provides the GUID of the status, the GUID to be chained, and what type of chain the GUID is.</summary>
    public event ChainTriggerHitDelegate? ChainTriggerHit;

    #region Aquisition

    /// <summary> Obtains the details of a LociStatus when provided a valid status <paramref name="guid" />. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the status to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociStatusInfo) GetStatusInfo(Guid guid);

    /// <summary>
    ///     <seealso cref="GetStatusInfo" />
    /// </summary>
    /// <returns> The list of LociStatusInfo tuples for all created Statuses. </returns>
    public List<LociStatusInfo> GetStatusInfoList();

    /// <summary> Obtain the summary tuple for a LociStatus, Containing the ID, FileSystemPath, IconID, Name, and Description. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the status to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    public (LociApiEc, LociStatusSummary) GetStatusSummary(Guid guid);

    /// <returns> The list of LociStatusSummary tuples for all created Statuses. </returns>
    public List<LociStatusSummary> GetStatusSummaryList();

    #endregion Aquisition

    // All lock calls can be done when the client is in any render state.

    #region Locks

    /// <summary>Check if a status can be locked.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <returns><see langword="true" /> if the status can be locked, or false otherwise. A status that is already locked will also return false.</returns>
    public bool CanLock(Guid statusId);

    /// <summary>Attempt to lock one or more statuses in the Clients StatusManager by GUID.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="key"> Locks the status using the specified key. Must be non-zero. </param>
    /// <returns>An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, StatusLocked)</returns>
    public LociApiEc LockStatus(Guid statusId, uint key);

    /// <summary>Attempt to lock one or more statuses in the Clients StatusManager by GUID.</summary>
    /// <param name="statusIds">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="key"> Locks the statuses using the specified key. Must be non-zero. </param>
    /// <param name="failed">The statuses that failed to lock.</param>
    /// <returns>An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, StatusLocked)</returns>
    public LociApiEc LockStatuses(List<Guid> statusIds, uint key, out List<Guid> failed);

    //
    // Any that fail to unlock are output to the failed list when done in bulk.
    /// <summary>Attempt to unlock one or more statuses with a provided key.</summary>
    /// <param name="statusId">The <see cref="Guid" /> identifier of the status.</param>
    /// <param name="key"> Unlocks the status using the specified key. Must be the key that was provided to lock the status. </param>
    /// <returns>An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, InvalidKey)</returns>
    public LociApiEc UnlockStatus(Guid statusId, uint key);

    /// <summary>Attempt to unlock one or more statuses with a provided key.</summary>
    /// <param name="statuses">A list of <see cref="Guid" /> identifiers.</param>
    /// <param name="key"> Unlocks the status using the specified key. Must be the key that was provided to lock the status. </param>
    /// <param name="failed">The statuses that failed to unlock.</param>
    /// <returns>An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, InvalidKey)</returns>
    public LociApiEc UnlockStatuses(List<Guid> statuses, uint key, out List<Guid> failed);

    /// <summary>Unlock all statuses locked with by the provided key.</summary>
    /// <param name="key">The key being used to unlock.</param>
    /// <returns>The total number of statuses unlocked.</returns>
    public int UnlockAll(uint key);

    #endregion Locks

    // Can add other events here as needed later...
}
