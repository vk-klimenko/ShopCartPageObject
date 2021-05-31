using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class AdminPanelMainPage: Page
    {
        public AdminPanelMainPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "box-apps-menu")]
        IWebElement Sections;
        [FindsBy(How = How.CssSelector, Using = "ul.docs")]
        IWebElement SubSections;
        [FindsBy(How = How.CssSelector, Using = "td#content h1")]
        IWebElement TitleH1;


        /// <summary>
        /// Получить список разделов левого меню
        /// </summary>
        /// <returns>Список</returns>
        internal IList<IWebElement> GetSections()
        {
            return Sections.FindElements(By.Id("app-"));
        }
        /// <summary>
        /// Получить список подразделов левого меню
        /// </summary>
        /// <returns>Список</returns>
        internal IList<IWebElement> GetSubSections()
        {
            return SubSections.FindElements(By.TagName("li"));
        }
        /// <summary>
        /// Проверка h1 элемента на странице
        /// </summary>
        /// <returns></returns>
        internal bool IsH1Present()
        {
            Console.Out.WriteLine(TitleH1.Text.Trim());
            return TitleH1.Displayed;
            
        }
        /// <summary>
        /// Проверка наличия подкатегорий
        /// </summary>
        /// <returns></returns>
        internal bool AreSubSectionsPresent()
        {
            try
            {
                return (SubSections.FindElements(By.TagName("li")).Count > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
