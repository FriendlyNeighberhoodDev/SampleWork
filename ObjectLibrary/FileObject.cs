using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
    public class FileObject
    {
        public string Device { get; set; }
        public string FilePath { get; set; }
        public string Version { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Active { get; set; }
        public DateTime LastImport { get; set; }
    }
}
