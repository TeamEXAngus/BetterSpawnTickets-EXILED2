using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class WarheadDetonation
    {
        public void OnWarheadDetonation()
        {
            //Grant tickets to MTF and Chaos when warhead detonated
            Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["WarheadDetonation"]);
            Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["WarheadDetonation"]);
        }
    }
}