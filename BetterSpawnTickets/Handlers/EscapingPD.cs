using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Collections.Generic;

namespace BetterSpawnTickets.Handlers
{
    internal class EscapingPD
    {
        //Grant tickets to MTF or Chaos on pocket dimension escape
        public void OnEscapingPD(EscapingPocketDimensionEventArgs ev)
        {
            try
            {
                switch (ev.Player.Side)
                {
                    case Exiled.API.Enums.Side.Mtf:
                        MyFunctions.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["PlayerEscapePD"]);
                        break;

                    case Exiled.API.Enums.Side.ChaosInsurgency:
                        MyFunctions.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["PlayerEscapePD"]);
                        break;

                    default:
                        break;
                }
            }
            catch (KeyNotFoundException)
            {
                Log.Error(MyFunctions.ConfigName(ev.Player.Side, "tickets_on_kill") + $"was missing the value PlayerEscapePD");
            }
        }
    }
}