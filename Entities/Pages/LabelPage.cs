using Antiproton;
using Antiproton.AntiprotonElements;
using Antiproton.AntiprotonElementExtensions;
using Antiproton.AntiprotonPageSetup;
using Entities.PageComponents;
using Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using static Helpers.Enums;

namespace Entities
{
    public class LabelPage : PBarPage
    {
        protected override string RelativePageUrl { get; set; } = "settings/labels";
        protected override string PageDomainPrefix { get; set; } = "beta";

        private AddAndEditLabelComponent addlabelComponent;
        private AddAndEditFolderComponent addFolderComponent;
        private DeleteLabelComponent deleteLabelComponent;

        protected List<PBarElement> NotificationList => Driver.FindElements(NotificationLocator).ToList();

        protected PBarElement DeleteButton => new PBarElement(Driver, By.CssSelector("button[data-test-id='folders/labels:item-delete']"));

        protected PBarElement LabelSection => new PBarElement(Driver, By.CssSelector("section[data-target-id='labellist']"));

        protected PBarElement AddLabelButton => new PBarElement(Driver, LabelSection.FindElement(By.TagName("button")));

        protected PBarTable LabelsTable => new PBarTable(Driver, LabelSection.FindElement(By.TagName("table")));

        protected PBarElement FolderSection => new PBarElement(Driver, By.CssSelector("section[data-target-id='folderlist']"));

        protected PBarElement AddFolderButton => new PBarElement(Driver, FolderSection.FindElement(By.TagName("button")));

        protected PBarElement FolderList => new PBarElement(Driver, FolderSection.FindElement(By.TagName("ul")));

        protected By NotificationLocator = By.CssSelector(".notification-success");

        protected By EditButton = By.CssSelector("button[role='button']");

        protected By DropDownButton = By.CssSelector("button[title='Open actions dropdown']");

        

        public AddAndEditLabelComponent ClickAddLabelButton()
        {
            AddLabelButton
                .Click();

            addlabelComponent = new AddAndEditLabelComponent(Driver, this);

            return addlabelComponent;
        }

        public AddAndEditLabelComponent EditRandomLabel(int edittedLabel)
        {
            LabelsTable
                .GetAllTableBodyRows()
                .ElementAt(edittedLabel)
                .FindElement(EditButton)
                .Click();

            addlabelComponent = new AddAndEditLabelComponent(Driver, this);

            return addlabelComponent;
        }

        public DeleteLabelComponent ClickDeleteLabelButton(string labelToBeDeleted)
        {
            PBarElement labelElementToBeDeleted = LabelsTable
                .GetAllTableBodyRows()
                .ElementAt(GetAllLabelNames()
                .IndexOf(labelToBeDeleted));

            labelElementToBeDeleted
                .FindElement(DropDownButton)
                .Click();

            DeleteButton
                .Click();

            deleteLabelComponent = new DeleteLabelComponent(Driver, this);

            return deleteLabelComponent;
        }

        public LabelPage WaitForSuccessfulNotification(string entityName, NotificationEnums notificationEnum)
        {
            Driver.Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(NotificationLocator));

            WaitForLabelNotification($"{entityName} {notificationEnum.ToString().ToLower()}");

            return this;
        }

        public LabelPage VerifyCreatedLabel(string expectedLabelName)
        {
            PBarElement lastLabelInformation = LabelsTable
                .GetAllTableBodyRows()
                .Last()
                .FindElements(By.TagName("td"))[1];

            VerifyLabelNameAndColor(lastLabelInformation, expectedLabelName);

            return this;
        }

        public LabelPage VerifyEdittedLabel(int edittedLabel, string expectedLabelName)
        {
            PBarElement edittedLabelInformation = LabelsTable
                .GetAllTableBodyRows()
                .ElementAt(edittedLabel)
                .FindElements(By.TagName("td"))[1];

            VerifyLabelNameAndColor(edittedLabelInformation, expectedLabelName);

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
            return LabelsTable
                .GetAllTableBodyRows()
                .Count;
        }

        private List<string> GetAllLabelNames()
        {
            if (LabelSection.PeekElement(By.TagName("tbody")))
            {
                return LabelsTable
                .GetAllTableBodyRows()
                .Select(l => l.Text.Split(Environment.NewLine).First())
                .ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        private void WaitForLabelNotification(string labelName)
        {
            var lastNotification = NotificationList.Last();

            while (!lastNotification.WrappedElement.Text.Contains(labelName))
            {
                lastNotification = NotificationList.Last();
            }
        }

        private void VerifyLabelNameAndColor(PBarElement label, string expectedLabelName)
        {
            string lastLabelColor = label.FindElement(By.TagName("svg")).GetAttribute("style").Split('(')[1].Split(')')[0];

            string lastLabelName = label.Text;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(addlabelComponent.LabelColor, lastLabelColor);
                Assert.AreEqual(expectedLabelName, lastLabelName);
            });
        }

        public AddAndEditFolderComponent ClickAddFolderButton()
        {
            AddFolderButton
                .Click();

            addFolderComponent = new AddAndEditFolderComponent(Driver, this);

            return addFolderComponent;
        }

        public LabelPage VerifyParentFolderIsCreated(string folderName)
        {
            List<PBarElement> parentElements = FolderList.FindElements(By.TagName("li")).Where(el => !el.GetAttribute("title").Contains("/")).ToList();

            Assert.AreEqual(folderName, parentElements.Last().FindElement(By.TagName("span")).Text);

            return this;
        }

        public LabelPage VerifyChildFolderIsCreated(string parentFolderName, string childFolderName)
        {
            PBarElement parentElement = FolderList.FindElements(By.TagName("li")).Where(el => el.Text.Contains(parentFolderName) && el.Text.Contains(childFolderName)).Single();

            PBarElement childElement = parentElement.FindElement(By.TagName("li"));

            Assert.AreEqual(childFolderName, childElement.FindElement(By.TagName("span")).Text);

            return this;
        }

        public DeleteLabelComponent DeleteFolder(string folderName)
        {
            PBarElement parentElement = FolderList.FindElements(By.TagName("li")).Where(el => el.Text.Contains(folderName)).Single();

            parentElement
                .FindElement(DropDownButton)
                .Click();

            DeleteButton
                .Click();

            deleteLabelComponent = new DeleteLabelComponent(Driver, this);

            return deleteLabelComponent;
        }

        public LabelPage VerifyFoldersAreDeleted(List<string> folderNames)
        {
            if (FolderSection.PeekElement(By.TagName("ul")))
            {
                List<PBarElement> allFolderElements = FolderList.FindElements(By.TagName("li")).ToList();

                List<string> allFolderNames = allFolderElements.Select(el => el.Text.Split(Environment.NewLine).First()).ToList(); 
                
                Assert.IsFalse(allFolderNames.Intersect(folderNames).Any());
            }
            else
            {
                //If there are no folders then the folders are definetelly deleted
                Assert.IsTrue(true);
            }            

            return this;
        }
    }
}
