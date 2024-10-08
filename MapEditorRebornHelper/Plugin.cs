using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.Handlers;
using MapEditorReborn.Events.Handlers;
using MapEditorRebornHelper.Events;
using PluginAPI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorRebornHelper
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        public override string Author { get; } = "ScoutTrooper";
        public override string Name { get; } = "MapEditorRebornHelper";
        private EventHandlers _eventHandlers;
        private bool IsBeta = true;
        public static List<Door> CustomDoors = new List<Door>();
        public override void OnEnabled()
        {
            Instance = this;
            _eventHandlers = new EventHandlers();

            // Example for Registering Event - PluginEvents.CustomDoorInteracted += _eventHandlers.OnInteractingCustomDoor; 

            Exiled.Events.Handlers.Player.InteractingDoor += _eventHandlers.OnInteractingDoor_Event;
            Schematic.SchematicDestroyed += _eventHandlers.OnSchematicDestroyed;
            Schematic.SchematicSpawned += _eventHandlers.OnSchematicSpawned;

            if (IsBeta) Log.Warn("MapEditorRebornHelper installed version is Beta-Test. Use at your own risk.");

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.InteractingDoor -= _eventHandlers.OnInteractingDoor_Event;
            Schematic.SchematicDestroyed -= _eventHandlers.OnSchematicDestroyed;
            Schematic.SchematicSpawned -= _eventHandlers.OnSchematicSpawned;
            _eventHandlers = null;
            Instance = null;
            base.OnDisabled();
        }
    }

}
