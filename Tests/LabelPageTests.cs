using Antiproton.DriverExtensions;
using Entities;
using Helpers;
using NUnit.Framework;
using TestBases;

namespace Tests
{
    [TestFixture]
    public class LabelPageTests : LabelPageTestBase
    {
        [Test]
        public void WhenIGoToLabelPageICreateALabelSuccessfully()
        {
            labelPage
                .ClickAddLabelButton()
                .FillLabelName()
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulAddAndEditNotification()
                .VerifyCreatedLabel();
        }

        [Test]
        public void WhenIGoToLabelPageICreateALabelAndSuccessfullyEditARandomLabel()
        {
            labelPage
                .ClickAddLabelButton()
                .FillLabelName()
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulAddAndEditNotification()
                .VerifyCreatedLabel();

            int labelToEdit = RandomDataGenerator.RandomNumber(0, labelPage.GetNumberOfCreatedLabels());

            labelPage
                .EditRandomLabel(labelToEdit)
                .FillLabelName()
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulAddAndEditNotification()
                .VerifyEdittedLabel(labelToEdit);
        }

        [Test]
        public void WhenIGoToLabelPageICreateALabelSuccessfullyAndDeleteItSuccessfully()
        {
            labelPage
                .ClickAddLabelButton()
                .FillLabelName()
                .ChooseLabelColor()
                .ClickSaveButton()
                .WaitForSuccessfulAddAndEditNotification()
                .VerifyCreatedLabel();

            string randomLabelName = labelPage.GetRandomLabelName();

            labelPage
                .ClickDeleteLabelButton(randomLabelName)
                .ClickDeleteButton()
                .WaitForSuccessfulDeleteNotification(randomLabelName)
                .VerifyLabelIsDeleted(randomLabelName);



        }
    }
}
