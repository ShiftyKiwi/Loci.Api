namespace LociApi.Enums;

/// <summary> The interaction types that define a LociEvent. (WIP) </summary>
/// <remarks> This is long in case we make it a flag enum. </remarks>
public enum LociEventType : long
{
    /// <summary> In relation to the Clients' current job. </summary>
    JobChange = 0,

    /// <summary> Related to detection of recieving or losing buff or debuffs from the base game. </summary>
    GameBuffDebuff = 1,

    /// <summary> In relation to emote usage. </summary>
    Emote = 2,

    /// <summary> In relation to being in a specific zone or content type </summary>
    ZoneBased = 3,

    /// <summary> In relation to the Clients current online status. </summary>
    OnlineStatus = 4,

    /// <summary> In relation to the time of day (can be IRL or Eorzean time) </summary>
    TimeOfDay = 5
}
