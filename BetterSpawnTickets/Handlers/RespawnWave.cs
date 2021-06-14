using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Respawning;

namespace BetterSpawnTickets.Handlers
{
    internal class RespawnWave
    {
        public void OnRespawnWave(RespawningTeamEventArgs ev)
        {
            //Grant tickets to MTF and Chaos whenever a team respawns
            switch (ev.NextKnownTeam)
            {
                case SpawnableTeamType.NineTailedFox:
                    MyFunctions.GrantBothTeamsTickets("MtfRespawn");
                    break;

                case SpawnableTeamType.ChaosInsurgency:
                    MyFunctions.GrantBothTeamsTickets("ChaosRespawn");
                    break;

                default:
                    break;
            }
        }
    }
}