using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class EscapingPD
    {
        //Grant tickets to MTF or Chaos on pocket dimension escape
        public void OnEscapingPD(EscapingPocketDimensionEventArgs ev)
        {
            switch (MyFunctions.GetTeam(ev.Player))
            {
                case Respawning.SpawnableTeamType.NineTailedFox:
                    MyFunctions.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["PlayerEscapePD"]);
                    break;

                case Respawning.SpawnableTeamType.ChaosInsurgency:
                    MyFunctions.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["PlayerEscapePD"]);
                    break;

                default:
                    break;
            }
        }
    }
}