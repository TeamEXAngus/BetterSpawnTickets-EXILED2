using Exiled.Events.EventArgs;
using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class Player
    {
        //Whenever a player dies check if either team is empty and if so remove their tickets
        public void OnDying(DyingEventArgs ev)
        {
            Log.Debug($"{ev.Target.Nickname} died! Their class was {ev.Target.Role}!\n{BetterSpawnTickets.CountFoundationForces()} foundation forces remain and {BetterSpawnTickets.CountChaosForces()} chaos forces remain!");

            if (BetterSpawnTickets.Instance.Config.EliminateTeams)
            {
                //If MTF is empty, given that a spawn wave has already occured
                if (BetterSpawnTickets.CountFoundationForces() == 0 && BetterSpawnTickets.HasMTFSpawned)
                {
                    Log.Debug($"Removed all tickets from MTF!");
                    //If configured as so, give MTF tickets to Chaos
                    //Then, remove MTF tickets
                    if (BetterSpawnTickets.Instance.Config.TransferTickets) { Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, Respawn.NtfTickets); }
                    Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, -1 * Respawn.NtfTickets);
                }

                //Ditto for Chaos
                if (BetterSpawnTickets.CountChaosForces() == 0)
                {
                    Log.Debug($"Removed all tickets from Chaos!");
                    if (BetterSpawnTickets.Instance.Config.TransferTickets) { Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, Respawn.ChaosTickets); }
                    Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, -1 * Respawn.ChaosTickets);
                }

                Log.Debug($"MTF   tickets: {Respawn.NtfTickets}");
                Log.Debug($"Chaos tickets: {Respawn.ChaosTickets}");
            }

            //Grant MTF tickets on class killed
            if ((ev.Killer.Team == Team.MTF || ev.Killer.Role == RoleType.Scientist) && ev.Target != ev.Killer)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnKill[ev.Target.Role.ToString()]);
            }

            //Grant Chaos tickets on class killed
            else if ((ev.Killer.Role == RoleType.ChaosInsurgency || ev.Killer.Role == RoleType.ClassD) && ev.Target != ev.Killer)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnKill[ev.Target.Role.ToString()]);
            }

            BetterSpawnTickets.TeamsStayEliminatedLogic();
        }

        //Grant tickets to MTF or Chaos on pocket dimension escape
        public void EscapingPD(EscapingPocketDimensionEventArgs ev)
        {
            if (ev.Player.Team == Team.MTF || ev.Player.Role == RoleType.Scientist)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent["PocketDimensionEscape"]);
            }
            else if (ev.Player.Role == RoleType.ChaosInsurgency || ev.Player.Role == RoleType.ClassD)
            {
                Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent["PocketDimensionEscape"]);
            }

            BetterSpawnTickets.TeamsStayEliminatedLogic();
        }
    }
}