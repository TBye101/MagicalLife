using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.Entities.Humanoid.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            Human human = new Human(10, 10, new Point(0, 0));
            Assert.IsNotNull(human);
        }
    }
}