using System;
using System.IO;
using Framework.Driver;
using Framework.Services;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using GitHubAutomation.Tests;
using NUnit.Framework;
using GitHubAutomation.Utils;


namespace Framework.Tests
{
    class RussianRailwayTests : TestBase
    {
        const string expectedString = "Укажите другую станцию назначения";
        const string expectedStringForPastDate = "Укажите другую дату";
        const string expectedStringWithoutEnterPersonalData =
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
            "Поле \"Мобильный телефон\" должно быть заполнено.\r\n" +
            "Необходимо заполнить поле «E-mail».\r\n" +
            "Необходимо согласиться с условиями использования системы он-лайн продажи электронных железнодорожных билетов";
        const string expectedStringEnterPersonalDataWithWrongFormatDocumentType = "Пассажир № 1: Укажите, пожалуйста, номер паспорта в формате 1234 123456";
        const string expectedStringEnterPersonalDataWithWrongFormatEmail = "Пассажир № 1: Проверьте правильность формата вашего Email";
        const string expectedStringForWrongOrderNumber = "Заказа с таким номером не существует";
        const string expectedStrinerrorFormWithEmptyFields = "Номер заказа слишком короткий (Минимум: 14 симв.).\r\n" +
                                                             "Необходимо заполнить поле «Телефон или Email».\r\n" +
                                                             "Телефон или Email слишком короткий(Минимум: 6 симв.).";
        const string expectedStringForErrorFormSendingQuastionToAdmins = "Это поле обязательно для заполнения";
        [Test]
        public void SearchTicketsWithEmptyCityOfArrival()
        {

            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithAllProperties())
                .InputDateToDatepicker(RouteCreator.WithAllProperties())
                .ClickSearchingButton()
                .HoverOverFormErrorArrivalCity(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedString, beginningPage.formError.Text);

        }
        [Test]
        public void SearchTicketsWithTwoSameCities()
        {
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithEqualCities())
                .InputToStationToTextbox(RouteCreator.WithEqualCities())
                .InputDateToDatepicker(RouteCreator.WithEqualCities())
                .ClickSearchingButton()
                .HoverOverFormErrorArrivalCity(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedString, beginningPage.formError.Text);
        }
        [Test]
        public void SearchTicketsWithPastDate()
        {
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithPastDate())
                .InputToStationToTextbox(RouteCreator.WithPastDate())
                .InputDateToDatepicker(RouteCreator.WithPastDate())
                .ClickSearchingButton()
                .HoverOverFormErrorDate(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringForPastDate, beginningPage.formError.Text);
        }
        [Test]
        public void OrderingTicketWithoutEnteringPersonalData()
        {
            DateTime date = DateTime.Now;
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithAllProperties())
                .InputToStationToTextbox(RouteCreator.WithAllProperties())
                .InputDateToDatepicker(RouteCreator.WithAllProperties())
                .ClickSearchingButton();
            TrainSelectionPage trainSelectionPage = new TrainSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTrainButton(DriverSingleton.GetDriver());
            TypeOfWagonSelectionPage typeOfWagonSelectionPage = new TypeOfWagonSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTypeOfWagonButton(DriverSingleton.GetDriver())
                .ClickSelectingPlacesButton()
                .ClickContinueButton();
            PersonalDataPage personalDataPage = new PersonalDataPage(DriverSingleton.GetDriver())
                .ClickContinueButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringWithoutEnterPersonalData, personalDataPage.errorForm.Text);
        }
        [Test]
        public void OrderingTicketWithWrongFormatOfDocumentNumber()
        {
            DateTime date = DateTime.Now;
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithAllProperties())
                .InputToStationToTextbox(RouteCreator.WithAllProperties())
                .InputDateToDatepicker(RouteCreator.WithAllProperties())
                .ClickSearchingButton();
            TrainSelectionPage trainSelectionPage = new TrainSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTrainButton(DriverSingleton.GetDriver());
            TypeOfWagonSelectionPage typeOfWagonSelectionPage = new TypeOfWagonSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTypeOfWagonButton(DriverSingleton.GetDriver())
                .ClickSelectingPlacesButton()
                .ClickContinueButton();
            PersonalDataPage personalDataPage = new PersonalDataPage(DriverSingleton.GetDriver())
                .InputSurname(DriverSingleton.GetDriver(), UserCreator.WithWrongDocumentNumber())
                .InputName(UserCreator.WithWrongDocumentNumber())
                .InputPatronymic(UserCreator.WithWrongDocumentNumber())
                .ChooseDocument()
                .InputNumberDocument(UserCreator.WithWrongDocumentNumber())
                .InputBirthday(UserCreator.WithWrongDocumentNumber())
                .ClickGenderMale()
                .ClickPhoneCheckbox()
                .ClickAgreementConditionsCheckbox()
                .ClickContinueButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringEnterPersonalDataWithWrongFormatDocumentType, 
                personalDataPage.errorForm.Text);
        }
        [Test]
        public void OrderingTicketWithWrongFormatOfEmail()
        {
            DateTime date = DateTime.Now;
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClearAllFields()
                .InputToStationFromTextbox(RouteCreator.WithAllProperties())
                .InputToStationToTextbox(RouteCreator.WithAllProperties())
                .InputDateToDatepicker(RouteCreator.WithAllProperties())
                .ClickSearchingButton();
            TrainSelectionPage trainSelectionPage = new TrainSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTrainButton(DriverSingleton.GetDriver());
            TypeOfWagonSelectionPage typeOfWagonSelectionPage = new TypeOfWagonSelectionPage(DriverSingleton.GetDriver())
                .ClickSelectingTypeOfWagonButton(DriverSingleton.GetDriver())
                .ClickSelectingPlacesButton()
                .ClickContinueButton();
            PersonalDataPage personalDataPage = new PersonalDataPage(DriverSingleton.GetDriver())
                .InputSurname(DriverSingleton.GetDriver(), UserCreator.WithWrongEmail())
                .InputName(UserCreator.WithWrongEmail())
                .InputPatronymic(UserCreator.WithWrongEmail())
                .ChooseDocument()
                .InputNumberDocument(UserCreator.WithWrongEmail())
                .InputBirthday(UserCreator.WithWrongEmail())
                .ClickGenderMale()
                .ClickPhoneCheckbox()
                .ClickAgreementConditionsCheckbox()
                .ClickContinueButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringEnterPersonalDataWithWrongFormatEmail,
                personalDataPage.errorForm.Text);
        }
        [Test]
        public void EntryToSectionOrderManagementWithWrongOrderNumber()
        {
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClickManagmentOrdersButton();
            ControlOredersPage controlOredersPage = new ControlOredersPage(DriverSingleton.GetDriver())
                .InputOrderNumber(DriverSingleton.GetDriver(), UserCreator.WithAllProperties())
                .InputEmail(UserCreator.WithAllProperties())
                .ClickEntranceButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringForWrongOrderNumber, controlOredersPage.errorFormOrderNumber.Text);
        }
        [Test]
        public void EntryToSectionOrderManagementWithEmptyFields()
        {
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClickManagmentOrdersButton();
            ControlOredersPage controlOredersPage = new ControlOredersPage(DriverSingleton.GetDriver())
                .ClickEntranceButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStrinerrorFormWithEmptyFields, controlOredersPage.errorFormWithEmptyFields.Text);
        }

        [Test]
        public void SendingQuastionToAdminsWithEmptyFiels()
        {
            BeginningPage beginningPage = new BeginningPage(DriverSingleton.GetDriver())
                .ClickContacts();
            ContactsPage contacts = new ContactsPage(DriverSingleton.GetDriver())
                .ClickQuastionButton(DriverSingleton.GetDriver());
            Assert.AreEqual(expectedStringForErrorFormSendingQuastionToAdmins, contacts.errorMessage.Text);
        }


    }
}
