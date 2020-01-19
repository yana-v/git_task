using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
namespace GitHubAutomation.Utils
{
    class WaitUtils
    {
        public static string Way {get; set;}
        public static int Time { get; set; }

        public static void WaitElementForUsingXPath(IWebDriver browser, string way, int time)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(time))
               .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(way)));
        }

        public static void WaitElementForUsingId(IWebDriver browser, string way, int time)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(time))
               .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(way)));
        }

        public static void WaitElementForUsingName(IWebDriver browser, string way, int time)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(time))
               .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name(way)));
        }

        public static void WaitFourteenMinutes(IWebDriver browser )
        {
            new WebDriverWait(browser, TimeSpan.FromMinutes(15))
               .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//DIV[@class='step-four-title timer error']/h1")));
        }

    }
}
