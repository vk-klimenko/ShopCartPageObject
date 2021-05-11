using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class AdminPanelCountriesPage:Page
    {
        public List<string> Countries = new List<string>();
        public List<string> ByZones = new List<string>();
        public AdminPanelCountriesPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How = How.CssSelector, Using = "td:nth-child(6n)")]
        IWebElement Zone { get; set; }
        
        public void OpenAdminCountriesPage()
        {
            driver.Url = "http://litecart/admin/?app=countries&doc=countries";
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
        }
        /// <summary>
        /// Получить страны
        /// </summary>
        /// <returns></returns>
        internal IList<IWebElement> GetCountries()
        {
            return driver.FindElements(By.CssSelector("tr.row"));
        }
        /// <summary>
        /// Получить зоны в стране
        /// </summary>
        /// <returns></returns>
        internal IList<IWebElement> GetCountriesZone()
        {
            return driver.FindElements(By.XPath(".//table[@id='table-zones']//tr[position() > 1 and position() < last()]"));
        }
        /// <summary>
        /// Получить Url страны
        /// </summary>
        /// <param name="zoneurl"></param>
        /// <returns></returns>
        internal string GetCountryUrl(IWebElement el)
        {
            return el.FindElement(By.CssSelector("td:nth-child(5n) a")).GetAttribute("href");
        }
        /// <summary>
        /// Получить название страны
        /// </summary>
        /// <param name="zoneurl"></param>
        /// <returns></returns>
        internal string GetCountryName(IWebElement el)
        {
            return el.FindElement(By.CssSelector("td:nth-child(5n) a")).GetAttribute("innerText").Trim();
        }

        /// <summary>
        /// ПОлучить кол-во зон в стране
        /// </summary>
        /// <returns></returns>
        internal int GetZoneCount()
        {
            return Convert.ToInt32(Zone.GetAttribute("textContent"));
        }

        /// <summary>
        /// Проверка сортировки стран
        /// </summary>
        /// <param name="listSort"></param>
        /// <returns></returns>
        internal bool IsCountriesSort(List<string> listSort)
        {
            try
            {
                Console.Out.WriteLine("Countries sorted");
                return Countries.SequenceEqual(listSort);
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Countries are NOT sorted");
                return false;
            }
        }

        /// <summary>
        /// Проверка сортировки зон стран
        /// </summary>
        /// <param name="listSort"></param>
        /// <returns></returns>
        internal bool IsCountriesZoneSort(List<string> listSort)
        {
            try
            {
                Console.Out.WriteLine("Countries zone sorted");
                return ByZones.SequenceEqual(listSort);
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Countries zone are NOT sorted");
                return false;
            }
        }



    }
}
