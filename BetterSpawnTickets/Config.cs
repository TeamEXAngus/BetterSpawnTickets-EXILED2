using System.ComponentModel;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace BetterSpawnTickets
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not a team's tickets should be removed when all of its members are dead.")]
        public bool EliminateTeams { get; set; } = true;

        [Description("Prevents teams that have been eliminated from becoming un-eliminated.")]
        public bool TeamsStayEliminated { get; set; } = true;

        [Description("Whether or not MTF can be eliminated before the first spawn wave has occured. Its recommended to keep this as false.")]
        public bool EliminateMtfBeforeFirstWave { get; set; } = false;

        [Description("Whether or not a team's tickets should be transferred to the other team once the team dies.")]
        public bool TransferTickets { get; set; } = true;

        [Description("How many tickets the MTF team should be granted when a given class is killed by them. Supports Negative Values")]
        public Dictionary<string, int> MtfTicketsOnKill { get; set; } = new Dictionary<string, int>
        {
            {"ClassD", 0 },
            {"ChaosInsurgency", 0 },
            {"FacilityGuard", 0 },
            {"NtfCadet", 0 },
            {"NtfLieutenant", 0 },
            {"NtfScientist", 0 },
            {"NtfCommander", 0 },
            {"Scientist", 0 },
            {"Scp049", 0 },
            {"Scp0492", 0 },
            {"Scp079", 0 },
            {"Scp096", 0 },
            {"Scp106", 0 },
            {"Scp173", 0 },
            {"Scp93953", 0 },
            {"Scp93989", 0 },
            {"Tutorial", 0 },
        };

        [Description("How many tickets the Chaos team should be granted when a given class is killed by them. Supports negative values.")]
        public Dictionary<string, int> ChaosTicketsOnKill { get; set; } = new Dictionary<string, int>
        {
            {"ClassD", 0 },
            {"ChaosInsurgency", 0 },
            {"FacilityGuard", 0 },
            {"NtfCadet", 0 },
            {"NtfLieutenant", 0 },
            {"NtfScientist", 0 },
            {"NtfCommander", 0 },
            {"Scientist", 0 },
            {"Scp049", 0 },
            {"Scp0492", 0 },
            {"Scp079", 0 },
            {"Scp096", 0 },
            {"Scp106", 0 },
            {"Scp173", 0 },
            {"Scp93953", 0 },
            {"Scp93989", 0 },
            {"Tutorial", 0 },
        };

        [Description("How many tickets the MTF team should be granted for a given event. Supports negative values.")]
        public Dictionary<string, int> MtfTicketsOnEvent { get; set; } = new Dictionary<string, int>
        {
            {"GeneratorActivated", 0 },
            {"WarheadDetonation", 0 },
            {"PocketdimensionEscape", 0 },
            {"MtfRespawn", 0 },
            {"ChaosRespawn", 0 }
        };

        [Description("How many tickets the Chaos team should be granted for a given event. Supports negative values.")]
        public Dictionary<string, int> ChaosTicketsOnEvent { get; set; } = new Dictionary<string, int>
        {
            {"GeneratorActivated", 0 },
            {"WarheadDetonation", 0 },
            {"PocketdimensionEscape", 0 },
            {"MtfRespawn", 0 },
            {"ChaosRespawn", 0 }
        };
    }
}