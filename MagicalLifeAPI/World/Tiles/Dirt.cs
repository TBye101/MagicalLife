namespace MagicalLifeAPI.World.Tiles
{
    /// <summary>
    /// A dirt tile.
    /// </summary>
    public class Dirt : Tile
    {
        public Dirt()
        {
            //this.AdditionalMovementCost = 0;
        }

        public override string GetName()
        {
            return "dirt";
        }
    }
}