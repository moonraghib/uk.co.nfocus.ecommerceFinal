using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.Utilities
{
    [Binding]
    public class TestBase
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;

        [BeforeScenario]
        public void Setup()
        {
            //choosing browser to perform test on
            string browser = Environment.GetEnvironmentVariable("BROWSER");
            switch (browser)
            {
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    Console.WriteLine("NO browser or unknown browser");
                    Console.WriteLine("Using Chrome");
                    driver = new ChromeDriver();
                    break;

            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.FindElement(By.LinkText("My account")).Click();
            driver.FindElement(By.LinkText("Log out")).Click();

            Console.WriteLine("");
            Console.WriteLine("Log out Sucessful");
            Console.WriteLine("Test has been completed");
            driver.Quit();
        }
    }
}

