using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace BetterSpawnTickets.Handlers
{
    internal class GeneratorActivated
    {
        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            //Grant tickets to MTF and Chaos when generator activated
            MyFunctions.GrantBothTeamsTickets("GeneratorActivated");
        }
    }
}