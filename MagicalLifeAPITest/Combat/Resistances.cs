using MagicalLifeAPI.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MagicalLifeAPITest.Combat
{
    public class Resistances
    {
        [Fact]
        public void CanSubtractDamage()
        {
            Resistance resistance = new Resistance(DamageTypes.Fire, 20);
            Damage damage = new Damage(DamageTypes.Fire, 30);

            Damage expectedDamage = new Damage(DamageTypes.Fire, 10);

            Assert.Equal(expectedDamage, (damage - resistance));

        }
    }
}
