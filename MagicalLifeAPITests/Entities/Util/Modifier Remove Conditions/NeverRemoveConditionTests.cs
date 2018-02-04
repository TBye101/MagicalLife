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