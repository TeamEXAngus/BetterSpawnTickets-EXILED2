using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class Dying
    {
        //Whenever a player dies check if either team is empty and if so remove their tickets
        public void OnDying(DyingEventArgs ev)
        {
            //Grant MTF tickets on class killed
            if (BetterSpawnTickets.IsFoundation(ev.Killer) && ev.Target != ev.Killer)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnKill[ev.Target.Role.ToString()]);
            }

            //Grant Chaos tickets on class killed
            else if (BetterSpawnTickets.IsChaos(ev.Killer) && ev.Target != ev.Killer)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnKill[ev.Target.Role.ToString()]);
            }
        }
    }
}