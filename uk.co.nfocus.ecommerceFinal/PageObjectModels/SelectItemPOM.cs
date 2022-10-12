using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.PageObjectModels
{
    public class SelectItemPOM
    {
        public string url = "https://www.edgewordstraining.co.uk/demo-site/shop/";
        public By firstShopItem = By.CssSelector(".columns-3.products :first-child> a:nth-child(2)");
        public By navBarCart = By.CssSelector("ul#site-header-cart .count");
    }
}
