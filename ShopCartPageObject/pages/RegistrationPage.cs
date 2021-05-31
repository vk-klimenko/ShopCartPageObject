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
    internal class RegistrationPage:Page
    {
        public RegistrationPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "firstname")]
        internal IWebElement FirstNameInput;
        [FindsBy(How = How.Name, Using = "lastname")]
        internal IWebElement LastNameInput;
        [FindsBy(How = How.Name, Using = "address1")]
        internal IWebElement AddressInput;
        [FindsBy(How = How.Name, Using = "postcode")]
        internal IWebElement PostcodeInput;
        [FindsBy(How = How.Name, Using = "city")]
        internal IWebElement CityInput;
        [FindsBy(How = How.Name, Using = "email")]
        internal IWebElement EmailInput;
        [FindsBy(How = How.Name, Using = "phone")]
        internal IWebElement PhoneInput;
        [FindsBy(How = How.Name, Using = "password")]
        internal IWebElement PasswordInput;
        [FindsBy(How = How.Name, Using = "confirmed_password")]
        internal IWebElement ConfirmedPasswordInput;

        [FindsBy(How = How.Name, Using = "create_account")]
        internal IWebElement CreateAccountButton;

        [FindsBy(How = How.XPath, Using = ".//div[@id='box-account']//a[.='Logout']")]
        IWebElement LogoutLink;

        [FindsBy(How = How.Name, Using = "login")]
        internal IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "form[name='login_form'] input[name='email']")]
        internal IWebElement EmailLogin;
        [FindsBy(How = How.CssSelector, Using = "form[name='login_form'] input[name='password']")]
        internal IWebElement PassLogin;

        internal void OpenPage()
        {
            driver.Url = "http://litecart/en/create_account";
            wait.Until(ExpectedConditions.TitleIs("Create Account | E-Shop"));
        }

        internal void Logout()
        {
            wait.Until(d => d.FindElement(By.XPath(".//div[@id='box-account']//a[.='Logout']")));
            LogoutLink.Click();
        }

        internal RegistrationPage AuthCustomer(string mail, string pass)
        {
            wait.Until(d => d.FindElement(By.CssSelector("form[name='login_form']")));
            EmailInput.SendKeys(mail);
            PasswordInput.SendKeys(pass);
            return this;
        }

        internal void SelectCountry(string country)
        {
            driver.FindElement(By.CssSelector("[id ^= select2-country_code]")).Click();
            driver.FindElement(By.CssSelector(
                    String.Format(".select2-results__option[id $= {0}]", country))).Click();
        }

        internal void SelectZone(string zone)
        {
            wait.Until(d => d.FindElement(
                    By.CssSelector(String.Format("select[name=zone_code] option[value={0}]", zone))));
            new SelectElement(driver.FindElement(By.CssSelector("select[name=zone_code]"))).SelectByValue(zone);
        }

    }
}
