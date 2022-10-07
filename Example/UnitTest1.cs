using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Example
{
    [TestClass]
    class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArguments("--lang=ru-ru");
            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, new TimeSpan(0, 4, 0));
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://www.google.ru/";
            driver.FindElement(By.CssSelector("[name = 'q']")).SendKeys("Selenium");
            //driver.FindElement(By.CssSelector("[class = 'FPdoLc lJ9FBc'] [name = 'btnK']")).Click();
            driver.FindElement(By.CssSelector("[class = 'CqAVzb lJ9FBc'] [name = 'btnK']")).Click();
            Thread.Sleep(3000);
        }

        [TearDown]
        public void Stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}