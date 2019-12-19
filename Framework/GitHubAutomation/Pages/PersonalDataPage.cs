using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using GitHubAutomation.Utils;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    class PersonalDataPage
    {
        [FindsBy(How = How.XPath, Using = "//BUTTON[@class='button button--blue']")]
        private IWebElement continueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//DIV[@class='arcticmodal error-modal']")]
        public IWebElement errorForm { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_surname")]
        public IWebElement surnameInput { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_name")]
        public IWebElement nameInput { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_patronymic")]
        public IWebElement patronymicInput { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_documentTypeSelectBoxIt")]
        public IWebElement documentTypeSelection { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-id='3']")]
        public IWebElement foreignPasport { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_documentNumber")]
        public IWebElement numberDocumentInput { get; set; }

        [FindsBy(How = How.Id, Using = "AdultDocumentForm_1_dateofbirth")]
        public IWebElement birthdayInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//SPAN[@class='form-gender-item-text item-male']")]
        public IWebElement genderMaleButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//SPAN[@class='check-text'][text()= 'Нет российского номера']")]
        public IWebElement phoneCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "CustomerForm_mail")]
        public IWebElement emailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//SPAN[@class='check-icon'][3]")]
        public IWebElement AgreementWithConditionsCheckbox { get; set; }


        public PersonalDataPage(IWebDriver browser)
        {
            PageFactory.InitElements(browser, this);
        }

        public PersonalDataPage ClickContinueButton(IWebDriver browser)
        {
            WaitUtils.Time = 30;
            WaitUtils.Way = "//BUTTON[@class='button button--blue']";
            WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            continueButton.Click();
            WaitUtils.Way = "//DIV[@class='arcticmodal error-modal']";
            WaitUtils.WaitElementForUsingXPath(browser, WaitUtils.Way, WaitUtils.Time);
            return this;
        }

        public PersonalDataPage InputSurname (IWebDriver browser, User user)
        {
            WaitUtils.Time = 30;
            WaitUtils.Way = "AdultDocumentForm_1_surname";
            WaitUtils.WaitElementForUsingId(browser, WaitUtils.Way, WaitUtils.Time);
            surnameInput.SendKeys(user.Surname);
            return this;
        }

        public PersonalDataPage InputName(User user)
        {
            nameInput.SendKeys(user.Name);
            return this;
        }

        public PersonalDataPage InputPatronymic(User user)
        {
            patronymicInput.SendKeys(user.Patronymic);
            return this;
        }

        public PersonalDataPage ChooseDocument()
        {
            documentTypeSelection.Click();
            foreignPasport.Click();
            return this;
        }

        public PersonalDataPage InputNumberDocument(User user)
        {
            numberDocumentInput.SendKeys(user.documentNumber);
            return this;
        }

        public PersonalDataPage InputBirthday(User user)
        {
            birthdayInput.SendKeys(user.Birthday);
            return this;
        }

        public PersonalDataPage ClickGenderMale()
        {
            genderMaleButton.Click();
            return this;
        }

        public PersonalDataPage ClickPhoneCheckbox()
        {
            phoneCheckbox.Click();
            return this;
        }

        public PersonalDataPage ClickAgreementConditionsCheckbox()
        {
            AgreementWithConditionsCheckbox.Click();
            return this;
        }




    }
}
