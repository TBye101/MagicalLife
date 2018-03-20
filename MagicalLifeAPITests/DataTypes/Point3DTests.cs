using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.DataTypes.Tests
{
    [TestClass()]
    public class Point3DTests
    {
        [TestMethod()]
        public void Point3DTest()
        {
            Point3D a = new Point3D(3, 82, 3);
            Assert.AreEqual(a.X, 3);
            Assert.AreEqual(a.Y, 82);
            Assert.AreEqual(a.Z, 3);
        }

        [TestMethod()]
        public void Point3DTest1()
        {
            Point3D a = new Point3D("3, 2, 1");
            Assert.AreEqual(a.X, 3);
            Assert.AreEqual(a.Y, 2);
            Assert.AreEqual(a.Z, 1);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Point3D a = new Point3D(3, 2, 1);
            string test = a.ToString();
            Assert.AreEqual("3, 2, 1", test);
        }
    }
}