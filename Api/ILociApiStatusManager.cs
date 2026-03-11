using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///   Functions for interacting with the status manager.
/// </summary>
public interface ILociApiStatusManager
{
    // Gets the ClientPlayers Manager. This will always be valid.
    // Can return Success, TargetNotFound, TargetInvalid, DataNotFound
    public (LociApiEc, string?) GetManager();
    public (LociApiEc, string?) GetManagerByPtr(nint address);
    public (LociApiEc, string?) GetManagerByName(string charaName, string buddyName);
    
    // Tuple format. Always returns an empty list on failure.
    // (Can change in the future maybe?)
    public List<LociStatusInfo> GetManagerInfo();
    public List<LociStatusInfo> GetManagerInfoByPtr(nint ptr);
    public List<LociStatusInfo> GetManagerInfoByName(string charaName, string buddyName);

    // Attempts to set an actors status manager. Informs with return code how that went.
    // Returns Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, DataInvalid.
    // (Fail if the client and locks are present)
    public LociApiEc SetManager(string base64Data);
    public LociApiEc SetManagerByPtr(nint address, string base64Data);
    public LociApiEc SetManagerByName(string charaName, string buddyName, string base64Data);
    
    // Same rules as above, but for clearing.
    // For clearing, if the client, do not clear locked statuses, but allow method?
    public LociApiEc ClearManager();
    public LociApiEc ClearManagerByPtr(nint ptr);
    public LociApiEc ClearManagerByName(string charaName, string buddyName);

    /// <summary>
    ///   Converts the legacy StatusManager format in base64 to Loci's data format. <para />
    ///   This is intended to help provide conversion compatibility for those using Loci to 
    ///   see sent legacy data, even if it cannot be recipocated.
    /// </summary>
    /// <param name="base64Data"> The legacy data formatted base64. </param>
    /// <returns> The converted LociManagerBase64 </returns>
    public string ConvertLegacyData(string base64Data);

    /// <summary>
    ///   Triggers when an actors StatusManager updates in any way.
    /// </summary>
    public event Action<nint> ManagerChanged;
    
    /// <summary>
    ///   Triggers when the statuses of a StatusManager are updated in any way.
    /// </summary>
    public event ManagerStatusesChangedDelegate? ManagerStatusesChanged;

    /// <summary>
    ///   Triggered when ApplyToTarget in the Status or 
    ///   Preset tab of Loci is used on a target that is Ephemeral.
    /// </summary>
    /// <remarks> This does not fire if applied to a non-ephemeral target. </remarks>
    public event ApplyToTargetDelegate? ApplyToTargetSent;

}
