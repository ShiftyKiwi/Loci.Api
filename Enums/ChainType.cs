namespace LociApi.Enums;

/// <summary> What component of Loci gets enacted by the chain trigger. </summary>
public enum ChainType : byte
{
    /// <summary> Another LociStatus </summary>
    Status = 0,

    /// <summary> A LociPreset </summary>
    Preset = 1,

    /// <summary> A LociEvent </summary>
    Event = 2
}
