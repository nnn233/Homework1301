using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDateTime
{
    [TestClass]
    public class DateTimeTests
    {
        [TestMethod]
        public void CylinderVolume_2and8_100returned()
        {
            int a = 2;
            int b = 8;
            int expected = 100;

            Geometry g = new Geometry();
            double actual = g.CylinderVolume(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}