using Antiproton;
using Antiproton.AntiprotonPageSetup;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class DeleteLabelComponent : PBarComponent
    {
        private LabelPage _labelPage;

        public DeleteLabelComponent(PBarDriver driver, LabelPage labelPage)
        {
            Driver = driver;
            _labelPage = labelPage;
        }

        protected PBarElement DeleteButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        public LabelPage ClickDeleteButton()
        {
            DeleteButton
                .Click();

            return _labelPage;
        }
    }
}
