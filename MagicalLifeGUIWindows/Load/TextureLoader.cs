using Microsoft.Xna.Framework.Graphics;
using MagicalLifeGUIWindows.Asset;
using System.Reflection;
using MagicalLifeAPI.World;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Loads all internal textures.
    /// </summary>
    public class TextureLoader : IGameLoader
    {
        private int TotalJobs = -1;

        public int GetTotalOperations()
        {
            if (this.TotalJobs == -1)
            {
                this.TotalJobs = this.CalculateTotalJobs();
            }

            return this.TotalJobs;
        }

        private int CalculateTotalJobs()
        {
            List<Tile> tiles = ReflectionUtil.LoadAllAbstractClass<Tile>(Assembly.GetAssembly(typeof(Tile)));
            return tiles.Count;
        }

        public void InitialStartup(ref int progress)
        {
            List<Tile> tiles = ReflectionUtil.LoadAllAbstractClass<Tile>(Assembly.GetAssembly(typeof(Tile)));

            foreach (Tile item in tiles)
            {
                Texture2D texture = Game1.AssetManager.Load<Texture2D>(item.GetTextureName());
                progress++;
            }

            progress = this.TotalJobs;
        }
    }
}
