using Exiled.API.Enums;
using Exiled.API.Features.Doors;
using MapEditorReborn.API.Features.Objects;
using MapEditorRebornHelper.Enums;
using MapEditorRebornHelper.Enums.DoorEnums;
using MapEditorRebornHelper.MonoBehaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MapEditorRebornHelper.Extensions
{
    public static class DoorManager
    {
        public static PrefabType GetDoor(DoorTypeZone doorTypeZone)
        {
            switch (doorTypeZone)
            {
                case DoorTypeZone.DoorHCZ:
                    return PrefabType.HCZBreakableDoor;
                    break;
                case DoorTypeZone.DoorEZ:
                    return PrefabType.EZBreakableDoor;
                    break;
                case DoorTypeZone.DoorLCZ:
                    return PrefabType.LCZBreakableDoor;
                    break;
                default:
                    return PrefabType.HCZBreakableDoor;
                    break;
            }
        }
        public static bool IsCustomSchematicDoor(this Door door) => Plugin.CustomDoors.Contains(door);
        public static SchematicObject GetSchematicObject(this Door door) => door.GameObject.GetComponent<DoorScript>().schematicObject;
        public static Transform GetParent(this Door door) => door.GameObject.GetComponent<DoorScript>().True_parent;
    }
}
