using System.Runtime.CompilerServices;

namespace LociApi.Enums;

/// <summary> Defines the behavior of a LociStatus </summary>
[Flags]
public enum Modifiers : uint
{
    /// <summary> No special behavior. </summary>
    None = 0,

    /// <summary> The status is dispellable. </summary>
    CanDispel = 1u << 0,

    /// <summary> When reapplied, the status can increase its stack count, if stackable. </summary>
    StacksIncrease = 1u << 1,

    /// <summary> When a stack reaches its cap, it starts over and counts up again. </summary>
    StacksRollOver = 1u << 2,

    /// <summary> When reapplied, the expiry time remains the same instead of refreshing. </summary>
    PersistExpireTime = 1u << 3,

    /// <summary> When a ChainTrigger occurs, the current stacks are carried over to ChainedGUID. (Only for statuses) </summary>
    StacksMoveToChain = 1u << 4,

    /// <summary> When the stacks increase and hit max, the remaining stacks carry over. (Only for statuses) </summary>
    StacksCarryToChain = 1u << 5,

    /// <summary> When ChainTrigger occurs, keep the status active and do not remove it. </summary>
    PersistAfterTrigger = 1u << 6

    // Ideas: Persist original after chain trigger, ext.
}

/// <summary> Bitwise operation help for Status Modifiers. </summary>
public static class ModifiersEx
{
    /// <summary>Test if a specific flag is set.</summary>
    /// <param name="value">The value to test</param>
    /// <param name="flag">The desired flag</param>
    /// <returns><see langword="true" /> if flag is present</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Has(this Modifiers value, Modifiers flag)
    {
        return (value & flag) == flag;
    }

    /// <summary>Test if any flags are set</summary>
    /// <param name="value">The value to check</param>
    /// <param name="flags">The desired flags.</param>
    /// <returns><see langword="true" /> if any of the desired flags are present.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasAny(this Modifiers value, Modifiers flags)
    {
        return (value & flags) != 0;
    }

    /// <summary>Set a specific flag value</summary>
    /// <param name="value">The value to change.</param>
    /// <param name="flag">The flag to set</param>
    /// <param name="enabled">The state to set the flag in.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Set(ref this Modifiers value, Modifiers flag, bool enabled)
    {
        if (enabled) value |= flag;
        else value &= ~flag;
    }

    /// <summary>Clear a specified flag</summary>
    /// <param name="value">The value to change.</param>
    /// <param name="flag">The flag to clear.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Clear(ref this Modifiers value, Modifiers flag)
    {
        value &= ~flag;
    }

    /// <summary>Toggle a specified flag.</summary>
    /// <param name="value">The value to change.</param>
    /// <param name="flag">The flag to toggle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Toggle(ref this Modifiers value, Modifiers flag)
    {
        value ^= flag;
    }
}
