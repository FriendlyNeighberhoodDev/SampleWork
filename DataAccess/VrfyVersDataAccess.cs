using ObjectLibrary;
using System.IO;
using System.Reflection;

namespace DataAccess
{
    public class VrfyVersDataAccess : DataAccessCall<VrfyVersObject>
    {
        public VrfyVersDataAccess()
        {
            ConnectionString = "XXXXX";
            FilePath = "XXXX";
            Provider = "System.Data.SqlClient";
            WhereClauseForSiteSearch = " XXXXX ";
        }
    }
}
