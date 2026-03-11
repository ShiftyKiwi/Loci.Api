using LociApi.Enums;

namespace LociApi.Api;

/// <summary> Functions for interacting with presets (group of presets). </summary>
public interface ILociApiPresets
{
    // Should apply regardless of client render state.
    // Applies one or more presets to the Client by GUID. This can be locked.
    // Possible EC: Success, NoChange, DataNotFound, DataInvalid, PresetLocked, InvalidKey
    /// <summary> Applies one or more presets to the client via preset GUID identifier. </summary>
    /// <param name="presetId"> the <see cref="Guid" /> identifier of the preset(s) </param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, DataInvalid,
    ///     PresetLocked, InvalidKey)
    /// </returns>
    /// <remarks> Presets and statuses can be applied regardless of the render state. </remarks>
    public LociApiEc ApplyPreset(Guid presetId, uint key);

    /// <summary> Applies one or more presets to the client via preset GUID identifier. </summary>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <param name="failed"> A list of identifiers representing the statuses that failed to apply </param>
    /// <param name="presetIds"> List of <see cref="Guid" /> preset identifiers </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataNotFound, DataInvalid,
    ///     PresetLocked, InvalidKey)
    /// </returns>
    /// <remarks> Presets and statuses can be applied regardless of the render state. </remarks>
    public LociApiEc ApplyPresets(List<Guid> presetIds, uint key, out List<Guid> failed);

    // Should apply regardless of client render state.
    // Possible EC: Success, NoChange, DataInvalid, PresetLocked, InvalidKey
    /// <summary> Applies one or more presets using a PresetInfo tuple. </summary>
    /// <param name="presetInfo"> The LociPresetInfo tuple to apply </param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataInvalid, PresetLocked,
    ///     InvalidKey)
    /// </returns>
    /// <remarks> Presets and statuses can be applied regardless of the render state. </remarks>
    public LociApiEc ApplyPresetInfo(LociPresetInfo presetInfo, uint key);

    // Should apply regardless of client render state.
    // Possible EC: Success, NoChange, DataInvalid, PresetLocked, InvalidKey
    /// <summary> Applies one or more presets using a PresetInfo tuple. </summary>
    /// <param name="presetInfos"> A list of LociPresetInfo tuples to apply </param>
    /// <param name="key"> If set to anything but 0, the statuses will be <i>locked</i>. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, DataInvalid, PresetLocked,
    ///     InvalidKey)
    /// </returns>
    /// <remarks> Presets and statuses can be applied regardless of the render state. </remarks>
    public LociApiEc ApplyPresetInfos(List<LociPresetInfo> presetInfos, uint key);


    // **Will only apply when pointer target is valid.**
    // Calls can be done to any valid PresetManager by pointer.
    /// <summary> Apply a status preset to another managed character </summary>
    /// <param name="presetId"> The <see cref="Guid" /> preset identifier. </param>
    /// <param name="address"> The address of the managed character </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, PresetLocked)
    /// </returns>
    /// <remarks> Will only apply if the given address refers to a valid managed character. </remarks>
    public LociApiEc ApplyPresetByPtr(Guid presetId, nint address);

    /// <summary> Apply a multiple status presets to another managed character </summary>
    /// <param name="presetIds"> A list of <see cref="Guid" /> preset identifiers. </param>
    /// <param name="address"> The address of the managed character </param>
    /// <param name="failed"> A list of <see cref="Guid" /> identifiers that did not get applied. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, PresetLocked)
    /// </returns>
    /// <remarks> Will only apply if the given address refers to a valid managed character. </remarks>
    public LociApiEc ApplyPresetsByPtr(List<Guid> presetIds, nint address, out List<Guid> failed);

    // **Will only apply when render target is valid. Even if it is by name**
    // Applies one or more presets by GUID to the target player or owned object by name.
    // Possible EC: Success, NoChange, TargetNotFound, TargetInvalid, DataNotFound, PresetLocked
    /// <summary> Applies a preset by GUID to the target player or owned object by name. </summary>
    /// <param name="presetId"> The <see cref="Guid" /> preset identifier to apply. </param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount to edit, or an empty string. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, PresetLocked)
    /// </returns>
    /// <remarks> This can only be called on a valid rendered player. </remarks>
    public LociApiEc ApplyPresetByName(Guid presetId, string charaName, string buddyName);

    /// <summary> Applies multiple presets by GUID to the target player or owned object by name. </summary>
    /// <param name="presetIds"> the List of <see cref="Guid" />preset identifiers to apply. </param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format. <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName"> The name of the companion or mount, or an empty string. </param>
    /// <param name="failed"> A list of identifiers that could not be applied. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, PresetLocked)
    /// </returns>
    /// <remarks> This can only be called on a valid rendered player. </remarks>
    public LociApiEc ApplyPresetsByName(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed);

    /// <summary> Remove a given preset by GUID </summary>
    /// <param name="presetId"> The <see cref="Guid" /> preset identifier to remove. </param>
    /// <param name="key"> If the status was locked, the correct key must be provided to remove it. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePreset(Guid presetId, uint key);

    /// <summary> Remove multiple presets by GUID </summary>
    /// <param name="presetIds"> A list containing <see cref="Guid" /> preset identifiers to remove. </param>
    /// <param name="key"> If the status was locked, the correct key must be provided to remove it. </param>
    /// <param name="failed"> A list of identifiers that failed to be removed. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePresets(List<Guid> presetIds, uint key, out List<Guid> failed);

    /// <summary> Remove one or more presets on a managed actor by address </summary>
    /// <param name="presetId"> The <see cref="Guid" /> preset identifier to remove. </param>
    /// <param name="address"> The address of the actor to affect. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePresetByPtr(Guid presetId, nint address);

    /// <summary> Remove one or more presets on a managed actor by address </summary>
    /// <param name="presetIds"> A List containing <see cref="Guid" /> preset identifiers to remove. </param>
    /// <param name="address"> The address of the actor to affect. </param>
    /// <param name="failed"> A list of preset identifiers that failed to apply. </param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePresetsByPtr(List<Guid> presetIds, nint address, out List<Guid> failed);

    /// <summary>Remove one or more presets on a managed actor by name</summary>
    /// <param name="presetId"> The <see cref="Guid" /> preset identifier to remove. </param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format.<br />
    ///     <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName">The name of the owned object, or an empty string.</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePresetByName(Guid presetId, string charaName, string buddyName);

    /// <summary>Remove one or more presets on a managed actor by name</summary>
    /// <param name="presetIds"> A list containing <see cref="Guid" /> preset identifiers to remove. </param>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format.<br />
    ///     <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName">The name of the owned object, or an empty string.</param>
    /// <param name="failed">A list of identifiers that failed to be removed</param>
    /// <returns>
    ///     An error code indicating the reason for failure, or Success.<br /> (Possible <see cref="LociApiEc" /> errors: NoChange, TargetNotFound, TargetInvalid,
    ///     DataNotFound, InvalidKey)
    /// </returns>
    public LociApiEc RemovePresetsByName(List<Guid> presetIds, string charaName, string buddyName, out List<Guid> failed);

    /// <summary> Triggers whenever a saved preset is modified within the editor. </summary>
    public event PresetUpdatedDelegate? PresetUpdated;

    #region Aquisition

    /// <summary> Obtains the LociPresetInfo tuple for the provided <paramref name="guid" />, if valid. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the preset to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public (LociApiEc, LociPresetInfo) GetPresetInfo(Guid guid);

    /// <summary> Obtains the list of valid LociPresetInfo tuples. </summary>
    /// <returns> The list of LociPresetInfo tuples for all created Presets. </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public List<LociPresetInfo> GetPresetInfoList();

    /// <summary> Obtain the PresetSummary tuple for the provided <paramref name="guid" />, if valid. </summary>
    /// <param name="guid"> The <see cref="Guid" /> identifier of the preset to look up. </param>
    /// <returns> <see cref="LociApiEc" />:DataInvalid, DataNotFound, Success </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public (LociApiEc, LociPresetSummary) GetPresetSummary(Guid guid);

    /// <summary> Obtains a list containing the PresetSummary for all presets. </summary>
    /// <returns> The list of PresetSummary tuples for all created Presets. </returns>
    /// <remarks> PresetSummary contains the presets GUID, FileSystemPath, IconID, Name, and Description </remarks>
    public List<LociPresetSummary> GetPresetSummaryList();

    #endregion Aquisition

    // Events can be added here overtime.
}
