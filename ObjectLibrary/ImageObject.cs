using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
    public class ImageObject
    {
        public List<FileObject> Files { get; set; }
        public List<AlohaAppObject> AlohaApps { get; set; }
        public List<NonAlohaAppObject> NonAlohaApps { get; set; }
        public List<RegistryObject> RegistryItems { get; set; }
        public List<string> SiteNumbers { get; set; }
        public string ImageName { get; set; }
        public string ImageLongName { get; set; }
    }
}
