using DataAccess;
using NUnit.Framework;
using System.Linq;

namespace SiteDataServicesTests
{
    [TestFixture]
    class DataAccessTests
    {
        [Test]
        [Category("Integration")]
        public void VerifyAllStrConnectionWorks()
        {
            var dataAccess = new AllStrDataAccess();
            var results = dataAccess.GetAllSitesFromDataStore();
            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        [Category("Integration")]
        public void VerifyAllStrConnectionWorksBySite()
        {
            var dataAccess = new AllStrDataAccess();
            var results = dataAccess.GetSiteFromDataStoreBySiteNumber(3);
            Assert.IsNotNull(results);
        }


        [Test]
        [Category("Integration")]
        public void VerifySiteWiseConnectionWorks()
        {
            var dataAccess = new SiteWiseDataAccess();
            var results = dataAccess.GetAllSitesFromDataStore();
            Assert.IsTrue(results.Count > 0);
        }


        [Test]
        [Category("Integration")]
        public void VerifySiteWiseConnectionWorksBySite()
        {
            var dataAccess = new SiteWiseDataAccess();
            var results = dataAccess.GetSiteFromDataStoreBySiteNumber(3);
            Assert.IsNotNull(results);
        }


        [Test]
        [Category("Integration")]
        public void VerifyVrfyVersConnectionWorks()
        {
            var dataAccess = new VrfyVersDataAccess();
            var results = dataAccess.GetAllSitesFromDataStore();
            Assert.IsTrue(results.Count > 0);
        }


        [Test]
        [Category("Integration")]
        public void VerifyVrfyVersConnectionWorksBySite()
        {
            var dataAccess = new VrfyVersDataAccess();
            var results = dataAccess.GetSiteFromDataStoreBySiteNumber(3);
            Assert.IsNotNull(results);
        }


        [Test]
        [Category("Integration")]
        public void VerifyPOSInfoConnectionWorks()
        {
            var dataAccess = new POSInfoDataAccess();
            var results = dataAccess.GetAllSitesFromDataStore();
            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        [Category("Integration")]
        public void VerifyACIDataAccessLoads()
        {
            var dataAccess = new ACIDataAccess();
            var results = dataAccess.GetActiveACIList();
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
        }
    }
}
