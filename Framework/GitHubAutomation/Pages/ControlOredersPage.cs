using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using GitHubAutomation.Utils;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    class ControlOredersPage
    {
        [FindsBy(How = How.Name, Using = "OrderManagementForm[idExpress]")]
        private IWebElement numberOrderInput { get; set; }
        [FindsBy(How = How.Name, Using = "OrderManagementForm[phoneOrEmail]")]
        private IWebElement emailInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//BUTTON[@type='submit']")]
        private IWebElement entranceButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[text()='Заказа с таким номером не существует']")]
        public IWebElement errorFormOrderNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//DIV[@class='arcticmodal-block'][text()='Номер заказа слишком короткий (Минимум: 14 симв.).\r\n" +
                                            "Необходимо заполнить поле \"Телефон или Email\".\r\n" +
                                            "Телефон или Email слишком короткий(Минимум: 6 симв.).']")]
        public IWebElement errorFormWithEmptyFields { get; set; }

        public ControlOredersPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public ControlOredersPage InputOrderNumber(IWebDriver browser, User user)
        {
            WaitUtils.Time = 10;
            WaitUtils.Way = "OrderManagementForm[idExpress]";
            WaitUtils.WaitElementForUsingName(browser, WaitUtils.Way, WaitUtils.Time);
            numberOrderInput.SendKeys(user.NumberOrder);
            return this;
        }

        public ControlOredersPage InputEmail( User user)
        {
            emailInput.SendKeys(user.Email);
            return this;
        }

        public ControlOredersPage ClickEntranceButton(IWebDriver browser)
        {
            entranceButton.Click();
            WaitUtils.Time = 10;
            //WaitUtils.Way = "//li[text()='Номер заказа слишком короткий (Минимум: 14 симв.).\r\n" +
            //                                "Необходимо заполнить поле Телефон или Email».\r\n" +
            //                                "Телефон или Email слишком короткий(Минимум: 6 симв.).']";
            //WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            return this;
        }


    }
}
