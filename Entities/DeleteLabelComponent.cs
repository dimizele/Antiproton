using Antiproton;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class DeleteLabelComponent
    {
        public PBarDriver Driver { get; set; }

        private LabelPage _labelPage;

        public DeleteLabelComponent(PBarDriver driver, LabelPage labelPage)
        {
            Driver = driver;
            _labelPage = labelPage;
        }

        protected PBarElement Component => new PBarElement(Driver, By.TagName("Dialog"));

        protected PBarElement DeleteButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        public LabelPage ClickDeleteButton()
        {
            DeleteButton
                .Click();

            return _labelPage;
        }
    }
}
