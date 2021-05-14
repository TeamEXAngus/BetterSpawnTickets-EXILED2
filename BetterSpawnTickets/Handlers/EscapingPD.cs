using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class EscapingPD
    {
        //Grant tickets to MTF or Chaos on pocket dimension escape
        public void OnEscapingPD(EscapingPocketDimensionEventArgs ev)
        {
            if (BetterSpawnTickets.IsFoundation(ev.Player))
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["PlayerEscapePD"]);
            }
            else if (BetterSpawnTickets.IsChaos(ev.Player))
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["PlayerEscapePD"]);
            }
        }
    }
}