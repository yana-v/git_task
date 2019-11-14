using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public class PersonalDataPage
    {
        [FindsBy(How = How.XPath, Using = "//BUTTON[@class='button button--blue']")]
        private IWebElement continueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//DIV[@class='arcticmodal error-modal']")]
        private IWebElement errorForm { get; set; }

        public PersonalDataPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public PersonalDataPage ClickContinueButton(IWebDriver browser)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10))
               .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//BUTTON[@class='button button--blue']")));
            continueButton.Click();
            return this;
        }
        public string GetErrorText(IWebDriver browser)
        {
            new WebDriverWait(browser, TimeSpan.FromSeconds(10))
              .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//DIV[@class='arcticmodal error-modal']")));
            return errorForm.Text;
        }
    }
}
