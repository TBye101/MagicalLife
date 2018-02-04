using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicalLifeAPI.Entities.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Entities.Util.Tests
{
    [TestClass()]
    public class AttributeTests
    {
        [TestMethod()]
        public void AttributeTest()
        {
            Attribute att = new Attribute();
            Assert.IsNotNull(att);
            att = new Attribute(100);
            Assert.IsNotNull(att);
            Assert.AreEqual(1, att.Modifiers.Count);
            Assert.AreEqual(100, att.GetValue());
            att.AddModifier(new Tuple<long, IModifierRemoveCondition, string>(1, new NeverRemoveCondition(), "tEST1"));
            Assert.AreEqual(2, att.Modifiers.Count);
            Assert.AreEqual(101, att.GetValue());
        }
    }
}