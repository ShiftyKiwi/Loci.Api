using Dalamud.Plugin;
using LociApi.Api;
using LociApi.Enums;
using LociApi.Helpers;

namespace LociApi.IPC;

/// <inheritdoc cref="ILociApiStatuses.GetStatusInfo"/>
public sealed class GetStatusInfo(IDalamudPluginInterface pi)
    : FuncSubscriber<Guid, (LociApiEc, LociStatusInfo)>(pi, Label)
{
    public const string Label = $"Loci.{nameof(GetStatusInfo)}";

    /// <inheritdoc cref="ILociApiStatuses.GetStatusInfo"/>
    public new (LociApiEc, LociStatusInfo) Invoke(Guid guid)
        => base.Invoke(guid);

    public static FuncProvider<Guid, (LociApiEc, LociStatusInfo)> Provider(IDalamudPluginInterface pi, ILociApiStatuses api)
        => new(pi, Label, api.GetStatusInfo);
}
