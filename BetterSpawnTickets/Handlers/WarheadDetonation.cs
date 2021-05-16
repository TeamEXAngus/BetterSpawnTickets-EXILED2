using Exiled.API.Features;

namespace BetterSpawnTickets.Handlers
{
    internal class WarheadDetonation
    {
        public void OnWarheadDetonation()
        {
            //Grant tickets to MTF and Chaos when warhead detonated
            MyFunctions.GrantBothTeamsTickets("WarheadDetonation");
        }
    }
}