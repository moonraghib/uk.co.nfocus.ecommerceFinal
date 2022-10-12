using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.PageObjectModels
{
    public class LandingPagePOM
    {
        public string url = "https://www.edgewordstraining.co.uk/demo-site/";
        public By bottomBanner = By.CssSelector("body > p > a");
        public By myAccountLink = By.LinkText("My account");
    }
}
