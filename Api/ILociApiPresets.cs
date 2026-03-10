using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///   Functions for interacting with presets (group of presetes).
/// </summary>
public interface ILociApiPresets
{
    #region Aquisition
    /// <summary>
    ///   Obtains the PresetInfo tuple for the provided <paramref name="guid"/>, if valid.
    /// </summary>
    /// <param name="guid">The <see cref="Guid"/> identifier of the preset to look up.</param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public (LociApiEc, LociPresetInfo) GetPresetInfo(Guid guid);

    /// <returns> The list of LociPresetInfo tuples for all created Presets. </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public List<LociPresetInfo> GetPresetInfoList();

    /// <summary>
    ///     Obtain the PresetSummary tuple for the provided <paramref name="guid"/>, if valid.
    /// </summary>
    /// <param name="guid"> The <see cref="Guid"/> identifier of the preset to look up.</param>
    /// <returns><see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public (LociApiEc, LociPresetSummary) GetPresetSummary(Guid guid);

    /// <returns> The list of PresetSummary tuples for all created Presets. </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public List<LociPresetSummary> GetPresetSummaryList();
    #endregion Aquisition

    // Should apply regardless of client render state.
    // Applies one or more presets to the Client by GUID. This can be locked.
    // Possible EC: Success, NoChange, DataNotFound, DataInvalid, PresetLocked, InvalidKey
    public LociApiEc ApplyPreset(Guid presetId, uint key);
    public LociApiEc ApplyPresets(List<Guid> presetIds, uint key, out List<Guid> failed);

    // Should apply regardless of client render state.
    // Applies one or more presetes to the Client by their PresetInfo tuple. This can be locked.
    // Possible EC: Success, NoChange, DataInvalid, PresetLocked, InvalidKey
    public LociApiEc ApplyPresetInfo(LociPresetInfo presetInfo, uint key);
    public LociApiEc ApplyPresetInfos(List<LociPresetInfo> presetInfos, uint key);


    // **Will only apply when pointer target is valid.**
    // Calls can be done to any valid PresetManager by pointer.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, PresetLocked
    public LociApiEc ApplyPresetByPtr(Guid presetId, nint address);
    public LociApiEc ApplyPresetsByPtr(List<Guid> presetIds, nint address, out List<Guid> failed);

    // **Will only apply when render target is valid. Even if it is by name**
    // Applies one or more presetes by GUID to the target player or owned object by name.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, PresetLocked
    public LociApiEc ApplyPresetByName(Guid presetId, string charaName, string buddyName);
    public LociApiEc ApplyPresetsByName(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed);

    public LociApiEc RemovePreset(Guid presetId, uint key);
    public LociApiEc RemovePresets(List<Guid> presetIds, uint key, out List<Guid> failed);

    public LociApiEc RemovePresetByPtr(Guid presetId, nint address);
    public LociApiEc RemovePresetsByPtr(List<Guid> presetIds, nint address, out List<Guid> failed);

    public LociApiEc RemovePresetByName(Guid presetId, string charaName, string buddyName);
    public LociApiEc RemovePresetsByName(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed);

    /// <summary>
    ///   Triggers whenever a saved preset is modified within the editor.
    /// </summary>
    public event PresetUpdatedDelegate? PresetUpdated;
    // Events can be added here overtime..
}
