using ObjectLibrary;
using System.IO;
using System.Reflection;

namespace DataAccess
{
    public class AllStrDataAccess : DataAccessCall<AllStrObject>
    {
        public AllStrDataAccess()
        {
            ConnectionString = "XXXXXX";
            FilePath = "XXXXX";
            Provider = "System.Data.SqlClient";
            WhereClauseForSiteSearch = " XXXXX";
        }
    }
}

