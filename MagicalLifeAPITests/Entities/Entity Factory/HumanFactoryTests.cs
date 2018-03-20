using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.Entities.Entity_Factory.Tests
{
    [TestClass()]
    public class HumanFactoryTests
    {
        [TestMethod()]
        public void GenerateHumanTest()
        {
            HumanFactory factory = new HumanFactory();
            Assert.IsNotNull(factory);
        }
    }
}