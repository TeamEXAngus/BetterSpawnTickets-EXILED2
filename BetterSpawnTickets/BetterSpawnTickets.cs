using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using MapHandler = Exiled.Events.Handlers.Map;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;
using WarheadHandler = Exiled.Events.Handlers.Warhead;

namespace BetterSpawnTickets
{
    public class BetterSpawnTickets : Plugin<Config>
    {
        private static BetterSpawnTickets singleton = new BetterSpawnTickets();
        public static BetterSpawnTickets Instance => singleton;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 5);

        //Declaring event handlers

        private Handlers.Dying dying;
        private Handlers.EscapingPD escapingPD;
        private Handlers.RespawnWave respawnWave;
        private Handlers.WarheadDetonation warheadDetonation;
        private Handlers.GeneratorActivated generatorActivated;

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
            warheadDetonation = new Handlers.WarheadDetonation();
            generatorActivated = new Handlers.GeneratorActivated();

            PlayerHandler.Dying += dying.OnDying;
            ServerHandler.RespawningTeam += respawnWave.OnRespawnWave;
            PlayerHandler.EscapingPocketDimension += escapingPD.OnEscapingPD;
            WarheadHandler.Detonated += warheadDetonation.OnWarheadDetonation;
            MapHandler.GeneratorActivated += generatorActivated.OnGeneratorActivated;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            PlayerHandler.Dying -= dying.OnDying;
            ServerHandler.RespawningTeam -= respawnWave.OnRespawnWave;
            PlayerHandler.EscapingPocketDimension -= escapingPD.OnEscapingPD;
            WarheadHandler.Detonated -= warheadDetonation.OnWarheadDetonation;
            MapHandler.GeneratorActivated -= generatorActivated.OnGeneratorActivated;

            dying = null;
            escapingPD = null;
            respawnWave = null;
            warheadDetonation = null;
            generatorActivated = null;
        }
    }
}