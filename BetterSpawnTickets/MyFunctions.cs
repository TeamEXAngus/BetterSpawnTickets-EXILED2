using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Respawning;

namespace BetterSpawnTickets
{
    internal class MyFunctions
    {
        //Prevents spawn tickets from ever being set below 0 by returning no less than -1 * the team's tickets
        public static int NegativeTicketHandler(Respawning.SpawnableTeamType team, int amount)
        {
            int tickets = (team == Respawning.SpawnableTeamType.NineTailedFox ? Respawn.NtfTickets : Respawn.ChaosTickets);
            return (tickets + amount <= 0) ?
                amount :
                -tickets;
        }

        //Exiled's grant tickets function with NegativeTicketHandler() grafted in
        public static void GrantTickets(SpawnableTeamType team, int amount)
        {
            Respawn.GrantTickets(team, NegativeTicketHandler(team, amount));
        }

        //Grants both teams tickets for the same reason
        public static void GrantBothTeamsTickets(string reason)
        {
            try
            {
                GrantTickets(SpawnableTeamType.NineTailedFox, BetterSpawnTickets.Instance.Config.MtfTicketsOnEvent[reason]);
            }
            catch (KeyNotFoundException)
            {
                Log.Error("mtf_tickets_on_event" + $"was missing the value {reason}");
            }

            try
            {
                GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, BetterSpawnTickets.Instance.Config.ChaosTicketsOnEvent[reason]);
            }
            catch (KeyNotFoundException)
            {
                Log.Error("chaos_tickets_on_event" + $"was missing the value {reason}");
            }
        }

        public static string ConfigName(Side side, string name)
        {
            var a = side == Side.Mtf ? "mtf_" : "chaos_";
            return $"{a}{name}".ToLower();
        }
    }
}