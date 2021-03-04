using Microsoft.VisualStudio.TestTools.UnitTesting;
using webapi.Controllers;

namespace test
{
    [TestClass]
    public class DefaultControllerTest
    {
        [TestMethod]
        public void TestGet()
        {
            var controller = new DefaultController();
            var response = controller.Get();
            Assert.AreEqual("Running API Cibergestion by BC...", response);
        }
    }
}
