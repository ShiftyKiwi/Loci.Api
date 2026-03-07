namespace Loci.Api.API;

/// <summary>
/// The full API available for Loci.
/// </summary>
public interface ILociApi : ILociApiBase
{
    /// <inheritdoc cref="ILociApiRegistry"/>
    public ILociApiRegistry Registry { get; }

    ///<inheritdoc cref="ILociApiStatuses" />
    public ILociApiStatuses Statuses { get; }

    ///<inheritdoc cref="ILociApiPresets" />
    public ILociApiPresets Presets { get; }

    /// <inheritdoc cref="ILociApiEvents" />
    public ILociApiEvents Events { get; }
}
