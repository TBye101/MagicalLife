using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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