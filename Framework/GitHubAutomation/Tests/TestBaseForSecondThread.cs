using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    class TestBaseForSecondThread
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void StartTest()
        {
            Driver = DriverSingleton.GetDriverForSecondThread();
            Driver.Navigate().GoToUrl("https://rzd.poezda.net");
        }

        [TearDown]
        public void FinishTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }
            DriverSingleton.CloseDriverForSecondThread();
        }
    }
}

