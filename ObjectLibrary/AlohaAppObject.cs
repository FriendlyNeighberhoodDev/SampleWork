using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
    public class AlohaAppObject
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Device { get; set; }
        public bool Active { get; set; }
        public DateTime LastImport { get; set; }
    }
}
