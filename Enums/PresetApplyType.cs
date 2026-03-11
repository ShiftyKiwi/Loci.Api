namespace LociApi.Enums;

/// <summary>
///   Dictates how a preset should be applied to an ActorSM
/// </summary>
public enum PresetApplyType : byte
{
    /// <summary>
    ///   Any existing statuses that are already active are ignored.
    /// </summary>
    IgnoreExisting = 0,

    /// <summary>
    ///   Existing statuses have their timer and stack counts reset on application.
    /// </summary>
    UpdateExisting = 1,

    /// <summary>
    ///   All other statuses are removed prior to application. <b>Use with caution.</b>
    /// </summary>
    ReplaceAll = 2,
}
