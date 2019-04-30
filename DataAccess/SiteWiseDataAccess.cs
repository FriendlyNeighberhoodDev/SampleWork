using ObjectLibrary;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DataAccess
{
    public class SiteWiseDataAccess : DataAccessCall<SiteWiseObject>
    {
        public SiteWiseDataAccess()
        {
            ConnectionString = "XXXXX";
            FilePath = "XXXXX";
            Provider = "Oracle.ManagedDataAccess.Client";
            WhereClauseForSiteSearch = " XXXX ";
        }
    }
}
