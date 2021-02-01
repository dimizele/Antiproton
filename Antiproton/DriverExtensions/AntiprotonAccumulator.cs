using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton.DriverExtensions
{
    public class AntiprotonAccumulator
    {
        public PBarDriver CreateChromeDriver(TimeSpan timeout)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");

            PBarDriver driver = new PBarDriver(new ChromeDriver(options));

            driver.Manage().Timeouts().PageLoad = timeout;
            driver.Manage().Timeouts().ImplicitWait = timeout;
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
