using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class Dying
    {
        public void OnDying(DyingEventArgs ev)
        {
            //Grant tickets to a team whenever a member of that team kills a player
            if (ev.Target != ev.Killer) //Prevents jank when a player is killed by the environment
            {
                switch (ev.Killer.Side)
                {
                    case Exiled.API.Enums.Side.Mtf:
                        MyFunctions.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnKill[ev.Target.Role.ToString()]);
                        break;

                    case Exiled.API.Enums.Side.ChaosInsurgency:
                        MyFunctions.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnKill[ev.Target.Role.ToString()]);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}