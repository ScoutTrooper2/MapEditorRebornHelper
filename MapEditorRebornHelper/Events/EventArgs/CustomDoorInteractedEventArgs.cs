using Exiled.API.Features.Doors;
using MapEditorReborn.API.Features.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MapEditorRebornHelper.Events.EventArgs
{
    public class CustomDoorInteractedEventArgs
    {
        public Door Door { get; }
        public SchematicObject Schematic { get; }
        public Transform Parent {  get; }
        public CustomDoorInteractedEventArgs(Door door, SchematicObject schematicObject, Transform parent)
        {
            Door = door;
            Schematic = schematicObject;
            Parent = parent;
        }
    }
}
