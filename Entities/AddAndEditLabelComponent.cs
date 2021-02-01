using Antiproton;
using Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class AddAndEditLabelComponent
    {
        public PBarDriver Driver { get; set; }

        private string _labelColor;
        private LabelPage _labelPage;

        public AddAndEditLabelComponent(PBarDriver driver, LabelPage labelPage)
        {
            Driver = driver;
            _labelPage = labelPage;
        }

        public string LabelColor
        {
            get
            {
                return _labelColor;
            }
            set
            {
                _labelColor = value;
            }
        }

        protected PBarElement Component => new PBarElement(Driver, By.TagName("Dialog"));

        protected PBarElement LabelName => new PBarElement(Driver, By.Id("accountName"));

        protected PBarElement ColorSelector => new PBarElement(Driver, Component.FindElement(By.CssSelector(".flex-item-noshrink.pm-button")));

        protected PBarElement ColorSelectorList => new PBarElement(Driver, By.ClassName("ColorSelector-container"));

        protected List<PBarElement> AllColorsList => ColorSelectorList.FindElements(By.TagName("li")).ToList();

        protected PBarElement SaveButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        protected PBarElement CancelButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        public AddAndEditLabelComponent FillLabelName(string labelName = null)
        {
            LabelName
                .Clear()
                .SendKeys(labelName ?? RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13)));

            return this;
        }

        public AddAndEditLabelComponent ChooseLabelColor()
        {
            ColorSelector
                .Click();

            PBarElement selectedColor = AllColorsList.RandomListItem();

            LabelColor = selectedColor.GetAttribute("value");

            selectedColor.Click();

            return this;
        }

        public LabelPage ClickSaveButton()
        {
            SaveButton
                .Click();

            return _labelPage;
        }

        public LabelPage ClickCancelButton()
        {
            CancelButton
                .Click();

            return _labelPage;
        }
    }
}
