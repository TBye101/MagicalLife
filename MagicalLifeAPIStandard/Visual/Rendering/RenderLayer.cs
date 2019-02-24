namespace MagicalLifeAPI.Components.Generic.Renderable
{
    /// <summary>
    /// Keeps track of what priority things have when rendering.
    /// </summary>
    public static class RenderLayer
    {
        public static readonly int DirtBase;
        public static readonly int GrassBase = 1;

        public static readonly int Items = 500;

        public static readonly int Stone = 1000;

        public static readonly int Character = 1100;

        public static readonly int TreeStump = 1200;

        public static readonly int TreeTrunk = 1201;

        public static readonly int TreeLeaves = 1202;

        public static readonly int MapItemCount = int.MaxValue - 1;
        public static readonly int GUI = int.MaxValue;
    }
}