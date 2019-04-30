using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary
{
    public  class Site
    {
        public int SiteNumber { get; set; }
        public string ACIActive { get; set; }
        public VrfyVersObject VrfyVersSiteInformation { get; set; }
        public SiteWiseObject SiteWiseSiteInformation { get; set; }
        public AllStrObject AllStrSiteInformation { get; set; }
        public List<POSInfoObject> POSSiteInformation { get; set; }
        public ImageObject Image { get; set; }

        public Site()
        {
            POSSiteInformation = new List<POSInfoObject>();
        }

        public static void AddOrUpdateSite(List<SiteWiseObject> siteWiseList, List<Site> siteList)
        {
            foreach (var siteWiseSite in siteWiseList)
            {
                var site = siteList.FirstOrDefault(s => s.SiteNumber == siteWiseSite.SiteNumber);
                var addToList = false;
                if (site == null)
                {
                    addToList = true;
                    site = new Site { SiteNumber = siteWiseSite.SiteNumber };
                }
                site.SiteWiseSiteInformation = siteWiseSite;
                if (addToList) siteList.Add(site);
            }
        }

        public static void AddOrUpdateSite(List<AllStrObject> allStrList, List<Site> siteList)
        {
            foreach (var allStrSite in allStrList)
            {
                var site = siteList.FirstOrDefault(s => s.SiteNumber == allStrSite.SiteNumber);
                var addToList = false;
                if (site == null)
                {
                    addToList = true;
                    site = new Site { SiteNumber = allStrSite.SiteNumber };
                }
                site.AllStrSiteInformation = allStrSite;
                if (addToList) siteList.Add(site);
            }
        }

        public static void AddOrUpdateSite(List<VrfyVersObject> vrfyVersList, List<Site> siteList)
        {
            foreach (var vrfyVersSite in vrfyVersList)
            {
                var site = siteList.FirstOrDefault(s => s.SiteNumber == vrfyVersSite.SiteNumber);
                var addToList = false;
                if (site == null)
                {
                    addToList = true;
                    site = new Site { SiteNumber = vrfyVersSite.SiteNumber };
                }
                site.VrfyVersSiteInformation = vrfyVersSite;
                if (addToList) siteList.Add(site);
            }
        }

        public static void AddOrUpdateSite(List<POSInfoObject> posList, List<Site> siteList)
        {
            foreach (var posSite in posList)
            {
                var site = siteList.FirstOrDefault(s => s.SiteNumber == posSite.SiteNumber);
                var addToList = false;
                if (site == null)
                {
                    addToList = true;
                    site = new Site { SiteNumber = posSite.SiteNumber };
                }
                site.POSSiteInformation.Add(posSite);
                if (addToList) siteList.Add(site);
            }
        }

        public static void AddOrUpdateSite(List<int> activeList, List<Site> siteList)
        {
            foreach (var site in siteList)
            {
                site.ACIActive = activeList == null ? "ERROR" : "N";
            }
            foreach(var activeSite in activeList)
            {
                var site = siteList.FirstOrDefault(s => s.SiteNumber == activeSite);
                if (site != null)
                {
                    site.ACIActive = "Y";
                }
            }
        }
    }
}
