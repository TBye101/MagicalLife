using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions.Tests
{
    [TestClass()]
    public class NeverRemoveConditionTests
    {
        [TestMethod()]
        public void WearOffTest()
        {
            NeverRemoveCondition remove = new NeverRemoveCondition();
            Assert.IsNotNull(remove);

            for (int i = 0; i < 1000; i++)
            {
                Assert.IsTrue(!remove.WearOff());
            }
        }
    }
}