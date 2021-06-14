using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Exiled.API.Enums;
using System.Collections.Generic;

namespace BetterSpawnTickets.Handlers
{
    internal class Dying
    {
        public void OnDying(DyingEventArgs ev)
        {
            //Grant tickets to a team whenever a member of that team kills a player
            if (ev.Target != ev.Killer) //Prevents jank when a player is killed by the environment
            {
                try
                {
                    switch (ev.Killer.Side)
                    {
                        case Side.Mtf:
                            MyFunctions.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnKill[ev.Target.Role.ToString()]);
                            break;

                        case Side.ChaosInsurgency:
                            MyFunctions.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnKill[ev.Target.Role.ToString()]);
                            break;

                        default:
                            break;
                    }
                }
                catch (KeyNotFoundException)
                {
                    Log.Error(MyFunctions.ConfigName(ev.Killer.Side, "tickets_on_kill") + $"was missing the value {ev.Target.Role}");
                }
            }
        }
    }
}