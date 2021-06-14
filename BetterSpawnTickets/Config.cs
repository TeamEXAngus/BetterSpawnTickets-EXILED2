using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace BetterSpawnTickets
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The number of tickets that MTF should be granted when a Scientist, Guard, or MTF kills a given class. Supports Negative Values")]
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

        [Description("The number of tickets that Chaos should be granted when a Class D or Chaos Insurgent kills a given class. Supports Negative Values")]
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
            {"PlayerEscapePD", 0 },
            {"MtfRespawn", 0 },
            {"ChaosRespawn", 0 }
        };

        [Description("How many tickets the Chaos team should be granted for a given event. Supports negative values.")]
        public Dictionary<string, int> ChaosTicketsOnEvent { get; set; } = new Dictionary<string, int>
        {
            {"GeneratorActivated", 0 },
            {"WarheadDetonation", 0 },
            {"PlayerEscapePD", 0 },
            {"MtfRespawn", 0 },
            {"ChaosRespawn", 0 }
        };
    }
}