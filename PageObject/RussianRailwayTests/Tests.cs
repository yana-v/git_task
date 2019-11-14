using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using PageObject;
using PageObject.Pages;
using System.Collections.ObjectModel;
//using OpenQA.Selenium.Support.PageObjects;



namespace RussianRailwayTests
{
    [TestClass]
    public class Tests
    {
        
        IWebDriver webDriver;
        const string expectedStringForsSearchTicket = "Укажите другую станцию назначения";
        const string expectedStringEnterPersonalData =
            "Пассажир № 1: Необходимо заполнить поле \"Фамилия\"\r\n" +
            "Пассажир № 1: поле \"Фамилия\" должно иметь только русские буквы, дефис.\r\n" +
            "Пассажир № 1: Необходимо заполнить поле \"Имя\"\r\n" +
            "Пассажир № 1: поле \"Имя\" должно иметь только русские буквы, дефис.\r\n" +
            "Пассажир № 1: Необходимо заполнить поле \"Отчество\" или поставьте -\r\n" +
            "Пассажир № 1: поле \"Отчество\" должно иметь только русские буквы.\r\n" +
            "Пассажир № 1: поле \"Дата рождения\" неправильный формат даты\r\n" +
            "Пассажир № 1: поле \"Дата рождения\" указано не корректно\r\n" +
            "Пассажир № 1: Необходимо заполнить поле \"Серия и номер\"\r\n" +
            "Пассажир № 1: Укажите, пожалуйста, номер паспорта в формате 1234 123456\r\n" +
            "Пассажир № 1: Необходимо указать \"Пол\"\r\n" +
            "Выберите способ оплаты\r\n" +
            "Поле \"Мобильный телефон\" должно быть заполнено.\r\n" +
            "Необходимо заполнить поле «E-mail».\r\n" +
            "Необходимо согласиться с условиями использования системы он-лайн продажи электронных железнодорожных билетов";

        
        [TestInitialize]
        public void StartTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://rzd.poezda.net");
        }

        [TestMethod]
        public void SearchTicketsWithEmptyCityOfArrival()
        {
            DateTime date = DateTime.Now;
            BeginningPage beginningPage = new BeginningPage(webDriver).ClearAllFields()
                .InputToStationFromTextbox("Бобруйск")
                .InputDateToDatepicker(date.AddDays(1).ToShortDateString())
                .ClickSearchingButton();
            Assert.AreEqual(expectedStringForsSearchTicket, beginningPage.GetErrorText(webDriver));

        }

        [TestMethod]
        public void OrderingTicketWithoutEnteringPersonalData()
        {
            DateTime date = DateTime.Now;
            BeginningPage beginningPage = new BeginningPage(webDriver).ClearAllFields()
                .InputToStationFromTextbox("Бобруйск")
                .InputToStationToTextbox("Минск")
                .InputDateToDatepicker(date.AddDays(1).ToShortDateString())
                .ClickSearchingButton();
            TrainSelectionPage trainSelectionPage = new TrainSelectionPage(webDriver)
                .ClickSelectingTrainButton(webDriver);
            WagonAndPlaceSelectionPage typeOfWagonSelectionPage = new WagonAndPlaceSelectionPage(webDriver)
                .ClickSelectingTypeOfWagonButton(webDriver)
                .ClickSelectingPlacesButton()
                .ClickContinueButton();
            PersonalDataPage personalDataPage = new PersonalDataPage(webDriver)
                .ClickContinueButton(webDriver);
            Assert.AreEqual(expectedStringEnterPersonalData, personalDataPage.GetErrorText(webDriver));
        }

        [TestCleanup]
        public void FinishTest()
        {
          webDriver.Quit();
        }
    }
}
