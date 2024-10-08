using Exiled.Events.EventArgs.Server;
using MapEditorRebornHelper.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorRebornHelper.Events
{
    public class PluginEvents
    {
        public static event Action<CustomDoorInteractedEventArgs> CustomDoorInteracted;
        public static void OnCustomDoorInteracted(CustomDoorInteractedEventArgs ev)
        {
            PluginEvents.CustomDoorInteracted?.Invoke(ev);
        }
    }
}
