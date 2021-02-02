using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Antiproton.AntiprotonElements
{
    public class PBarTable : PBarElement
    {
        public PBarTable(PBarDriver driver, By elementIdentifier) : base(driver, elementIdentifier)
        {
        }

        public PBarTable(PBarDriver driver, IWebElement element) : base(driver, element)
        {
        }

        public PBarTable(PBarDriver driver, IWebElement element, By elementIdentifier) : base(driver, element, elementIdentifier)
        {
        }

        public PBarTable(PBarDriver driver, PBarElement element) : base(driver, element)
        {
        }
    }
}
