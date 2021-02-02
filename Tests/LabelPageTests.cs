using Antiproton.DriverExtensions;
using Entities;
using Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using TestBases;

namespace Tests
{
    [TestFixture]
    public class LabelPageTests : LabelPageTestBase
    {
        [Test]
        public void WhenIGoToLabelPageICreateALabelSuccessfully()
        {
            string randomLabelName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddLabelButton()
                .FillLabelName(randomLabelName)
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomLabelName, Enums.NotificationEnums.Created)
                .VerifyCreatedLabel(randomLabelName);
        }

        [Test]
        public void WhenIGoToLabelPageICreateALabelAndSuccessfullyEditARandomLabel()
        {
            string randomLabelName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddLabelButton()
                .FillLabelName(randomLabelName)
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomLabelName, Enums.NotificationEnums.Created)
                .VerifyCreatedLabel(randomLabelName);

            int labelToEdit = RandomDataGenerator.RandomNumber(0, labelPage.GetNumberOfCreatedLabels());
            string randomEdittedLabelName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .EditRandomLabel(labelToEdit)
                .FillLabelName(randomEdittedLabelName)
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomEdittedLabelName, Enums.NotificationEnums.Updated)
                .VerifyEdittedLabel(labelToEdit, randomEdittedLabelName);
        }

        [Test]
        public void WhenIGoToLabelPageICreateALabelSuccessfullyAndDeleteItSuccessfully()
        {
            string randomLabelName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddLabelButton()
                .FillLabelName(randomLabelName)
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomLabelName, Enums.NotificationEnums.Created)
                .VerifyCreatedLabel(randomLabelName);

            string randomLabelNameForDelition = labelPage.GetRandomLabelName();

            labelPage
                .ClickDeleteLabelButton(randomLabelNameForDelition) 
                .ClickDeleteButton()
                .WaitForSuccessfulNotification(randomLabelNameForDelition, Enums.NotificationEnums.Removed)
                .VerifyLabelIsDeleted(randomLabelNameForDelition);
        }

        [Test]
        public void WhenIGoToLabelPageICreateAFolderSuccessfully()
        {
            string randomFolderName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddFolderButton()
                .FillFolderName(randomFolderName)
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomFolderName, Enums.NotificationEnums.Created)
                .VerifyParentFolderIsCreated(randomFolderName);
        }

        [Test]
        public void WhenIGoToLabelPageICreateAFolderSuccessfullyAndCreateAChildFolderSuccessfully()
        {
            string randomParentName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));
            string randomChildName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddFolderButton()
                .FillFolderName(randomParentName)
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomParentName, Enums.NotificationEnums.Created)
                .VerifyParentFolderIsCreated(randomParentName)
                .ClickAddFolderButton()
                .FillFolderName(randomChildName)
                .ChooseParentFolder(randomParentName)
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomChildName, Enums.NotificationEnums.Created)
                .VerifyChildFolderIsCreated(randomParentName, randomChildName);
        }

        [Test]
        public void WhenIGoToLabelPageChildFoldersAreDeletedWhenParentFolderIsDeleted()
        {
            string randomParentName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));
            string randomChildName = RandomDataGenerator.RandomStringOnlyLetters(RandomDataGenerator.RandomNumber(7, 13));

            labelPage
                .ClickAddFolderButton()
                .FillFolderName(randomParentName)
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomParentName, Enums.NotificationEnums.Created)
                .VerifyParentFolderIsCreated(randomParentName)
                .ClickAddFolderButton()
                .FillFolderName(randomChildName)
                .ChooseParentFolder(randomParentName)
                .ClickSaveButton()
                .WaitForSuccessfulNotification(randomChildName, Enums.NotificationEnums.Created)
                .VerifyChildFolderIsCreated(randomParentName, randomChildName)
                .DeleteFolder(randomParentName)
                .ClickDeleteButton()
                .WaitForSuccessfulNotification(randomParentName, Enums.NotificationEnums.Removed)
                .VerifyFoldersAreDeleted(new List<string> { randomParentName, randomChildName });
        }
    }
}
