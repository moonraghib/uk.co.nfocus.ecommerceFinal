using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.PageObjectModels
{
    public class LoginPOM
    {
        public string url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
        public By username = By.Id("username");
        public By password = By.Id("password");
        public By login = By.CssSelector("button[name='login']");
        public By logout = By.LinkText("Logout");
        public By topNavShop = By.LinkText("Shop");
        public By ordersNav = By.CssSelector(".woocommerce-MyAccount-navigation-link.woocommerce-MyAccount-navigation-link--orders > a");
        public By ordersTable = By.CssSelector(".woocommerce-orders-table__cell.woocommerce-orders-table__cell-order-number");
    }
}
