using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Framework.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    class ContactsPage
    {
        [FindsBy(How = How.XPath, Using = "//INPUT[@class='btVer3']")]
        private IWebElement sendQuastionButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//LABEL[text()='Это поле обязательно для заполнения.'][1]")]
        public IWebElement errorMessage { get; set; }

        public ContactsPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public ContactsPage ClickQuastionButton(IWebDriver browser)
        {
            WaitUtils.Time = 20;
            WaitUtils.Way = "//INPUT[@class='btVer3']";
            WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            sendQuastionButton.Click();
            return this;
        }


    }
}
