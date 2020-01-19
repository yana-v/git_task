using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Framework.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    class ResevationPage
    {
        [FindsBy(How = How.XPath, Using = "//DIV[@class='step-four-title timer error']/h1")]
        public IWebElement errorText { get; set; }


        public ResevationPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }
    }
}
