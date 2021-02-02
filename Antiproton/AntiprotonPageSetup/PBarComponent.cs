using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton.AntiprotonPageSetup
{
    public class PBarComponent
    {
        public PBarDriver Driver { get; set; }

        protected PBarElement Component => new PBarElement(Driver, By.TagName("Dialog"));

        protected PBarElement CancelButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));
    }
}
