using LociApi.Enums;

namespace LociApi.Api;

/// <summary> Functions to manage ephemeral hosting on actors via external plugins.
///     <para />
///     Implement if controlling what can be applied to other actors besides the client. </summary>
public interface ILociApiRegistry
{
    /// <summary>
    ///     Assign a <paramref name="hostLabel" /> to an Actors StatusManager, marking them as ephemeral and adding it to the list of hosts for target
    ///     application.
    /// </summary>
    /// <param name="address"> Address of the Player or Minion. </param>
    /// <param name="hostLabel"> The label that will be added to the actors EphemeralHosts. Should be shared across your Plugin. </param>
    /// <returns> <see cref="LociApiEc" />: TargetInvalid, TargetNotFound, Success. </returns>
    /// <remarks>
    ///     <b> Ephemeral actors are not disposed of when unrendered, and are not saved between reloads. </b> As such, be sure to reassign after disposal and
    ///     ready events.
    /// </remarks>
    public LociApiEc RegisterByPtr(nint address, string hostLabel);

    /// <summary>
    ///     Assign a <paramref name="hostLabel" /> to an Actors StatusManager, marking them as ephemeral and adding it to the list of hosts for target
    ///     application.<br /> Can be called when actor is not rendered, but their StatusManager must exist.
    /// </summary>
    /// <param name="charaName"> Expects '<c> Player Name@World </c>'. If using <paramref name="buddyName" />, only '<c> Player Name </c>' is used. </param>
    /// <param name="buddyName"> The NameString of a Minion/Pet/Companion. If empty, <paramref name="charaName" /> is expected to be '<c> Player Name@World </c>' </param>
    /// <param name="hostLabel"> The label that will be added to the actors EphemeralHosts. (Should be a shared label) </param>
    /// <returns> <see cref="LociApiEc" />: TargetInvalid, TargetNotFound, Success. </returns>
    /// <remarks>
    ///     <b> Ephemeral actors are not disposed of when unrendered, and are not saved between reloads. </b><br /> As such, be sure to reassign after disposal
    ///     and ready events.
    /// </remarks>
    public LociApiEc RegisterByName(string charaName, string buddyName, string hostLabel);

    /// <summary> Remove an existing <paramref name="hostLabel" /> from an Actors StatusManager. </summary>
    /// <param name="address"> Address of the Player or Minion. </param>
    /// <param name="hostLabel"> The label that will be removed from the actors EphemeralHosts. (Should be a shared label) </param>
    /// <returns> <see cref="LociApiEc" />: TargetInvalid, TargetNotFound, NoChange, Success </returns>
    public LociApiEc UnregisterByPtr(nint address, string hostLabel);

    /// <summary>
    ///     Remove an existing <paramref name="hostLabel" /> from an Actors StatusManager. Can be called when actor is not rendered, but their StatusManager must
    ///     exist.
    /// </summary>
    /// <param name="charaName"> Expects '<c> Player Name@World </c>'. If using <paramref name="buddyName" />, only '<c> Player Name </c>' is used. </param>
    /// <param name="buddyName"> The NameString of a Minion/Pet/Companion. If empty, <paramref name="charaName" /> is expected to be '<c> Player Name@World </c>' </param>
    /// <param name="hostLabel"> The label that will be removed to the actors EphemeralHosts. (Should be a shared label) </param>
    /// <returns> <see cref="LociApiEc" />: TargetInvalid, TargetNotFound, NoChange, Success. </returns>
    public LociApiEc UnregisterByName(string charaName, string buddyName, string hostLabel);

    /// <summary>Removes the host label from All actors.</summary>
    /// <param name="hostLabel">The label that will be removed to the actors EphemeralHosts. (Should be a shared label)</param>
    /// <returns>The number of actors altered.</returns>
    public int UnregisterAll(string hostLabel);

    /// <summary>Retrieves the current Ephemeral hosts for a rendered actor.</summary>
    /// <param name="address">The address of the rendered actor.</param>
    /// <returns>A list containing all the current host labels affecting this actor.</returns>
    public List<string> GetHostsByPtr(nint address);

    /// <summary>Retrieves the current Ephemeral hosts for an actor by name.</summary>
    /// <param name="charaName">
    ///     The name of the player in <c>'First Last@World'</c> format.<br />
    ///     <b>Omit <c>'@World'</c> when providing <paramref name="buddyName" /></b>
    /// </param>
    /// <param name="buddyName">The name of the owned object, or an empty string.</param>
    /// <returns>A list containing all the current host labels affecting this actor.</returns>
    /// <remarks>Can be called when actor is not rendered, but their StatusManager must exist.</remarks>
    public List<string> GetHostsByName(string charaName, string buddyName);

    /// <summary>Gets the number of status managers that use a specific host label.</summary>
    /// <param name="hostLabel">The host label to check.</param>
    /// <returns>The number of StatusManagers using the specified hostLabel</returns>
    /// <remarks>Can also include the current client.</remarks>
    public int GetHostActorCount(string hostLabel);

    /// <summary>Fires whenever the ephemeral hosts for an actor changed, and what host triggered the event.</summary>
    public event Action<nint, string>? ActorHostsChanged;
}
