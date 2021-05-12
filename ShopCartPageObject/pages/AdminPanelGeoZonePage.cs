using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class AdminPanelGeoZonePage:Page
    {
        internal List<string> ZoneCountry = new List<string>();
        internal List<string> ZoneCountrySort = new List<string>();
        private By href = By.CssSelector("tr.row td:nth-child(3) a");
        

        public AdminPanelGeoZonePage(IWebDriver driver): base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "table.dataTable tr.row")]
        internal IList<IWebElement> GeoZones;
        [FindsBy(How = How.XPath, Using = "//select[@name='zones[1][zone_code]']/option[position()>1]")]
        internal IList<IWebElement> OptionSelect;

        internal void OpenPageZone()
        {
            driver.Url = "http://litecart/admin/?app=geo_zones&doc=geo_zones";
        }

        internal string GetUrlZone(IWebElement el)
        {
            return el.FindElement(href).GetAttribute("href");
        }
        
        internal bool IsGeoZoneSort()
        {
            try
            {
                Console.Out.WriteLine("GeoZone sorted");
                return ZoneCountry.SequenceEqual(ZoneCountrySort);

            }
            catch (Exception)
            {
                Console.Out.WriteLine("GeoZone are NOT sorted");
                return false;
            }
        }

    }
}
