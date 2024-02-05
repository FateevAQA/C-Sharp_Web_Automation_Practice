﻿using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Tests.Drivers
{
    [Binding]
    public class WebDriverFactory
    {
        private IObjectContainer _objectContainer;
        private ChromeDriver _driver;

        public WebDriverFactory(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var _chromeOptions = new ChromeOptions();
            _chromeOptions.AddArguments(new[] {
                "--start-maximized",
                "--ignore-certificate-errors",
                "--disable-popup-blocking",
                "--no-sandbox",
             // "--headless",
                "--disable-dev-shm-usage" });

            _driver = new ChromeDriver(_chromeOptions);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
