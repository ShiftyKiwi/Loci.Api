namespace LociApi.Enums;

/// <summary> What caused a LociStatus to invoke its ChainedGUID </summary>
public enum ChainTrigger
{
    /// <summary> Occurs when the status is dispelled </summary>
    Dispel = 0,

    /// <summary> Occurs when a stackable status reaches or passes its max stack count </summary>
    HitMaxStacks = 1,

    /// <summary> Occurs when the time of a non-permanent status expires naturally. </summary>
    TimerExpired = 2,

    /// <summary> Occurs when a stackable status reaches a defined stack count </summary>
    HitSetStacks = 3
}
