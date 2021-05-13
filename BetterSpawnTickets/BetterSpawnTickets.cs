using System;
using System.Collections.Generic;
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
        //Plugin set-up stuff which I copied from a tutorial
        private static readonly Lazy<BetterSpawnTickets> LazyInstance = new Lazy<BetterSpawnTickets>(valueFactory: () => new BetterSpawnTickets());

        public static BetterSpawnTickets Instance => LazyInstance.Value;

        //Plugin priority determines when during startup the plugin gets loaded
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        //Event handlers
        private Handlers.Player player;

        private Handlers.Server server;

        private Handlers.Map map;

        //MTF can only be eliminated when this value is true - is set to true when MTF spawns.
        public static bool HasMTFSpawned = Instance.Config.EliminateMtfBeforeFirstWave;

        public static bool MtfEliminated = false;
        public static bool ChaosEliminated = false;

        //Copied from tutorial
        private BetterSpawnTickets()
        {
        }

        //Get the number of living players on Chaos' team
        public static int CountFoundationForces()
        {
            int returnVal = 0;

            foreach (Player player in Exiled.API.Features.Player.List)
            {
                //Increment returnVal for every player who is a scientist, guard, or NTF
                if (new List<RoleType> { RoleType.Scientist, RoleType.FacilityGuard, RoleType.NtfCadet, RoleType.NtfLieutenant, RoleType.NtfScientist, RoleType.NtfCommander }.Contains(player.Role))
                {
                    returnVal++;
                }
            }

            return returnVal;
        }

        public static void TeamsStayEliminatedLogic()
        {
            //TeamsStayEliminated logic
            if (Respawn.NtfTickets == 0) { BetterSpawnTickets.MtfEliminated = false; }
            if (BetterSpawnTickets.MtfEliminated && BetterSpawnTickets.Instance.Config.TeamsStayEliminated) { Respawn.GrantTickets(Respawning.SpawnableTeamType.NineTailedFox, -1 * Respawn.NtfTickets); }

            if (Respawn.ChaosTickets == 0) { BetterSpawnTickets.ChaosEliminated = false; }
            if (BetterSpawnTickets.ChaosEliminated && BetterSpawnTickets.Instance.Config.TeamsStayEliminated) { Respawn.GrantTickets(Respawning.SpawnableTeamType.ChaosInsurgency, -1 * Respawn.ChaosTickets); }
        }

        //Get the number of living players on the Foundation's team
        public static int CountChaosForces()
        {
            int returnVal = 0;

            foreach (Player player in Exiled.API.Features.Player.List)
            {
                //Increment returnVal for every player who is a chaos or class-d
                if (new List<RoleType> { RoleType.ChaosInsurgency, RoleType.ClassD }.Contains(player.Role))
                {
                    returnVal++;
                }
            }

            return returnVal;
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
            player = new Handlers.Player();
            server = new Handlers.Server();
            map = new Handlers.Map();

            PlayerHandler.Dying += player.OnDying;
            PlayerHandler.EscapingPocketDimension += player.EscapingPD;
            ServerHandler.RespawningTeam += server.OnRespawnWave;
            MapHandler.GeneratorActivated += map.OnGeneratorActivated;
            WarheadHandler.Detonated += map.OnWarheadDetonation;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            PlayerHandler.Dying -= player.OnDying;
            PlayerHandler.EscapingPocketDimension -= player.EscapingPD;
            ServerHandler.RespawningTeam -= server.OnRespawnWave;
            MapHandler.GeneratorActivated -= map.OnGeneratorActivated;
            WarheadHandler.Detonated -= map.OnWarheadDetonation;

            player = null;
            server = null;
            map = null;
        }
    }
}