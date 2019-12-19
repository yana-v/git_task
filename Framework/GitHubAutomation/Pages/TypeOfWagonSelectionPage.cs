using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    class TypeOfWagonSelectionPage
    {
        [FindsBy(How = How.XPath, Using = "//SPAN[@class='car-type__btn car-type__btn--select button button--border'][1]")]
        private IWebElement selectingTypeOfWagonButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//SPAN[contains(@class,'hint--top') or contains(@class,'hint--bottom') or contains(@class,'place-number')][1] ")]
        private IWebElement selectingPlacesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//BUTTON[contains(@id,'zabronirovat_')]")]
        private IWebElement continueButton { get; set; }

        public TypeOfWagonSelectionPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }


        public TypeOfWagonSelectionPage ClickSelectingTypeOfWagonButton(IWebDriver browser)
        {
            WaitUtils.Time = 10;
            WaitUtils.Way = "//SPAN[@class='car-type__btn car-type__btn--select button button--border'][1]";
            WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            selectingTypeOfWagonButton.Click();
            return this;
        }



        public TypeOfWagonSelectionPage ClickSelectingPlacesButton()
        {
            selectingPlacesButton.Click();
            return this;
        }

        public TypeOfWagonSelectionPage ClickContinueButton()
        {
            continueButton.Click();
            return this;
        }

    }
}

