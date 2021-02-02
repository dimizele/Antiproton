using Antiproton;
using Antiproton.AntiprotonPageSetup;
using Helpers;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class AddAndEditLabelComponent : PBarComponent
    {
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

        protected PBarElement LabelNameInput => new PBarElement(Driver, By.Id("accountName"));

        protected PBarElement ColorSelector => new PBarElement(Driver, Component.FindElement(By.CssSelector(".flex-item-noshrink.pm-button")));

        protected PBarElement ColorSelectorList => new PBarElement(Driver, By.ClassName("ColorSelector-container"));

        protected List<PBarElement> AllColorsList => ColorSelectorList.FindElements(By.TagName("li")).ToList();

        protected PBarElement SaveButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        public AddAndEditLabelComponent FillLabelName(string labelName)
        {
            LabelNameInput
                .ClearWithCtrlADelete()
                .SendKeys(labelName);

            return this;
        }

        public AddAndEditLabelComponent ChooseLabelColor()
        {
            ColorSelector
                .Click();

            PBarElement selectedColor = AllColorsList.RandomListItem();

            LabelColor = selectedColor.GetAttribute("style").Split('(')[1].Split(')')[0];

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
