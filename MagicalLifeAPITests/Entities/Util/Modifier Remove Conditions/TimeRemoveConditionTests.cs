using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions.Tests
{
    [TestClass()]
    public class TimeRemoveConditionTests
    {
        [TestMethod()]
        public void TimeRemoveConditionTest()
        {
            TimeRemoveCondition condition = new TimeRemoveCondition(3);
            Assert.IsNotNull(condition);

            Assert.IsTrue(!condition.WearOff());
            Assert.IsTrue(!condition.WearOff());
            Assert.IsTrue(condition.WearOff());
        }
    }
}