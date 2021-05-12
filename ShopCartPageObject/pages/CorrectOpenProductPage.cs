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
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#box-campaigns .name")]
        internal IWebElement Name;
        [FindsBy(How = How.CssSelector, Using = "#box-campaigns s.regular-price")]
        internal IWebElement RegularPrice;
        [FindsBy(How = How.CssSelector, Using = "#box-campaigns strong.campaign-price")]
        internal IWebElement CampaignPrice;


        [FindsBy(How = How.CssSelector, Using = "#box-product h1.title")]
        internal IWebElement NameCard;
        [FindsBy(How = How.CssSelector, Using = "#box-product s.regular-price")]
        internal IWebElement RegularPriceCard;
        [FindsBy(How = How.CssSelector, Using = "#box-product strong.campaign-price")]
        internal IWebElement CampaignPriceCard;

        //internal string GetAttribute_TextContent(IWebElement el)
        //{
        //    return el.GetAttribute("textContent").Trim();
        //}

        internal string GetCssValue_Color(IWebElement el)
        {
            return el.GetCssValue("color").Replace("rgba(", "").TrimEnd(')');
        }

        internal string GetCssValue_FontSize(IWebElement el)
        {
            return el.GetCssValue("font-size").Replace("px", "").Replace(".", ",").Trim();
        }

        internal string GetCssLineThrough_Price(IWebElement el)
        {
            return el.GetCssValue("text-decoration-line").Trim();
        }

        internal string GetCssFontWeighth_CampaignPrice()
        {
            return CampaignPrice.GetCssValue("text-decoration-line").Trim();
        }

        
    }
}
