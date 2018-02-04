using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Entities.Entity_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Entities.Humanoid;

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