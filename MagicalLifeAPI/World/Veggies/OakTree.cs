using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.World.Veggies
{
    /// <summary>
    /// An oak tree.
    /// </summary>
    public class OakTree : Vegetation
    {
        public OakTree() : base("Oak Tree")
        {
            //this.IsDorment = false;
            //this.MovementCost = .2;
            //this.MaxYield = 150;
            //this.MinYield = 100;
            //this.MinDaysBetweenReproduction = 360;
            //this.MutationChance = .03;
            //this.OffSpringMax = 150;
            //this.OffSpringMin = 30;
            //this.Precipitationmax = 100;
            //this.PrecipitationMin = 20;
            //this.ReproductionChance = .1;
            //this.ReproductionRange = 5;
        }

        //public override List<Item> GetCurrentYield()
        //{
        //    int toGen = StaticRandom.Rand(MathUtil.Round(this.MinYield), MathUtil.Round(this.MaxYield));
        //    throw new NotImplementedException();
        //}
    }
}