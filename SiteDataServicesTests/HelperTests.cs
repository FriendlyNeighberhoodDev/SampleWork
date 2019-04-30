using NUnit.Framework;
using ObjectLibrary;
using System.Collections.Generic;
using System.Linq;
using Moq;
using DataAccess;
using SiteDataServices;

namespace SiteDataServicesTests
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        public void VerifyGetAllSitesFromSiteWise()
        {           
            var siteWiseDataAccessMock = new Mock<IDataAccess<SiteWiseObject>>();
            siteWiseDataAccessMock.Setup(mock => mock.GetAllSitesFromDataStore()).Returns(new List<SiteWiseObject> { new SiteWiseObject { SiteNumber = 1234, DiningRoomActive = "Y", FreestyleDrivethruFlag = "Y", FreestyleFlag = "Y", KioskActiveCount = 2, PickUpWindowActive = "N", MobileOrderingActive = "Y", CopScreenActive = "Y" } });
            var helper = new SiteDataServicesHelper(siteWiseDataAccessMock.Object, new AllStrDataAccess(), new VrfyVersDataAccess(), new POSInfoDataAccess(), new ACIDataAccess());
            var siteList = helper.GetAllSitesFromSiteWise();
            var site = siteList.FirstOrDefault(s => s.SiteNumber == 1234);
            Assert.IsTrue(siteList.Count == 1);
            Assert.IsNotNull(site);
            Assert.AreEqual("Y", site.DiningRoomActive);
            Assert.AreEqual("Y", site.FreestyleDrivethruFlag);
            Assert.AreEqual("Y", site.FreestyleFlag);
            Assert.AreEqual(2, site.KioskActiveCount);
            Assert.AreEqual("N", site.PickUpWindowActive);
            Assert.AreEqual("Y", site.MobileOrderingActive);
            Assert.AreEqual("Y", site.CopScreenActive);
        }

        [Test]
        public void VerifyGetASiteFromSiteWiseBySiteNumber()
        {
            var siteWiseDataAccessMock = new Mock<IDataAccess<SiteWiseObject>>();
            siteWiseDataAccessMock.Setup(mock => mock.GetSiteFromDataStoreBySiteNumber(It.IsAny<int>())).Returns(new SiteWiseObject { SiteNumber = 1234, DiningRoomActive = "Y", FreestyleDrivethruFlag = "Y", FreestyleFlag = "Y", KioskActiveCount = 2, PickUpWindowActive = "N", MobileOrderingActive = "Y", CopScreenActive = "Y" });
            var helper = new SiteDataServicesHelper(siteWiseDataAccessMock.Object, new AllStrDataAccess(), new VrfyVersDataAccess(), new POSInfoDataAccess(), new ACIDataAccess());
            var site = helper.GetASiteFromSiteWiseBySiteNumber(1234);
            Assert.IsNotNull(site);
            Assert.AreEqual("Y", site.DiningRoomActive);
            Assert.AreEqual("Y", site.FreestyleDrivethruFlag);
            Assert.AreEqual("Y", site.FreestyleFlag);
            Assert.AreEqual(2, site.KioskActiveCount);
            Assert.AreEqual("N", site.PickUpWindowActive);
            Assert.AreEqual("Y", site.MobileOrderingActive);
            Assert.AreEqual("Y", site.CopScreenActive);
        }

        [Test]
        public void VerifyGetAllSitesFromAllStr()
        {
            var allStrDataAccessMock = new Mock<IDataAccess<AllStrObject>>();
            allStrDataAccessMock.Setup(mock => mock.GetAllSitesFromDataStore()).Returns(new List<AllStrObject> { new AllStrObject { SiteNumber = 1234, BreakfastFlag = "N", CombinationName = "Combo Name", CombinationNumber = 4444, CopAdiName = "Adi Name",
                CopAdiNumber = 5555, CustomerSelfOrderFlag = "Y", CustomerWIFIFlag = "N", DeliveryFlag = "Y", DeliveryProviderName = "GrubHub",
                MobilePayFlag = "Y", SiteName = "Flagship" } });
            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), allStrDataAccessMock.Object, new VrfyVersDataAccess(), new POSInfoDataAccess(), new ACIDataAccess());
            var siteList = helper.GetAllSitesFromAllStr();
            var site = siteList.FirstOrDefault(s => s.SiteNumber == 1234);
            Assert.IsTrue(siteList.Count == 1);
            Assert.IsNotNull(site);
            Assert.AreEqual("N", site.BreakfastFlag);
            Assert.AreEqual("Combo Name", site.CombinationName);
            Assert.AreEqual(4444, site.CombinationNumber);
            Assert.AreEqual("Adi Name", site.CopAdiName);
            Assert.AreEqual(5555, site.CopAdiNumber);
            Assert.AreEqual("Y", site.CustomerSelfOrderFlag);
            Assert.AreEqual("N", site.CustomerWIFIFlag);
            Assert.AreEqual("Y", site.DeliveryFlag);
            Assert.AreEqual("GrubHub", site.DeliveryProviderName);
            Assert.AreEqual("Y", site.MobilePayFlag);
            Assert.AreEqual("Flagship", site.SiteName);
        }

        [Test]
        public void VerifyGetASiteFromAllStrBySiteNumber()
        {
            var allStrDataAccessMock = new Mock<IDataAccess<AllStrObject>>();
            allStrDataAccessMock.Setup(mock => mock.GetSiteFromDataStoreBySiteNumber(It.IsAny<int>())).Returns(new AllStrObject
            {
                SiteNumber = 1234,
                BreakfastFlag = "N",
                CombinationName = "Combo Name",
                CombinationNumber = 4444,
                CopAdiName = "Adi Name",
                CopAdiNumber = 5555,
                CustomerSelfOrderFlag = "Y",
                CustomerWIFIFlag = "N",
                DeliveryFlag = "Y",
                DeliveryProviderName = "GrubHub",
                MobilePayFlag = "Y",
                SiteName = "Flagship"
            });
            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), allStrDataAccessMock.Object, new VrfyVersDataAccess(), new POSInfoDataAccess(), new ACIDataAccess());
            var site = helper.GetASiteFromAllStrBySiteNumber(1234);
            Assert.IsNotNull(site);
            Assert.AreEqual("N", site.BreakfastFlag);
            Assert.AreEqual("Combo Name", site.CombinationName);
            Assert.AreEqual(4444, site.CombinationNumber);
            Assert.AreEqual("Adi Name", site.CopAdiName);
            Assert.AreEqual(5555, site.CopAdiNumber);
            Assert.AreEqual("Y", site.CustomerSelfOrderFlag);
            Assert.AreEqual("N", site.CustomerWIFIFlag);
            Assert.AreEqual("Y", site.DeliveryFlag);
            Assert.AreEqual("GrubHub", site.DeliveryProviderName);
            Assert.AreEqual("Y", site.MobilePayFlag);
            Assert.AreEqual("Flagship", site.SiteName);
        }

        [Test]
        public void VerifyGetAllSitesFromVrfyVers()
        {
            var vrfyVersDataAccessMock = new Mock<IDataAccess<VrfyVersObject>>();
            vrfyVersDataAccessMock.Setup(mock => mock.GetAllSitesFromDataStore()).Returns(new List<VrfyVersObject> { new VrfyVersObject { SiteNumber = 1234, AlohaVersion = "14.2.32", Reason = "N", SupportedBy = "DUMAC" } });
            var posInfoDataAccessMock = new Mock<IDataAccess<POSInfoObject>>();
            posInfoDataAccessMock.Setup(mock => mock.GetAllSitesFromDataStore()).Returns(new List<POSInfoObject> { new POSInfoObject { SiteNumber = 1234, Device = "MWS01234", ManufactureModel = "IBM" },
                new POSInfoObject { SiteNumber = 1234, Device = "MWS01234", ManufactureModel = "IBM 4840" } });

            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), new AllStrDataAccess(), vrfyVersDataAccessMock.Object, posInfoDataAccessMock.Object, new ACIDataAccess());
            var siteList = helper.GetAllSitesFromVrfyVers();
            var site = siteList.FirstOrDefault(s => s.SiteNumber == 1234);
            Assert.IsTrue(siteList.Count == 1);
            Assert.IsNotNull(site);
            Assert.AreEqual("14.2.32", site.AlohaVersion);
            Assert.AreEqual("N", site.Reason);
            Assert.AreEqual("DUMAC", site.SupportedBy);
        }

        [Test]
        public void VerifGetASiteFromVrfyVersBySiteNumber()
        {
            var vrfyVersDataAccessMock = new Mock<IDataAccess<VrfyVersObject>>();
            vrfyVersDataAccessMock.Setup(mock => mock.GetSiteFromDataStoreBySiteNumber(It.IsAny<int>())).Returns(new VrfyVersObject { SiteNumber = 1234, AlohaVersion = "14.2.32", Reason = "N", SupportedBy = "DUMAC" } );
            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), new AllStrDataAccess(), vrfyVersDataAccessMock.Object, new POSInfoDataAccess(), new ACIDataAccess());
            var site = helper.GetASiteFromVrfyVersBySiteNumber(1234);
            Assert.IsNotNull(site);
            Assert.AreEqual("14.2.32", site.AlohaVersion);
            Assert.AreEqual("N", site.Reason);
            Assert.AreEqual("DUMAC", site.SupportedBy);
        }

        [Test]
        public void VerifyGetAllSitesFromPOSInfo()
        {
            var posInfoDataAccessMock = new Mock<IDataAccess<POSInfoObject>>();
            posInfoDataAccessMock.Setup(mock => mock.GetAllSitesFromDataStore()).Returns(new List<POSInfoObject> { new POSInfoObject { SiteNumber = 1234, Device = "MWS01234", ManufactureModel = "IBM" } });
            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), new AllStrDataAccess(), new VrfyVersDataAccess(), posInfoDataAccessMock.Object, new ACIDataAccess());
            var siteList = helper.GetAllPOSInfoFromVrfyVers();
            var site = siteList.FirstOrDefault(s => s.SiteNumber == 1234);
            Assert.IsTrue(siteList.Count == 1);
            Assert.IsNotNull(site);
            Assert.AreEqual("MWS01234", site.Device);
            Assert.AreEqual("IBM", site.ManufactureModel);
        }

        [Test]
        public void VerifyGetPOSInfoForSite()
        {
            var posInfoDataAccessMock = new Mock<IDataAccess<POSInfoObject>>();
            posInfoDataAccessMock.Setup(mock => mock.GetDataPointsFromDataStoreBySiteNumber(It.IsAny<int>())).Returns(new List<POSInfoObject> { new POSInfoObject { SiteNumber = 1234, Device = "MWS01234", ManufactureModel = "IBM" } });
            var helper = new SiteDataServicesHelper(new SiteWiseDataAccess(), new AllStrDataAccess(), new VrfyVersDataAccess(), posInfoDataAccessMock.Object, new ACIDataAccess());
            var siteList = helper.GetAlPOSInfoFromVrfyVersBySiteNumber(1234);
            var site = siteList.FirstOrDefault(s => s.SiteNumber == 1234);
            Assert.IsTrue(siteList.Count == 1);
            Assert.IsNotNull(site);
            Assert.AreEqual("MWS01234", site.Device);
            Assert.AreEqual("IBM", site.ManufactureModel);
        }

        [Test]
        [Category("Integration")]
        public void VerifyGetAllSiteDataWorksWithLiveData()
        {
            var helper = new SiteDataServicesHelper();
            var sites = helper.GetAllSiteData();
            Assert.IsNotNull(sites);
            Assert.IsTrue(sites.Count > 0);
        }
    }
}
