using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public class TrainSelectionPage
    {
        [FindsBy(How = How.XPath, Using = "//A[@id='select_train'][1]")]
        private IWebElement selectingTrainButton { get; set; }

        public TrainSelectionPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public TrainSelectionPage ClickSelectingTrainButton( IWebDriver browser)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(35))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("select_train")));
            selectingTrainButton.Click();
            return this;
        }
        
    }
}
