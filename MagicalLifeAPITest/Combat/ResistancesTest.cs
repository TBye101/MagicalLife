using MagicalLifeAPI.Combat;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.Humanoid;
using MagicalLifeAPI.Entity.Util.Modifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MagicalLifeAPITest.Combat
{
    public class ResistancesTest
    {
        [Fact]
        public void CanSubtractDamage()
        {
            Resistance resistance = new Resistance(DamageTypes.Fire, 20);
            Damage damage = new Damage(DamageTypes.Fire, 30);

            Damage expectedDamage = new Damage(DamageTypes.Fire, 10);

            Assert.Equal(expectedDamage, damage - resistance);

        }

        [Fact]
        public void CanRemoveHealth()
        {
            Living living = new Human();
            living.Health.SetBaseValue(50);

            Damage damage = new Damage(DamageTypes.Fire, 30);


            //living.Health

            //Assert.Equal(living.Health,0);
        }
    }
}
