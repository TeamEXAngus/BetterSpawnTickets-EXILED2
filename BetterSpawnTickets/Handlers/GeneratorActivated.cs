using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class GeneratorActivated
    {
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            //Grant tickets to MTF and Chaos when generator activated
            Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["GeneratorActivated"]);
            Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["GeneratorActivated"]);
        }
    }
}