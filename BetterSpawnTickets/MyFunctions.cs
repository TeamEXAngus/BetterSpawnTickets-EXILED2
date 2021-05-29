using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace BetterSpawnTickets
{
    internal class MyFunctions
    {
        //Returns true if the chosen player is Scientist, Guard, or MTF
        public static bool IsFoundation(Player player)
        {
            return (player.Team == Team.MTF || player.Role == RoleType.Scientist);
        }

        //Returns true if the chosen player is Class D or Chaos
        public static bool IsChaos(Player player)
        {
            return (player.Role == RoleType.ChaosInsurgency || player.Role == RoleType.ClassD);
        }

        //Uses above functions to get the team of a chosen player
        public static Respawning.SpawnableTeamType GetTeam(Player player)
        {
            return IsFoundation(player) ? Respawning.SpawnableTeamType.NineTailedFox :
                  (IsChaos(player) ? Respawning.SpawnableTeamType.ChaosInsurgency : Respawning.SpawnableTeamType.None);
        }

        //Prevents spawn tickets from ever being set below 0 by returning no less than -1 * the team's tickets
        public static int NegativeTicketHandler(Respawning.SpawnableTeamType team, int amount)
        {
            int tickets = (team == Respawning.SpawnableTeamType.NineTailedFox ? Respawn.NtfTickets : Respawn.ChaosTickets);
            return (tickets - amount) > 0 ? amount : -1 * tickets;
        }

        //Exiled's grant tickets function with NegativeTicketHandler() grafted in
        public static void GrantTickets(Respawning.SpawnableTeamType team, int amount)
        {
            Respawn.GrantTickets(team, NegativeTicketHandler(team, amount));
        }

        //Grants both teams tickets for the same reason
        public static void GrantBothTeamsTickets(string reason)
        {
            GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent[reason]);
            GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent[reason]);
        }
    }
}