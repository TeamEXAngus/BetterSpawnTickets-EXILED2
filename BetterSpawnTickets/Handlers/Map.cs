using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class Map
    {
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            //Grant tickets to MTF and Chaos when generator activated
            Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["GeneratorActivated"]);
            Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["GeneratorActivated"]);

            BetterSpawnTickets.TeamsStayEliminatedLogic();
        }

        public void OnWarheadDetonation()
        {
            //Grant tickets to MTF and Chaos when warhead detonated
            Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["WarheadDetonation"]);
            Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["WarheadDetonation"]);

            BetterSpawnTickets.TeamsStayEliminatedLogic();
        }
    }
}