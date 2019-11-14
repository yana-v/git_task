using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public class WagonAndPlaceSelectionPage
    {
        [FindsBy(How = How.XPath, Using = "//SPAN[@class='car-type__btn car-type__btn--select button button--border'][1]")]
        private IWebElement selectingTypeOfWagonButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//SPAN[contains(@class,'hint--top') or contains(@class,'hint--bottom')][1]")]
        private IWebElement selectingPlacesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//BUTTON[contains(@id,'zabronirovat_')]")]
        private IWebElement continueButton { get; set; }

        public WagonAndPlaceSelectionPage (IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }


        public WagonAndPlaceSelectionPage ClickSelectingTypeOfWagonButton(IWebDriver browser)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//SPAN[@class='car-type__btn car-type__btn--select button button--border'][1]")));
            selectingTypeOfWagonButton.Click();
            return this;
        }

        public WagonAndPlaceSelectionPage ClickSelectingPlacesButton()
        {
            selectingPlacesButton.Click();
            return this;
        }

        public WagonAndPlaceSelectionPage ClickContinueButton()
        {
            continueButton.Click();
            return this;
        }

    }
}
