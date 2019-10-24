using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTestProjectее
{
    [TestClass]
    public class RussianRailwaysTests
    {
        IWebDriver webDriver;
        const string expectedStringForOrderTicket = "Укажите другую станцию назначения";
        const string expectedStringForManagmentOrders = "Заказа с таким номером не существует";

        [TestInitialize]
        public void StartTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://rzd.poezda.net");
        }

        [TestMethod]
        public void SearchTicketsWithTwoSameCities()
        {

            var stationFrom = GetWebElementByName("SearchForm[stationNameFrom]");
            var stationTo = GetWebElementByName("SearchForm[stationNameTo]");
            var datepicker = GetWebElementByName("SearchForm[dateTo]");
            var searchingButton = webDriver.FindElement(By.XPath("//BUTTON[@type='button']"));
            stationFrom.Clear();
            stationTo.Clear();
            stationFrom.SendKeys("Бобруйск");
            stationTo.SendKeys("Бобруйск");
            DateTime date = DateTime.Now;
            datepicker.Click();
            datepicker.SendKeys(date.AddDays(1).ToShortDateString());
            searchingButton.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            var formError = GetWebElementByXPath("//DIV[@class='form-error']");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            Assert.AreEqual(expectedStringForOrderTicket, formError.Text);
        }
        [TestMethod]
        public void EntryToSectionOrderManagementWithWrongOrderNumber()
        {

            var managmentOrdersButton = GetWebElementByXPath("//A[@class= 'header-menu-item-link g-fonts-order']");
            managmentOrdersButton.Click();
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            var numberOrder = GetWebElementByName("OrderManagementForm[idExpress]");
            var email = GetWebElementByName("OrderManagementForm[phoneOrEmail]");
            var entranceButton = GetWebElementByXPath("//BUTTON[@type='submit']");
            numberOrder.SendKeys("213456712345678901345");
            email.SendKeys("ivan-v-1971@yandex.by");
            entranceButton.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            var errorForm = GetWebElementByXPath("/html/body/div[6]/table/tbody/tr/td/div/div[2]/ul/li");
            Assert.AreEqual(expectedStringForManagmentOrders, errorForm.Text);
            
        }

        [TestCleanup]
        public void FinishTest()
        {
            webDriver.Quit();
        }

        private IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
        private IWebElement GetWebElementByName(string name)
        {
            return webDriver.FindElement(By.Name(name));
        }


    }
}
