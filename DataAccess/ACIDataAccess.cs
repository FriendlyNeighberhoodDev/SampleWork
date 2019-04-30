using ObjectLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataAccess
{
    public class ACIDataAccess : IACIDataAccess 
    {
        public List<int> GetActiveACIList()
        {
            var directory = new DirectoryInfo(@"XXXXX");
            using (var rd = new StreamReader(directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First().FullName))
            {
                try
                {
                    var siteList = new List<int>();
                    while (!rd.EndOfStream)
                    {
                        var site = rd.ReadLine();
                        if (!site.Equals("Site", System.StringComparison.OrdinalIgnoreCase))
                            siteList.Add(int.Parse(site));
                    }
                    return siteList;
                }
                catch
                {
                    return null;
                }
            }
            
        }
    }
}
