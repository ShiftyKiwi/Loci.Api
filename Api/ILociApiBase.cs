namespace LociApi.Api;

/// <summary>
///   Base API functionality.
/// </summary>
public interface ILociApiBase
{
    /// <summary>
    ///   Get the current API version being used by Loci.
    ///   Major version changes indicate incompatibilities, minor version changes are backward-compatible additions.
    /// </summary>
    public (int Major, int Minor) ApiVersion { get; }
}
