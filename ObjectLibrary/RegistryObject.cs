using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
    public class RegistryObject
    {
        public string Device { get; set; }
        public string RegistryHive { get; set; }
        public string RegistryKey { get; set; }
        public bool Active { get; set; }
        public DateTime LastImport { get; set; }
    }
}
