using Antiproton;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Entities
{
    public class LabelPage : PBarPage
    {
        protected override string RelativePageUrl { get; set; } = "settings/labels";
        protected override string PageDomainPrefix { get; set; } = "beta";

        private AddAndEditLabelComponent labelComponent;

        protected PBarElement LabelSection => new PBarElement(Driver, By.Id("labellist"));

        protected PBarElement AddLabelButton => new PBarElement(Driver, LabelSection.FindElement(By.TagName("button")));

        protected PBarElement LabelsTable => new PBarElement(Driver, LabelSection.FindElement(By.TagName("table")));

        protected PBarElement FolderSection => new PBarElement(Driver, By.Id("folderlist"));

        protected PBarElement AddFolderButton => new PBarElement(Driver, FolderSection.FindElement(By.TagName("button")));

        public AddAndEditLabelComponent ClickAddLabelButton()
        {
            AddLabelButton
                .Click();

            labelComponent = new AddAndEditLabelComponent(Driver, this);

            return labelComponent;
        }

        public LabelPage VerifyCreatedLabelColor()
        {
            PBarElement labelColor = Driver.FindElements(By.TagName("td"))[1];

            Assert.AreEqual(labelComponent.LabelColor, labelColor);

            return this;
        }
    }
}
