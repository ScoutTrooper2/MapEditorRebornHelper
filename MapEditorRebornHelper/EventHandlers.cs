using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using Interactables.Interobjects.DoorUtils;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;
using MapEditorReborn.Events.EventArgs;
using MapEditorRebornHelper.Enums;
using MapEditorRebornHelper.Enums.DoorEnums;
using MapEditorRebornHelper.Events;
using MapEditorRebornHelper.Events.EventArgs;
using MapEditorRebornHelper.Extensions;
using MapEditorRebornHelper.MonoBehaviours;
using MEC;
using Mirror;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static PlayerList;

namespace MapEditorRebornHelper
{
    public class EventHandlers
    {
        public void OnSchematicDestroyed(SchematicDestroyedEventArgs ev)
        {
            var doorsToRemove = Plugin.CustomDoors.Where(x => x.GameObject.GetComponent<DoorScript>().True_root.name == ev.Schematic.transform.root.name).ToList();

            foreach (var door in doorsToRemove)
            {
                Plugin.CustomDoors.Remove(door);
                NetworkServer.Destroy(door.GameObject);
            }
        }
        public void OnInteractingDoor_Event(InteractingDoorEventArgs ev)
        {
            if (DoorManager.IsCustomSchematicDoor(ev.Door) == false) return;

            CustomDoorInteractedEventArgs rev = new CustomDoorInteractedEventArgs(ev.Door, DoorManager.GetSchematicObject(ev.Door), DoorManager.GetParent(ev.Door));
            PluginEvents.OnCustomDoorInteracted(rev);
        }
        public void OnSchematicSpawned(SchematicSpawnedEventArgs ev)
        {
            foreach (var Door in ev.Schematic.AttachedBlocks.Where(x => x.name.StartsWith("Door_")))
            {
                string doorName = Door.name;
                string[] parts = doorName.Split('_');

                // Door_{DoorType}_{Name}_{AllowToInteract}_{IsLocked}_{DoorHealth}_{DoorIgnoredDamages}_{DoorRequiredPermissions}
                if (parts.Length >= 8) 
                {
                    if (Enum.TryParse(parts[1], out DoorTypeZone doorType)) { Log.Debug("DoorType Parse Completed"); } else { Log.Error("Failed to Parse DoorType"); return; }
                    string name = parts[2]; 
                    if (bool.TryParse(parts[3], out bool allowToInteract)) { Log.Debug("allowToInteract Parse Completed"); } else { Log.Error("allowToInteract to Parse IsLocked"); return; }
                    if (bool.TryParse(parts[4], out bool isLocked)) { Log.Debug("IsLocked Parse Completed"); } else { Log.Error("Failed to Parse IsLocked"); return; }
                    if (int.TryParse(parts[5], out int doorHealth)) { Log.Debug("Health has been parsed"); } else { Log.Error("Failed to Parse Health"); return; }
                    if (Enum.TryParse(parts[6], out DoorDamageType doorIgnoredDamages)) { Log.Debug("doorIgnoredDamages Parse Completed"); } else { Log.Error("Failed to Parse doorIgnoredDamages"); return; }
                    if (Enum.TryParse(parts[7], out Interactables.Interobjects.DoorUtils.KeycardPermissions DoorRequiredPermissions)) { Log.Debug("DoorRequiredPermissions Parse Completed"); } else { Log.Error("Failed to Parse DoorRequiredPermissions"); return; }

                    GameObject gameObject = PrefabHelper.Spawn(Extensions.DoorManager.GetDoor(doorType), Door.transform.position, Door.transform.rotation);                                                                         

                    Door door = Exiled.API.Features.Doors.Door.Get(gameObject.GetComponentInParent<DoorVariant>());

                    DoorObject doorObject = door.GameObject.AddComponent<DoorObject>().Init(new MapEditorReborn.API.Features.Serializable.DoorSerializable() { DoorHealth = doorHealth, IgnoredDamageSources = doorIgnoredDamages, KeycardPermissions = DoorRequiredPermissions });

                    if (isLocked) door.ChangeLock(DoorLockType.AdminCommand);

                    door.GameObject.name = name;

                    door.Scale = Door.GetComponent<PrimitiveObject>().Scale;

                    Log.Debug($"Door `{door.Name}` transform position = {door.Transform.position}, scale = {door.Scale}");

                    door.GameObject.AddComponent<DoorScript>().Init(Door.transform.parent);

                    Plugin.CustomDoors.Add(door);

                    if (Plugin.Instance.Config.ShouldDestroyPrimitive) NetworkServer.Destroy(Door); else { Door.transform.position = new Vector3(0f, 0f, 0f); }
                }
                else
                {
                    Log.Error($"Door '{doorName}' has failed name.");
                }
            }
        }
    }
}
