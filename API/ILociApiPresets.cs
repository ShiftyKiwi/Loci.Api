using LociApi.Enums;

namespace LociApi.Api;

/// <summary>
///   Functions for interacting with presets (groups of statuses).
/// </summary>
public interface ILociApiPresets
{

    public (LociApiEc, LociPresetInfo) GetPresetInfo(Guid presetId);
    public (LociApiEc, List<LociPresetInfo>) GetAllPresetInfo();


    public (LociApiEc, object) ApplyPresetByPtr(Guid preset, nint ptr);
    public (LociApiEc, object) ApplyPresetByName(Guid preset, string name);
    public (LociApiEc, object) ApplyPresetsByPtr(List<Guid> presets, nint ptr);
    public (LociApiEc, object) ApplyPresetsByName(List<Guid> presets, string name);

}
