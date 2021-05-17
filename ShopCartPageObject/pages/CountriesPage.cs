using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class CountriesPage:Page
    {
        public CountriesPage(IWebDriver driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#content tr a[target='_blank']")]
        IList<IWebElement> Links;

        /// <summary>
        /// Открыть страну
        /// </summary>
        /// <param name="code">Код страны</param>
        internal void OpenCountry(string code)
        {
            driver.Url = $"http://litecart/admin/?app=countries&doc=edit_country&country_code={code}";
        }
        
        internal void OpenLink(string link)
        {
            driver.Url = link;
        }
        /// <summary>
        /// Открыть новое окно
        /// </summary>
        internal void OpenWindowTab()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.open()");
        }

        /// <summary>
        /// Получить Id текущего окна
        /// </summary>
        /// <returns>Id окна</returns>
        internal string GetIdCurrentWindow()
        {
            return driver.CurrentWindowHandle;
        }
        /// <summary>
        /// Получить все id открытых окон
        /// </summary>
        /// <returns>список id</returns>
        internal IList<string> GetIdWindowsTab()
        {
            return driver.WindowHandles;
        }

        /// <summary>
        /// Получить url's на странице
        /// </summary>
        /// <returns>url's</returns>
        internal List<string> GetLinks()
        {
            List<string> temp = new List<string>(); 
            foreach(IWebElement el in Links)
            {
                temp.Add(el.GetAttribute("href").Trim());
            }
            return temp;
        }
        /// <summary>
        /// Получить id нового окна. Ожидание появления окна
        /// </summary>
        /// <param name="windows">Список открытых окон</param>
        /// <returns>id нового окна</returns>
        internal string GetNewWindow(IList<string> windows)
        {
            return wait.Until(d => TryFindNewWindow(windows));
        }
        private string TryFindNewWindow(IList<string> windows)
        {
            IList<string> newHandles = driver.WindowHandles.Except(windows).ToList();
            return newHandles.Count > 0 ? newHandles[0] : null;
        }

        /// <summary>
        /// Перейти в новое окно
        /// </summary>
        /// <param name="id">id окна</param>
        internal void GoToWindowTab(string id)
        {
            driver.SwitchTo().Window(id);
        }
        /// <summary>
        /// Закрыть активное окно
        /// </summary>
        internal void CloseWindow()
        {
            driver.Close();
        }
    }
}
