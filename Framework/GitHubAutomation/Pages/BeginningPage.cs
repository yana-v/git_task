using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using Framework.Models;
using GitHubAutomation.Utils;


namespace GitHubAutomation.Pages
{
    class BeginningPage
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
        public IWebElement formError { get; set; }

        [FindsBy(How = How.XPath, Using = "//A[@class= 'header-menu-item-link g-fonts-order']")]
        public IWebElement managmentOrdersButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//A[@class='footer-menu-item'][text()='Контакты']")]
        public IWebElement contacts { get; set; }


        public BeginningPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public BeginningPage ClickSearchingButton()
        {
            searchingButton.Click();
            return this;
        }

        public BeginningPage ClickManagmentOrdersButton()
        {
            managmentOrdersButton.Click();
            return this;
        }

        public BeginningPage ClickContacts()
        {
            contacts.Click();
            return this;
        }


        public BeginningPage ClearAllFields()
        {
            stationFromTextbox.Clear();
            stationToTextbox.Clear();
            datepicker.Clear();
            return this;
        }

        public BeginningPage InputToStationFromTextbox(Route route)
        {
            stationFromTextbox.SendKeys(route.DepartureCity);
            return this;
        }

        public BeginningPage InputToStationToTextbox(Route route)
        {
            stationToTextbox.SendKeys(route.ArrivalCity);
            return this;
        }

        public BeginningPage InputDateToDatepicker(Route route)
        {
            datepicker.SendKeys(route.Date);
            return this;
        }

        public BeginningPage HoverOverFormErrorArrivalCity(IWebDriver browser)
        {
            WaitUtils.Time = 10;
            WaitUtils.Way = "//DIV[@class='form-error']";
            WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            Actions action = new Actions(browser);
            action.MoveToElement(stationToTextbox).Build().Perform();
            return this;
        }

        public BeginningPage HoverOverFormErrorDate(IWebDriver browser)
        {
            WaitUtils.Time = 10;
            WaitUtils.Way = "SearchForm[dateTo]";
            WaitUtils.WaitElementForUsingId(browser, WaitUtils.Way, WaitUtils.Time);
            Actions action = new Actions(browser);
            action.MoveToElement(datepicker).Build().Perform();
            return this;
        }


    }
}
