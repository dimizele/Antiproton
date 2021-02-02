using Antiproton;
using Antiproton.AntiprotonPageSetup;
using Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.PageComponents
{
    public class AddAndEditFolderComponent : PBarComponent
    {
        private LabelPage _labelPage;

        public AddAndEditFolderComponent(PBarDriver driver, LabelPage labelPage)
        {
            Driver = driver;
            _labelPage = labelPage;
        }

        protected PBarElement FolderNameInput => new PBarElement(Driver, By.Id("accountName"));

        protected SelectElement FolderLocationField => new SelectElement(Component.FindElement(By.Id("parentID")).WrappedElement);

        protected PBarElement SaveButton => new PBarElement(Driver, Component.FindElement(By.CssSelector("button[type='submit']")));

        public AddAndEditFolderComponent FillFolderName(string folderName)
        {
            FolderNameInput
                .ClearWithCtrlADelete()
                .SendKeys(folderName);

            return this;
        }

        public AddAndEditFolderComponent ChooseParentFolder(string parentFolderName)
        {
            FolderLocationField
                .SelectByText(parentFolderName);

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
