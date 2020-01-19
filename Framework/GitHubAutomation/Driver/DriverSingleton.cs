using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Driver
{
    class DriverSingleton
    {
        static IWebDriver driver;
        static IWebDriver driverForSeconThread;
        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }

        public static IWebDriver GetDriverForSecondThread()
        {
            if (driverForSeconThread == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driverForSeconThread = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driverForSeconThread = new ChromeDriver();
                        break;
                }
                driverForSeconThread.Manage().Window.Maximize();
            }
            return driverForSeconThread;
        }

        public static void CloseDriverForSecondThread()
        {
            driverForSeconThread.Quit();
            driverForSeconThread = null;
        }
    }
}
