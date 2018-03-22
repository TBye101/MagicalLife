using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Eventing;
using MagicalLifeAPI.World;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Rendering;
using Microsoft.Xna.Framework;

namespace MagicalLifeGUIWindows.Input.Specialized_Handlers
{
    /// <summary>
    /// Used to readjust the <see cref="ClickBounds"/> for living objects.
    /// </summary>
    public static class LivingBoundHandler
    {
        public static void Initialize()
        {
            Living.LivingCreated += Living_LivingCreated;
        }

        private static void Living_LivingCreated(object sender, LivingEventArg e)
        {
            e.Living.LivingModified += Living_LivingModified;
        }

        /// <summary>
        /// Corrects the <see cref="ClickBounds"/> of the <see cref="Living"/>.
        /// </summary>
        /// <param name="living"></param>
        /// <param name="hasExistingBounds">This is true if the <see cref="Living"/> already has registered <see cref="ClickBounds"/> with the <see cref="BoundHandler"/>.</param>
        private static void AdjustBounds(LivingEventArg e, bool hasExistingBounds)
        {
            if (!hasExistingBounds)
            {
                BoundHandler.AddClickBounds(GetBoundsForTile(e.Location));//Somehow tie the clickbounds and the creature together.
            }
        }

        private static void Living_LivingModified(object sender, MagicalLifeAPI.Entities.Eventing.LivingEventArg e)
        {
        }

        /// <summary>
        /// Returns the bounds for a specific tile.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private static Rectangle GetBoundsForTile(Point3D location)
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
