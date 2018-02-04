using MagicalLifeAPI.Entities.Humanoid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Tests
{
    [TestClass()]
    public class LivingTests
    {
        [TestMethod()]
        public void LivingTest()
        {
            Living l = new Human(1, 1);
            Assert.IsNotNull(l);
            Assert.AreEqual(1, l.Health.GetValue());
            Assert.AreEqual(1, l.MovementSpeed.GetValue());
        }
    }
}