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
    internal class AdminPanelLoginPage : Page
    {
        public AdminPanelLoginPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        [FindsBy(How = How.Name, Using = "username")]
        IWebElement UserName;
        [FindsBy(How = How.Name, Using = "password")]
        IWebElement UserPass;
        [FindsBy(How = How.Name, Using = "remember_me")]
        IWebElement RememberFlag;
        [FindsBy(How = How.Name, Using = "login")]
        IWebElement LoginBtn;

        internal void OpenAdminPage()
        {
            driver.Url = $"{baseUrl}admin/";
            wait.Until(ExpectedConditions.ElementExists(By.Id("box-login")));
        }

        internal AdminPanelLoginPage EntryUserName(string name)
        {
            UserName.Clear();
            UserName.SendKeys(name);
            return this;
        }
        internal AdminPanelLoginPage EntryUserPass(string pass)
        {
            UserPass.Clear();
            UserPass.SendKeys(pass);
            return this;
        }
        internal void SubmitLogin(bool flag = false)
        {
            if (flag)
                RememberFlag.Click();
            LoginBtn.Click();
        }
    }
}
