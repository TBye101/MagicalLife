using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Eventing;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to readjust the <see cref="ClickBounds"/> for living objects.
    /// </summary>
    public static class LivingBoundHandler
    {
        public static readonly int LivingPriority = 2147483646;

        public static void Initialize()
        {
            Living.LivingCreated += Living_LivingCreated;
        }

        private static void Living_LivingCreated(object sender, LivingEventArg e)
        {
            //e.Living.LivingModified += Living_LivingModified;
            //AdjustBounds(e, false);
        }

        /// <summary>
        /// Corrects the <see cref="ClickBounds"/> of the <see cref="Living"/>.
        /// </summary>
        /// <param name="living"></param>
        /// <param name="hasExistingBounds">This is true if the <see cref="Living"/> already has registered <see cref="ClickBounds"/> with the <see cref="BoundHandler"/>.</param>
        //private static void AdjustBounds(LivingEventArg e, bool hasExistingBounds)
        //{
        //    if (!hasExistingBounds)
        //    {
        //        ClickBounds bounds = new ClickBounds(GetBoundsForTile(e.Location), LivingBoundHandler.LivingPriority);
        //        bounds.GameObject = e.Living;
        //        BoundHandler.AddClickBounds(bounds);
        //    }
        //    else
        //    {
        //        foreach (ClickBounds item in BoundHandler.GameObjectBounds)
        //        {
        //            if (item.GameObject == e.Living)
        //            {
        //                ClickBounds bounds = new ClickBounds(GetBoundsForTile(e.Location), LivingBoundHandler.LivingPriority);
        //                bounds.GameObject = item.GameObject;
        //                BoundHandler.RemoveClickBounds(item);
        //                BoundHandler.AddClickBounds(bounds);
        //            }
        //        }
        //    }
        //}

        private static void Living_LivingModified(object sender, MagicalLifeAPI.Entities.Eventing.LivingEventArg e)
        {
            //AdjustBounds(e, true);
        }

        /// <summary>
        /// Returns the bounds for a specific tile.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Rectangle GetBoundsForTile(Point location)
        {
            Point size = Tile.GetTileSize();

            int x = location.X + RenderingPipe.XViewOffset;
            int y = location.Y + RenderingPipe.YViewOffset;
            int width = size.X;
            int height = size.Y;

            return new Rectangle(x, y, width, height);
        }
    }
}