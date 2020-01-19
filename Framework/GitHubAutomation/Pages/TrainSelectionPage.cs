using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    class TrainSelectionPage
    {
        [FindsBy(How = How.XPath, Using = "//A[@id='select_train'][1]")]
        private IWebElement selectingTrainButton { get; set; }

        public TrainSelectionPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public TrainSelectionPage ClickSelectingTrainButton(IWebDriver browser)
        {
            WaitUtils.Time = 60;
            WaitUtils.Way = "select_train";
            WaitUtils.WaitElementForUsingId(browser, WaitUtils.Way, WaitUtils.Time);
            selectingTrainButton.Click();
            return this;
        }

    }
}
