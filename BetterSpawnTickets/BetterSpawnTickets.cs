using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;
using MapHandler = Exiled.Events.Handlers.Map;
using WarheadHandler = Exiled.Events.Handlers.Warhead;

namespace BetterSpawnTickets
{
    public class BetterSpawnTickets : Plugin<Config>
    {
        private static readonly Lazy<BetterSpawnTickets> LazyInstance = new Lazy<BetterSpawnTickets>(valueFactory: () => new BetterSpawnTickets());
        public static BetterSpawnTickets Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium; //Plugin priority determines when during startup the plugin gets loaded

        //Declaring event handlers

        private Handlers.Dying dying;
        private Handlers.EscapingPD escapingPD;
        private Handlers.RespawnWave respawnWave;
        private Handlers.GeneratorActivated generatorActivated;
        private Handlers.WarheadDetonation warheadDetonation;

        private BetterSpawnTickets()
        {
        }

        //Run startup code when plugin is enabled
        public override void OnEnabled()
        {
            RegisterEvents();
        }

        //Run shutdown code when plugin is disabled
        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        //Plugin startup code
        public void RegisterEvents()
        {
            dying = new Handlers.Dying();
            escapingPD = new Handlers.EscapingPD();
            respawnWave = new Handlers.RespawnWave();
            generatorActivated = new Handlers.GeneratorActivated();
            warheadDetonation = new Handlers.WarheadDetonation();

            PlayerHandler.Dying += dying.OnDying;
            PlayerHandler.EscapingPocketDimension += escapingPD.OnEscapingPD;
            ServerHandler.RespawningTeam += respawnWave.OnRespawnWave;
            MapHandler.GeneratorActivated += generatorActivated.OnGeneratorActivated;
            WarheadHandler.Detonated += warheadDetonation.OnWarheadDetonation;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            PlayerHandler.Dying -= dying.OnDying;
            PlayerHandler.EscapingPocketDimension -= escapingPD.OnEscapingPD;
            ServerHandler.RespawningTeam -= respawnWave.OnRespawnWave;
            MapHandler.GeneratorActivated -= generatorActivated.OnGeneratorActivated;
            WarheadHandler.Detonated -= warheadDetonation.OnWarheadDetonation;

            dying = null;
            escapingPD = null;
            respawnWave = null;
            generatorActivated = null;
            warheadDetonation = null;
        }
    }
}