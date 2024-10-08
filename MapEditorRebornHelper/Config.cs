using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorRebornHelper
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        public bool ShouldDestroyPrimitive { get; set; } = false;
    }
}
