using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Universal.Tests
{
    [TestClass()]
    public class UniqueTests
    {
        [TestMethod()]
        public void UniqueTest()
        {
            Unique a = new Unique();
            Assert.IsNotNull(a);
            Assert.IsNotNull(a.ID);
            Assert.IsTrue(a.ID.ToString().Length > 0);
        }
    }
}