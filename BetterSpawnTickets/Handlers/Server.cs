using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class Server
    {
        public void OnRespawnWave(RespawningTeamEventArgs ev)
        {
            //Grant tickets to MTF and Chaos on MTF spawn
            if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["MtfRespawn"]);
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["MtfRespawn"]);

                //Store the fact that MTF has spawned
                if (!BetterSpawnTickets.HasMTFSpawned) { BetterSpawnTickets.HasMTFSpawned = true; Log.Debug($"HasMTFSpawned set to 'true'!"); }
            }

            //Grant tickets to MTF and Chaos on Chaos spawn
            else if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["ChaosRespawn"]);
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["ChaosRespawn"]);
            }

            BetterSpawnTickets.TeamsStayEliminatedLogic();
        }
    }
}