using Antiproton;
using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class LabelPage : PBarPage
    {
        protected override string RelativePageUrl { get; set; } = "settings/labels";
        protected override string PageDomainPrefix { get; set; } = "beta";

        private AddAndEditLabelComponent addlabelComponent;
        private DeleteLabelComponent deleteLabelComponent;

        protected List<PBarElement> NotificationList => Driver.FindElements(NotificationLocator).ToList();

        protected PBarElement LabelSection => new PBarElement(Driver, By.CssSelector("section[data-target-id='labellist']"));

        protected PBarElement AddLabelButton => new PBarElement(Driver, LabelSection.FindElement(By.TagName("button")));

        protected PBarElement LabelsTable => new PBarElement(Driver, LabelSection.FindElement(By.TagName("tbody")));

        protected List<PBarElement> LabelsList => LabelsTable.FindElements(By.TagName("tr")).ToList();

        protected PBarElement LabelDropDownDeleteButton => new PBarElement(Driver, By.CssSelector("button[data-test-id='folders/labels:item-delete']"));

        protected PBarElement FolderSection => new PBarElement(Driver, By.CssSelector("section[data-target-id='folderlist']"));

        protected PBarElement AddFolderButton => new PBarElement(Driver, FolderSection.FindElement(By.TagName("button")));

        protected By NotificationLocator = By.CssSelector(".notification-success");

        protected By LabelEditButton = By.CssSelector("button[role='button']");

        protected By LabelDropDownButton = By.CssSelector("button[title='Open actions dropdown']");

        public AddAndEditLabelComponent ClickAddLabelButton()
        {
            AddLabelButton
                .Click();

            addlabelComponent = new AddAndEditLabelComponent(Driver, this);

            return addlabelComponent;
        }

        public AddAndEditLabelComponent EditRandomLabel(int edittedLabel)
        {
            LabelsList.ElementAt(edittedLabel)
                .FindElement(LabelEditButton)
                .Click();

            addlabelComponent = new AddAndEditLabelComponent(Driver, this);

            return addlabelComponent;
        }

        public DeleteLabelComponent ClickDeleteLabelButton(string labelToBeDeleted)
        {
            PBarElement labelElementToBeDeleted = LabelsList.ElementAt(GetAllLabelNames().IndexOf(labelToBeDeleted));

            labelElementToBeDeleted
                .FindElement(LabelDropDownButton)
                .Click();

            LabelDropDownDeleteButton
                .Click();

            deleteLabelComponent = new DeleteLabelComponent(Driver, this);

            return deleteLabelComponent;
        }

        public LabelPage WaitForSuccessfulAddAndEditNotification()
        {
            Driver.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NotificationLocator));

            WaitForLabelNotification(addlabelComponent.LabelName);

            return this;
        }

        public LabelPage WaitForSuccessfulDeleteNotification(string labelName)
        {
            Driver.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NotificationLocator));

            WaitForLabelNotification(labelName);

            return this;
        }

        public LabelPage VerifyCreatedLabel()
        {
            PBarElement lastLabelInformation = LabelsList.Last().FindElements(By.TagName("td"))[1];

            VerifyLabelNameAndColor(lastLabelInformation);

            return this;
        }

        public LabelPage VerifyEdittedLabel(int edittedLabel)
        {
            PBarElement edittedLabelInformation = LabelsList.ElementAt(edittedLabel).FindElements(By.TagName("td"))[1];

            VerifyLabelNameAndColor(edittedLabelInformation);

            return this;
        }

        public LabelPage VerifyLabelIsDeleted(string deletedLabelName)
        {
            CollectionAssert.DoesNotContain(GetAllLabelNames(), deletedLabelName);

            return this;
        }

        public string GetRandomLabelName()
        {
            return GetAllLabelNames().RandomListItem();
        }

        public int GetNumberOfCreatedLabels()
        {
            return LabelsList.Count;
        }

        private List<string> GetAllLabelNames()
        {
            return LabelsList.Select(l => l.Text.Split(Environment.NewLine).First()).ToList();
        }

        private void WaitForLabelNotification(string labelName)
        {
            var lastNotification = NotificationList.Last();

            while (!lastNotification.WrappedElement.Text.Contains(labelName))
            {
                lastNotification = NotificationList.Last();
            }
        }

        private void VerifyLabelNameAndColor(PBarElement label)
        {
            string lastLabelColor = label.FindElement(By.TagName("svg")).GetAttribute("style").Split('(')[1].Split(')')[0];

            string lastLabelName = label.Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(addlabelComponent.LabelColor, lastLabelColor);
                Assert.AreEqual(addlabelComponent.LabelName, lastLabelName);
            });
        }
    }
}
