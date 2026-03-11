using LociApi.Enums;

namespace LociApi;

/// <summary> Used when the statuses in an actors StatusManager change in any way. </summary>
/// <returns> The StatusManagers actor <paramref name="address" />,
///     <para />
///     the <paramref name="statusId" /> that made the change,
///     <para />
///     and what the <paramref name="changeType" /> was. </returns>
public delegate void ManagerStatusesChangedDelegate(nint address, Guid statusId, StatusChangeType changeType);

/// <summary> Used when interacting with the ApplyToTarget button in Loci with a selected host choen. </summary>
/// <returns>
///     The recipient <paramref name="targetAddr" />, the <paramref name="targetHost" /> the application was intended for, and the LociStatusInfo tuple
///     <paramref name="data" /> for application if valid.
///     <para />
/// </returns>
public delegate void ApplyToTargetDelegate(nint targetAddr, string targetHost, List<LociStatusInfo> data);

/// <summary> Used when a status is edited in any way. </summary>
/// <returns> The <paramref name="statusId" /> that changed, and if it <paramref name="wasDeleted" />. </returns>
public delegate void StatusUpdatedDelegate(Guid statusId, bool wasDeleted);

/// <summary> Used when an applied status meets its chain trigger condition, causing a chained action to occur. </summary>
/// <returns> The Actor <paramref name="address" /> of the StatusManager this occured in,
///     <para />
///     the <paramref name="statusId" /> that the chain trigger occured in,
///     <para />
///     the <paramref name="condition" /> that invoked the chain,
///     <para />
///     the <paramref name="chainType" /> indicating the module being chained,
///     <para />
///     and the <paramref name="chainedId" /> from the chainTypes module. </returns>
public delegate void ChainTriggerHitDelegate(nint address, Guid statusId, ChainTrigger condition, ChainType chainType, Guid chainedId);

/// <summary> Used when a preset is edited in any way. </summary>
/// <returns> The <paramref name="presetId" /> that changed, and if it <paramref name="wasDeleted" />. </returns>
public delegate void PresetUpdatedDelegate(Guid presetId, bool wasDeleted);

/// <summary> Used when a loci event is edited in any way. </summary>
/// <returns> The <paramref name="eventId" /> that changed, and if it <paramref name="wasDeleted" />. </returns>
public delegate void EventUpdatedDelegate(Guid eventId, bool wasDeleted);
