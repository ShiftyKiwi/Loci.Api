using LociApi.Enums;

namespace LociApi.Api;

/// <summary> Functions for interacting with the status manager. </summary>
public interface ILociApiStatusManager
{
    // Gets the ClientPlayers Manager. This will always be valid.
    // Can return Success, TargetNotFound, TargetInvalid, DataNotFound
    /// <summary>Get the client player's status manager</summary>
    /// <returns>
    ///     A tuple that contains the status manager as well as an error code indicating the reason for failure, or Success.<br /> (Possible
    ///     <see cref="LociApiEc" /> errors: None)
    /// </returns>
    public (LociApiEc, string?) GetManager();

    /// <summary>Gets a specific object's status manager via pointer lookup.</summary>
    /// <param name="address">the pointer of the object</param>
    /// <returns>
    ///     A tuple that contains the status manager as well as an error code indicating the reason for failure, or Success.<br /> (Possible
    ///     <see cref="LociApiEc" /> errors: TargetNotFound, TargetInvalid, DataNotFound)
    /// </returns>
    public (LociApiEc, string?) GetManagerByPtr(nint address);

    /// <summary>Gets a specific object's status manager via name lookup.</summary>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>
    ///     A tuple that contains the status manager as well as an error code indicating the reason for failure, or Success.<br /> (Possible
    ///     <see cref="LociApiEc" /> errors: TargetNotFound, TargetInvalid, DataNotFound)
    /// </returns>
    public (LociApiEc, string?) GetManagerByName(string charaName, string buddyName);

    // Tuple format. Always returns an empty list on failure.
    // (Can change in the future maybe?)
    /// <summary>Get the client player's custom statuses.</summary>
    /// <returns>The list containing all available statuses.</returns>
    public List<LociStatusInfo> GetManagerInfo();

    /// <summary>Get a manager's status info via pointer lookup</summary>
    /// <param name="ptr">the pointer address.</param>
    /// <returns>The list containing all available statuses. Returns an empty list on failure.</returns>
    public List<LociStatusInfo> GetManagerInfoByPtr(nint ptr);

    /// <summary>Get a manager's status info via name lookup</summary>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>The list containing all available statuses. Returns an empty list on failure.</returns>
    public List<LociStatusInfo> GetManagerInfoByName(string charaName, string buddyName);

    //  Informs with return code how that went.
    // Returns Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, DataInvalid.
    // (Fail if the client and locks are present)
    /// <summary>Attempt to set an actors status manager.</summary>
    /// <param name="base64Data">The status manager data to set</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, DataInvalid.)
    /// </returns>
    public LociApiEc SetManager(string base64Data);

    /// <summary>Attempt to set an actors status manager.</summary>
    /// <param name="address">The pointer address of the player attached to the manager.</param>
    /// <param name="base64Data">The status manager data to set</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, DataInvalid.)
    /// </returns>
    public LociApiEc SetManagerByPtr(nint address, string base64Data);

    /// <summary>Attempt to set an actors status manager.</summary>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <param name="base64Data">The status manager data to set</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, DataInvalid.)
    /// </returns>
    public LociApiEc SetManagerByName(string charaName, string buddyName, string base64Data);

    // Same rules as above, but for clearing.
    // For clearing, if the client, do not clear locked statuses, but allow method?
    /// <summary>Converts the legacy StatusManager format in base64 to Loci's data format.
    ///     <para />
    ///     This is intended to help provide conversion compatibility for those using Loci to see sent legacy data, even if it cannot be recipocated.</summary>
    /// <param name="base64Data"> The legacy data formatted base64. </param>
    /// <returns> The converted LociManagerBase64 </returns>
    public string ConvertLegacyData(string base64Data);

    /// <summary>Attempt to clear an actors status manager.</summary>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, DataInvalid.)
    /// </returns>
    public LociApiEc ClearManager();

    /// <summary>Attempt to clear an actors status manager.</summary>
    /// <param name="ptr">The pointer address of the player attached to the manager.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, StatusLocked)
    /// </returns>
    public LociApiEc ClearManagerByPtr(nint ptr);

    /// <summary>Attempt to clear an actors status manager.</summary>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, DataInvalid.)
    /// </returns>
    public LociApiEc ClearManagerByName(string charaName, string buddyName);

    /// <summary> Triggers when an actors StatusManager updates in any way. </summary>
    public event Action<nint> ManagerChanged;

    /// <summary> Triggers when the statuses of a StatusManager are updated in any way. </summary>
    public event ManagerStatusesChangedDelegate? ManagerStatusesChanged;

    /// <summary> Triggered when ApplyToTarget in the Status or Preset tab of Loci is used on a target that is Ephemeral. </summary>
    /// <remarks> This does not fire if applied to a non-ephemeral target. </remarks>
    public event ApplyToTargetDelegate? ApplyToTargetSent;
}
