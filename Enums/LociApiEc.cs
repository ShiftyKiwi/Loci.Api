namespace LociApi.Enums;

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
    ///   Used by bulk calls to indicate some operations worked, but not all. 
    /// </summary>
    PartialSuccess = 2,

    /// <summary>
    ///   The requested target could not be located.
    /// </summary>
    TargetNotFound = 3,

    /// <summary>
    ///   The requested target was null.
    /// </summary>
    TargetInvalid = 4,

    /// <summary>
    ///   The data requested could not be found in Loci.
    /// </summary>
    DataNotFound = 5,

    /// <summary>
    ///   The GUID targetted for the interaction was not present in Loci.
    /// </summary>
    DataInvalid = 6,

    /// <summary>
    ///   The GUID targetted for modification was locked, and no lock was provided.
    /// </summary>
    ItemLocked = 7,

    /// <summary>
    ///   Attempted to apply or removed a locked status with an incorrect key.
    /// </summary>
    InvalidKey = 8,

    /// <summary>
    ///   Itsm was marked as persistent and cannot be removed.
    /// </summary>
    ItemIsPersistent = 9,

    /// <summary>
    ///   Operation was performed on Client, when it is not allowed
    /// </summary>
    ClientForbidden = 10,

    /// <summary>
    ///   Some data was parsed, but the file system path failed to be identified
    /// </summary>
    FSPathFaulted = 11,

    /// <summary>
    ///   Another error not yet documented occured.
    /// </summary>
    UnkError = int.MaxValue,
}
