using ObjectLibrary;
using System.IO;
using System.Reflection;

namespace DataAccess
{
    public class POSInfoDataAccess : DataAccessCall<POSInfoObject>
    {
        public POSInfoDataAccess()
        {
            ConnectionString = "XXXX";
            FilePath = "XXXXX";
            Provider = "System.Data.SqlClient";
            WhereClauseForSiteSearch = " XXXXX ";
        }
    }
}
