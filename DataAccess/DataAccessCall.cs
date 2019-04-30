using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataAccess
{
    public class DataAccessCall<T> : IDataAccess<T>
    {
        protected string ConnectionString { get; set; }
        protected string Provider { get; set; }
        protected string FilePath { get; set; }
        protected string WhereClauseForSiteSearch { get; set; }


        public List<T> GetAllSitesFromDataStore()
        {
            var conn = DbProviderFactories.GetFactory(Provider).CreateConnection();
            conn.ConnectionString = ConnectionString;
            using (var context = new DataModelContext(conn))
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(FilePath))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var script = reader.ReadToEnd();
                    var dataModels = context.Database.SqlQuery<T>(script);
                    return dataModels.ToList();
                }
            }
        }

        public T GetSiteFromDataStoreBySiteNumber(int siteNumber)
        {
            var conn = DbProviderFactories.GetFactory(Provider).CreateConnection();
            conn.ConnectionString = ConnectionString;
            using (var context = new DataModelContext(conn))
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(FilePath))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var script = reader.ReadToEnd() + WhereClauseForSiteSearch + siteNumber;
                    var dataModel = context.Database.SqlQuery<T>(script);
                    return dataModel.FirstOrDefault();
                }
            }
        }

        public List<T> GetDataPointsFromDataStoreBySiteNumber(int siteNumber)
        {
            var conn = DbProviderFactories.GetFactory(Provider).CreateConnection();
            conn.ConnectionString = ConnectionString;
            using (var context = new DataModelContext(conn))
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(FilePath))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var script = reader.ReadToEnd() + WhereClauseForSiteSearch + siteNumber;
                    var dataModels = context.Database.SqlQuery<T>(script);
                    return dataModels.ToList();
                }
            }
        }

    public partial class DataModelContext : DbContext
    {
        public DataModelContext(DbConnection conn) : base(conn, true)
        {

        }
    }
}
