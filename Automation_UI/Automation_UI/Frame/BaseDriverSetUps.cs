﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation_UI.PageObject
{
    [TestFixture(typeof(ChromeDriver))]
    public class BaseDriverSetUps<TWebDriver> where TWebDriver : IWebDriver, new() //нужен для того,чтобы класс тестов                                                                            //наследовался от этого класса
    {
        protected IWebDriver driver;
        private static readonly string url = "https://github.com/";

        [SetUp]
        public void runDriver()
        {
            this.driver = new TWebDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void quitDriver()
        {
            driver.Quit();
        }






        //internal static void CleanDriver()
        //{
        //    // Open new empty tab.
        //    IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
        //    js.ExecuteScript("window.open('');");

        //    // Close all tabs but one tab and delete all cookies.
        //    for (var tabs = driver.WindowHandles; tabs.Count > 1; tabs = driver.WindowHandles)
        //    {
        //        driver.SwitchTo().Window(tabs[0]);
        //        driver.Manage().Cookies.DeleteAllCookies();
        //        driver.Close();
        //    }

        //    // Switch to empty tab.
        //    driver.SwitchTo().Window(driver.WindowHandles[0]);
        //}

    }
}
