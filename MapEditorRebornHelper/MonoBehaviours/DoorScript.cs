using MapEditorReborn.API.Features.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MapEditorRebornHelper.MonoBehaviours
{
    public class DoorScript : MonoBehaviour
    {
        public SchematicObject schematicObject;
        public Transform True_root;
        public Transform True_parent;
        public void Init(Transform Parent)
        {
            True_parent = Parent;
            True_root = Parent.root;
            schematicObject = Parent.root.GetComponent<SchematicObject>();
        }
    }
}
