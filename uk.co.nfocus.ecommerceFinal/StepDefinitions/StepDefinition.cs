using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.nfocus.ecommerceFinal.PageObjectModels;
using uk.co.nfocus.ecommerceFinal.StepDefinitions;
using uk.co.nfocus.ecommerceFinal.Utilities;
using static uk.co.nfocus.ecommerceFinal.Utilities.TestBase;
using static uk.co.nfocus.ecommerceFinal.Utilities.WebpageInteractionMethods;
using static uk.co.nfocus.ecommerceFinal.Utilities.Customer;

namespace uk.co.nfocus.ecommerceFinal.StepDefinitions
{
    [Binding]
    public class StepDefinition : WebpageInteractionMethods
    {
        LandingPagePOM LandingPagePOM = new LandingPagePOM();
        LoginPOM LoginPOM = new LoginPOM();
        SelectItemPOM SelectItemPOM = new SelectItemPOM();
        CartPOM cartPOM = new CartPOM();
        CheckoutPOM checkoutPOM = new CheckoutPOM();
        OrderPOM OrderPOM = new OrderPOM();
        Customer customer = new Customer();


        string couponCode = "edgewords";
        decimal discountPercentage = 0.15m;
        string orderNumber;

        
        [Given(@"I am logged in with ""([^""]*)"" and ""([^""]*)""")]
        public void GivenIAmLoggedInWith(string email, string password)
        {
            
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";
  
            //Wait for disruptive javascript element to appear then remove it
            waitUntilDisplayed(wait, LandingPagePOM.bottomBanner);
            clickElement(driver, LandingPagePOM.bottomBanner);


            //Go to My Account
            waitUntilDisplayed(wait, LandingPagePOM.myAccountLink);
            clickElement(driver, LandingPagePOM.myAccountLink);


            //Login
            waitUntilDisplayed(wait, LoginPOM.login);
            clearElement(driver, LoginPOM.username);
            sendKeys(driver, LoginPOM.username, email);
            clearElement(driver, LoginPOM.password);
            sendKeys(driver, LoginPOM.password, password);
            clickElement(driver, LoginPOM.login);


            //Check Logged In
            waitUntilDisplayed(wait, LoginPOM.logout);
            Console.WriteLine("");
            Console.WriteLine("Log in successful!");
            Console.WriteLine("");
        }





        [Given(@"I have selected an item")]
        public void GivenIHaveSelectedAnItem()
        {
            
            //Go to Shop
            waitUntilDisplayed(wait, LoginPOM.topNavShop);
            clickElement(driver, LoginPOM.topNavShop);


            //Wait for element to disappear then add first shop item to cart
            waitUntilDisplayed(wait, SelectItemPOM.firstShopItem);
            clickElement(driver, SelectItemPOM.firstShopItem);
            Thread.Sleep(1000);


            //Check the cart button is loaded then click it
            waitUntilDisplayed(wait, SelectItemPOM.navBarCart);
            clickElement(driver, SelectItemPOM.navBarCart);
            
            Console.WriteLine("");
            Console.WriteLine("Item Selected!");
            Console.WriteLine("");
            
        }




        [When(@"I have applied the coupon code")]
        public void WhenIHaveAppliedTheCouponCode()
        {
            
            //Apply coupon code to purchase
            if (getElementCount(driver, cartPOM.removeCouponButton) > 0) { clickElement(driver, cartPOM.removeCouponButton); }
            waitUntilDisplayed(wait, cartPOM.couponInput);
            clearElement(driver, cartPOM.couponInput);
            sendKeys(driver, cartPOM.couponInput, couponCode);
            clickElement(driver, cartPOM.couponButton);
            Console.WriteLine("");
            Console.WriteLine("Coupon applied Sucsessfully!");
            Console.WriteLine("");
        }





        [Then(@"I should recieve the discount")]
        public void ThenIShouldRecieveTheDiscount()
        {
            
            //Check discount is applied and discounts the correct amount
            waitUntilDisplayed(wait, cartPOM.checkoutButton);
            waitUntilDisplayed(wait, cartPOM.discountAmount);
            decimal subtotalShipping = Convert.ToDecimal(getElementTextContent(driver, cartPOM.subtotal).Remove(0, 1));
            decimal total = Convert.ToDecimal(getElementTextContent(driver, cartPOM.total).Remove(0, 1));
            decimal discount = Math.Round(subtotalShipping * discountPercentage, 2);
            subtotalShipping = subtotalShipping + Convert.ToDecimal(getElementTextContent(driver, cartPOM.shipping).Remove(0, 1));

            bool couponCheck = false;
            if (total == (subtotalShipping - discount)) 
            { 
                couponCheck = true;
                Console.WriteLine("");
                Console.WriteLine("Correct discount given of: " + discount + "\nWith the total of: " + total);
                Console.WriteLine("");
                //reporting screenshot
                WebpageInteractionMethods.TakeScreenshot(driver, "Coupon applied");
                TestContext.AddTestAttachment(@"C:\Users\MamoonRaghib\Documents\nFocus\Screenshots\Coupon applied.png");
                TestContext.WriteLine("Screenshot of the checkout page");
                clickElement(driver, OrderPOM.myAccount);
            }
            else 
            { 
                couponCheck = false; 
            }

            try 
            { 
                Assert.That(couponCheck, "Sale cost with coupon should be: " + (subtotalShipping - discount) + "\nBut is: " + total); 
            }
            catch (AssertionException) 
            { 
            }
        }





        [Given(@"I have an item in my cart and logged in with ""([^""]*)"" and ""([^""]*)""")]
        public void IHaveAnItemInMyCart(string email, string password)
        {
            
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/";

            //Go to My Account
            waitUntilDisplayed(wait, LandingPagePOM.myAccountLink);
            

            //Wait for disruptive javascript element to appear then remove it
            waitUntilDisplayed(wait, LandingPagePOM.bottomBanner);
            clickElement(driver, LandingPagePOM.bottomBanner);

            clickElement(driver, LandingPagePOM.myAccountLink);
            

            //Login
            waitUntilDisplayed(wait, LoginPOM.login);
            clearElement(driver, LoginPOM.username);
            sendKeys(driver, LoginPOM.username, email);
            clearElement(driver, LoginPOM.password);
            sendKeys(driver, LoginPOM.password, password);
            clickElement(driver, LoginPOM.login);

            //Check Logged In
            waitUntilDisplayed(wait, LoginPOM.logout);
            Console.WriteLine("");
            Console.WriteLine("Logged in successfully!");

            //Go to Shop
            waitUntilDisplayed(wait, LoginPOM.topNavShop);
            clickElement(driver, LoginPOM.topNavShop);

            
            //Wait for element to disappear then add first shop item to cart
            waitUntilDisplayed(wait, SelectItemPOM.firstShopItem);
            clickElement(driver, SelectItemPOM.firstShopItem);
            Console.WriteLine("Item selected!");
            Console.WriteLine("");

            Thread.Sleep(1000);

            //Check the cart button is loaded then click it
            waitUntilDisplayed(wait, SelectItemPOM.navBarCart);
            clickElement(driver, SelectItemPOM.navBarCart);


        }




        [When(@"I have checked out")]
        public void IHaveCheckedOut()
        {
            

            //Check to make sure cart is successfully exited
            bool checkoutLoop = ClickElementValidationLoop(driver, wait, cartPOM.checkoutButton, checkoutPOM.url);
            Assert.That(checkoutLoop, "Checkout page failed to load");

            //Fill Checkout Fields
            waitUntilDisplayed(wait, checkoutPOM.firstName);
            clearElement(driver, checkoutPOM.firstName);
            
            sendKeys(driver, checkoutPOM.firstName, customer.getFirstName());
            clearElement(driver, checkoutPOM.lastName);
            sendKeys(driver, checkoutPOM.lastName, customer.getLastName());
           
            clearElement(driver, checkoutPOM.billingAddress);
            sendKeys(driver, checkoutPOM.billingAddress, customer.getBillingAddress());
            
            clearElement(driver, checkoutPOM.billingCity);
            sendKeys(driver, checkoutPOM.billingCity, customer.getBillingCity());
            
            clearElement(driver, checkoutPOM.billingPostcode);
            sendKeys(driver, checkoutPOM.billingPostcode, customer.getBillingPostcode());
            
            clearElement(driver, checkoutPOM.billingPhone);
            sendKeys(driver, checkoutPOM.billingPhone, customer.getBillingPhone());
           
            clearElement(driver, checkoutPOM.billingEmail);
            sendKeys(driver, checkoutPOM.billingEmail, customer.getBillingEmail());

            //Check to make sure checkout is successfully exited
            bool orderRecievedLoop = ClickElementValidationLoop(driver, wait, checkoutPOM.placeOrderButton, OrderPOM.url);
            Assert.That(orderRecievedLoop, "Order Details page failed to load");

            Console.WriteLine("");
            Console.WriteLine("Order placed!");

            
            //Get order number then go to orders
            waitUntilDisplayed(wait, OrderPOM.orderNumberElement);
            orderNumber = getElementTextContent(driver, OrderPOM.orderNumberElement);
            Console.WriteLine("Order number at check out is: " + orderNumber);
            Console.WriteLine("");
            //reporting screenshot
            WebpageInteractionMethods.TakeScreenshot(driver, "Order number from checkout");
            TestContext.AddTestAttachment(@"C:\Users\MamoonRaghib\Documents\nFocus\Screenshots\Order number from checkout.png");
            TestContext.WriteLine("Screenshot of the checkout page");
            clickElement(driver, OrderPOM.myAccount);

        }




        [Then(@"The order should appear in My Orders")]
        public void ThenTheOrderShouldAppearInMyOrders()
        {
            

            //Check if order number is present in orders
            waitUntilDisplayed(wait, LoginPOM.ordersNav);
            clickElement(driver, LoginPOM.ordersNav);
            waitUntilDisplayed(wait, LoginPOM.ordersTable);

            List<IWebElement> orders = new List<IWebElement>();
            orders.AddRange(driver.FindElements(LoginPOM.ordersTable));
            bool orderConfirmed = false;

            for (int i = 0; i < orders.Count(); i++)
            {
                string order = orders.ElementAt(i).Text;
                order = order.Remove(0, 1);
                if (order == orderNumber) 
                { 
                    orderConfirmed = true;
                    Console.WriteLine("");
                    Console.WriteLine("order number at checkout: " + orderNumber + 
                        " matches with order number in history: " + order);
                    Console.WriteLine("");
                    //reporting screenshot
                    WebpageInteractionMethods.TakeScreenshot(driver, "Order number from order history");
                    TestContext.AddTestAttachment(@"C:\Users\MamoonRaghib\Documents\nFocus\Screenshots\Order number from order history.png");
                    TestContext.WriteLine("Screenshot of the checkout page");
                }

            }

            try 
            { 
                Assert.That(orderConfirmed, "Order Not Found"); 
            }
            catch 
            (AssertionException) 
            { 
            }
        }
    }
}
