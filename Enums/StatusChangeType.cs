namespace LociApi.Enums;

/// <summary> Identifies how a status changed its related StatusManager state. </summary>
public enum StatusChangeType : byte
{
    /// <summary> Added to the StatusManager. </summary>
    Added = 0,

    /// <summary> The Status was reapplied and had reapplication enabled. </summary>
    Reapplied = 1,

    /// <summary> Removed from the StatusManager, by expiration or manual removal. </summary>
    Removed = 2
}
