using Antiproton.DriverExtensions;
using Entities;
using NUnit.Framework;
using TestBases;

namespace Tests
{
    [TestFixture]
    public class LabelPageTests : LabelPageTestBase
    {
        [Test]
        public void Test()
        {
            Driver
                .GoToPage<LabelPage>()
                .ClickAddLabelButton()
                .FillLabelName()
                .ChooseLabelColor()
                .ClickSaveButton()
                .VerifyCreatedLabelColor();
        }
    }
}
