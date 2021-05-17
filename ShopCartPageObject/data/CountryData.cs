using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCartPageObject.data
{
    public class CountryData
    {
        public string MainWindowId { get; internal set; }
        public string Code { get; internal set; }
        public IList<string> ExistsWindows { get; internal set; }
        public IList<IWebElement> LinksTargetBlank { get; internal set; }

        public CountryData(string code)
        {
            Code = code;
        }
    }
}
