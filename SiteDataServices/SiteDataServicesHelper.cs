using DataAccess;
using ObjectLibrary;
using System.Collections.Generic;

namespace SiteDataServices
{
    public  class SiteDataServicesHelper
    {
        private IDataAccess<SiteWiseObject> SiteWiseDataAccess { get; set; }
        private IDataAccess<AllStrObject> AllStrDataAccess { get; set; }
        private IDataAccess<VrfyVersObject> VrfyVersDataAccess { get; set; }
        private IDataAccess<POSInfoObject> POSInfoDataAccess { get; set; }
        private IACIDataAccess ACIDataAccess { get; set; }

        public SiteDataServicesHelper()
        {
            SiteWiseDataAccess = new SiteWiseDataAccess();
            AllStrDataAccess = new AllStrDataAccess();
            VrfyVersDataAccess = new VrfyVersDataAccess();
            POSInfoDataAccess = new POSInfoDataAccess();
            ACIDataAccess = new ACIDataAccess();
        }

        public SiteDataServicesHelper(IDataAccess<SiteWiseObject> siteWiseDataAccess, IDataAccess<AllStrObject> allStrDataAccess, IDataAccess<VrfyVersObject> vrfyVersDataAccess, IDataAccess<POSInfoObject> posInfoDataAccess, IACIDataAccess aciDataAccess)
        {
            SiteWiseDataAccess = siteWiseDataAccess;
            AllStrDataAccess = allStrDataAccess;
            VrfyVersDataAccess = vrfyVersDataAccess;
            POSInfoDataAccess = posInfoDataAccess;
            ACIDataAccess = aciDataAccess;
        }

        public  List<SiteWiseObject> GetAllSitesFromSiteWise()
        {            
            return SiteWiseDataAccess.GetAllSitesFromDataStore();
        }

        public  List<AllStrObject> GetAllSitesFromAllStr()
        {
            return AllStrDataAccess.GetAllSitesFromDataStore();
        }

        public  List<VrfyVersObject> GetAllSitesFromVrfyVers()
        {
            return VrfyVersDataAccess.GetAllSitesFromDataStore();
        }

        public List<POSInfoObject> GetAllPOSInfoFromVrfyVers()
        {
            return POSInfoDataAccess.GetAllSitesFromDataStore();
        }

        public  List<Site> GetAllSiteData()
        {
            var siteList = new List<Site>();
            var siteWiseList = GetAllSitesFromSiteWise();
            var allStrList = GetAllSitesFromAllStr();
            var vrfyVersList = GetAllSitesFromVrfyVers();
            var posInfoList = GetAllPOSInfoFromVrfyVers();
            var aciActiveList = ACIDataAccess.GetActiveACIList();
            Site.AddOrUpdateSite(siteWiseList, siteList);
            Site.AddOrUpdateSite(allStrList, siteList);
            Site.AddOrUpdateSite(vrfyVersList, siteList);
            Site.AddOrUpdateSite(posInfoList, siteList);
            Site.AddOrUpdateSite(aciActiveList, siteList);
            return siteList;
        }

        public SiteWiseObject GetASiteFromSiteWiseBySiteNumber(int siteNumber)
        {
            return SiteWiseDataAccess.GetSiteFromDataStoreBySiteNumber(siteNumber);
        }

        public AllStrObject GetASiteFromAllStrBySiteNumber(int siteNumber)
        {
            return AllStrDataAccess.GetSiteFromDataStoreBySiteNumber(siteNumber);
        }

        public VrfyVersObject GetASiteFromVrfyVersBySiteNumber(int siteNumber)
        {
            return VrfyVersDataAccess.GetSiteFromDataStoreBySiteNumber(siteNumber);
        }

        public List<POSInfoObject> GetAlPOSInfoFromVrfyVersBySiteNumber(int siteNumber)
        {
            return POSInfoDataAccess.GetDataPointsFromDataStoreBySiteNumber(siteNumber);
        }

        public Site GetAllSiteDataBySiteNumber(int siteNumber)
        {
            var siteWiseSite = GetASiteFromSiteWiseBySiteNumber(siteNumber);
            var allStrSite = GetASiteFromAllStrBySiteNumber(siteNumber);
            var vrfyVersSite = GetASiteFromVrfyVersBySiteNumber(siteNumber);
            var posInfoList = GetAlPOSInfoFromVrfyVersBySiteNumber(siteNumber);
            var aciActiveList = ACIDataAccess.GetActiveACIList();
            var aciActive = aciActiveList == null ? "ERROR" : aciActiveList.Contains(siteNumber) ? "Y" : "N";
            return new Site { SiteNumber = siteNumber, POSSiteInformation = posInfoList, AllStrSiteInformation = allStrSite, SiteWiseSiteInformation = siteWiseSite, VrfyVersSiteInformation = vrfyVersSite, ACIActive = aciActive };
        }
    }
}
