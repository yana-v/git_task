using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace PageObject
{
    public class BeginningPage
    {
        [FindsBy(How = How.Name, Using = "SearchForm[stationNameFrom]")]
        private IWebElement stationFromTextbox { get; set; }

        [FindsBy(How = How.Name, Using = "SearchForm[stationNameTo]")]
        private IWebElement stationToTextbox { get; set; }

        [FindsBy(How = How.Name, Using = "SearchForm[dateTo]")]
        private IWebElement datepicker { get; set; }

        [FindsBy(How = How.XPath, Using = "//BUTTON[@type='button']")]
        private IWebElement searchingButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//DIV[@class='form-error']")]
        private IWebElement formError { get; set; }


        public BeginningPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public BeginningPage ClickSearchingButton()
        {
            searchingButton.Click();
            return this;
        }

        public BeginningPage ClearAllFields()
        {
            stationFromTextbox.Clear();
            stationToTextbox.Clear();
            datepicker.Clear();
            return this;
        }

        public BeginningPage InputToStationFromTextbox(string text)
        {
            stationFromTextbox.SendKeys(text);
            return this;
        }

        public BeginningPage InputToStationToTextbox(string text)
        {
            stationToTextbox.SendKeys(text);
            return this;
        }

        public BeginningPage InputDateToDatepicker(string date)
        {
            datepicker.SendKeys(date);
            return this;
        }

        public string GetErrorText(IWebDriver browser)
        {
            new WebDriverWait (browser,TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//DIV[@class='form-error']")));
            Actions action = new Actions(browser);
            action.MoveToElement(stationToTextbox).Build().Perform();
            return formError.Text; ;
        }

        


    }
}
