using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///   Functions for interacting with statuses.
/// </summary>
public interface ILociApiStatuses
{
    /// <summary>
    /// Get an object representing a single custom status for the current active player.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> identifier of the status to look up.</param>
    /// <returns><see cref="LociApiEc" />:DataInvalid, DataNotFound, Success; along with the <see cref="LociStatusInfo"/> with the provided guid on
    /// successful return.</returns>
    public (LociApiEc, LociStatusInfo) GetStatusInfo(Guid guid);

    /// <summary>
    /// Get a list containing all the current statuses for the current active player
    /// </summary>
    /// <returns>a list of <see cref="LociStatusInfo"/> items on success.</returns>
    public (LociApiEc, List<LociStatusInfo>) GetAllStatusInfo();

    public LociApiEc ApplyStatus(Guid guid);
    public LociApiEc ApplyLockedStatus(Guid guid, uint key);
    public (LociApiEc, object) ApplyStatuses(List<Guid> guids);
    public (LociApiEc, object) ApplyLockedStatuses(List<Guid> guids, uint key);

    public (LociApiEc, object) ApplyStatusInfo(LociStatusInfo statusInfo);
    public LociApiEc ApplyLockedStatusInfo(LociStatusInfo statusInfo, uint key);
    public (LociApiEc, object) ApplyStatusInfos(List<LociStatusInfo> statusInfos);
    public (LociApiEc, object) ApplyLockedStatusInfos(List<LociStatusInfo> statusInfos, uint key);

    public (LociApiEc, object) ApplyStatusByPtr(Guid guid, nint ptr);
    public (LociApiEc, object) ApplyStatusesByPtr(List<Guid> guids, nint ptr);
    public (LociApiEc, object) ApplyStatusByName(Guid guid, string name);
    public (LociApiEc, object) ApplyStatusesByName(List<Guid> guids, nint ptr);

    public LociApiEc RemoveStatus(Guid guid);
    public (LociApiEc, object) RemoveStatuses(List<Guid> guids);
    public LociApiEc RemoveStatusByPtr(Guid guid, nint ptr);
    public (LociApiEc, object) RemoveStatusesByPtr(List<Guid> guids, nint ptr);
    public LociApiEc RemoveStatusByName(Guid guid, string name);
    public (LociApiEc, object) RemoveStatusesByName(List<Guid> guids, string name);

    public LociApiEc LockStatus(Guid status, uint key);
    public LociApiEc LockStatuses(List<Guid> statuses, uint key);
    public LociApiEc UnlockStatus(Guid status, uint key);
    public LociApiEc UnlockStatuses(List<Guid> statuses, uint key);
    public LociApiEc ClearLocks(uint key);
}
