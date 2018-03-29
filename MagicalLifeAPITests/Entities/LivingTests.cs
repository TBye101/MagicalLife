using MagicalLifeAPI.Entities.Humanoid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.Entities.Tests
{
    [TestClass()]
    public class LivingTests
    {
        [TestMethod()]
        public void LivingTest()
        {
            Living l = new Human(1, 1, new DataTypes.Point3D(0, 0, 0));
            Assert.IsNotNull(l);
            Assert.AreEqual(1, l.Health.GetValue());
            Assert.AreEqual(1, l.MovementSpeed.GetValue());
        }
    }
}