using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.pages
{
    internal class CorrectOpenProductPage:Page
    {
        public CorrectOpenProductPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-campaigns .name")]
        internal IWebElement Name;
        [FindsBy(How = How.CssSelector, Using = "#box-campaigns s.regular-price")]
        internal IWebElement RegularPrice;
        [FindsBy(How = How.CssSelector, Using = "#box-campaigns strong.campaign-price")]
        internal IWebElement CampaignPrice;

        [FindsBy(How = How.CssSelector, Using = "#box-campaigns a.link")]
        internal IWebElement LinkCard;
        [FindsBy(How = How.CssSelector, Using = "#box-product h1.title")]
        internal IWebElement NameCard;
        [FindsBy(How = How.CssSelector, Using = "#box-product s.regular-price")]
        internal IWebElement RegularPriceCard;
        [FindsBy(How = How.CssSelector, Using = "#box-product strong.campaign-price")]
        internal IWebElement CampaignPriceCard;

        /// <summary>
        /// Получить CSS значение: цвет элемента Color
        /// </summary>
        /// <param name="el">IWebElement element</param>
        /// <returns></returns>
        internal string GetCssValue_Color(IWebElement el)
        {
            return el.GetCssValue("color").Replace("rgba(", "").TrimEnd(')');
        }

        /// <summary>
        /// Получить CSS значение: размер шрифта элемента Font Size
        /// </summary>
        /// <param name="el">IWebElement element</param>
        /// <returns></returns>
        internal string GetCssValue_FontSize(IWebElement el)
        {
            return el.GetCssValue("font-size").Replace("px", "").Replace(".", ",").Trim();
        }

        /// <summary>
        /// Получить CSS значение: перечеркнутый элемент Line Through
        /// </summary>
        /// <param name="el">IWebElement element</param>
        /// <returns></returns>
        internal string GetCssValue_LineThrough(IWebElement el)
        {
            return el.GetCssValue("text-decoration-line").Trim();
        }

        /// <summary>
        /// Получить CSS значение: Font Weighth
        /// </summary>
        /// <param name="el">IWebElement element</param>
        /// <returns></returns>
        internal string GetCssValue_FontWeighth(IWebElement el)
        {
            return el.GetCssValue("font-weight").Trim();
        }

        
    }
}
