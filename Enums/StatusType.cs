namespace LociApi.Enums;

/// <summary> The category of a StatusIcon </summary>
public enum StatusType : byte
{
    /// <summary> Status Info (Enhancements) </summary>
    Positive = 0,

    /// <summary> Status Info (Enfeeblements) </summary>
    Negative = 1,

    /// <summary> Status Info (Other) </summary>
    Special = 2
}
