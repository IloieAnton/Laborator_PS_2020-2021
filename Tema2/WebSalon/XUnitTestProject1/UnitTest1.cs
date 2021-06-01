using System;
using Xunit;
using WebSalon.Controllers;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ProgramareControllerTest()
        {
            var controller = new ProgramareController();

            var result = controller.Index() as ViewResult;
            var model = result.Model as AboutViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Programare", model.Title);

        }
    }
}
