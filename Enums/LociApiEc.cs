namespace Loci.Api.Enums;

/// <summary>
///   Return codes for API functions.
/// </summary>
public enum LociApiEc
{
    /// <summary>
    ///   Interaction worked as intended.
    /// </summary>
    Success = 0,

    /// <summary>
    ///   Nothing was modified after the interaction occured.
    /// </summary>
    NoChange = 1,

    /// <summary>
    ///   The requested target could not be located.
    /// </summary>
    TargetNotFound = 2,

    /// <summary>
    ///   The requested target was null.
    /// </summary>
    TargetInvalid = 3,

    /// <summary>
    ///   The data requested could not be found in Loci.
    /// </summary>
    DataNotFound = 4,

    /// <summary>
    ///   The GUID targetted for the interaction was not present in Loci.
    /// </summary>
    DataInvalid = 5,

    /// <summary>
    ///   The GUID targetted for modification was locked, and no lock was provided.
    /// </summary>
    StatusLocked = 6,

    /// <summary>
    ///   Attempted to apply or removed a locked status with an incorrect key.
    /// </summary>
    InvalidKey = 7,

    /// <summary>
    ///   Another error not yet documented occured.
    /// </summary>
    UnkError = int.MaxValue,
}
