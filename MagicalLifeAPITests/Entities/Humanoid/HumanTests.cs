using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Entities.Humanoid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Humanoid.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            Human human = new Human(10, 10);
            Assert.IsNotNull(human);
        }
    }
}