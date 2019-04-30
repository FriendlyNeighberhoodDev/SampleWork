using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess<T>
    {
        List<T> GetAllSitesFromDataStore();
        T GetSiteFromDataStoreBySiteNumber(int siteNumber);
        List<T> GetDataPointsFromDataStoreBySiteNumber(int siteNumber);
    }
}
