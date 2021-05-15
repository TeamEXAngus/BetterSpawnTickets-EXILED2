using Exiled.Events.EventArgs;
using Exiled.API.Features;

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