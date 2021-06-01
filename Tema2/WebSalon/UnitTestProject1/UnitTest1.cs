using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSalon.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class ProgramareControllerTest
    {
        [TestMethod]
        public void Index()
        {
            ProgramareController controller = new ProgramareController();
            
            ViewResult result = controller.Index() as ViewResult;
            ViewModel viewModel = controller.Index() as ViewModel;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEquals("Programare", viewModel.Title);
        }
    }
    }
}
