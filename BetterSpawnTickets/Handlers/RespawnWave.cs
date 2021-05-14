using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class RespawnWave
    {
        public void OnRespawnWave(RespawningTeamEventArgs ev)
        {
            //Grant tickets to MTF and Chaos on MTF spawn
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["MtfRespawn"]); Log.Info($"Gave MTF {BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["MtfRespawn"]} because MTF respawned!");
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["MtfRespawn"]); Log.Info($"Gave Chaos {BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["MtfRespawn"]} because MTF respawned!");
            }

            //Grant tickets to MTF and Chaos on Chaos spawn
            else if (ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["ChaosRespawn"]); Log.Info($"Gave MTF {BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["ChaosRespawn"]} because Chaos respawned!");
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["ChaosRespawn"]); Log.Info($"Gave Chaos {BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["ChaosRespawn"]} because Chaos respawned!");
            }
        }
    }
}