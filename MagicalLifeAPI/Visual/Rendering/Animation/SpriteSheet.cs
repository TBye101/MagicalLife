using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Error.InternalExceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Visual.Animation
{
    /// <summary>
    /// Holds a sprite sheet texture, as well as the positioning data that goes along with it.
    /// </summary>
    public class SpriteSheet
    {
        /// <summary>
        /// The actual sprite sheet texture.
        /// </summary>
        public Texture2D Sprites
        {
            get
            {
                return AssetManager.Textures[this.TextureID];
            }
        }

        public int TextureID { get; private set; }

        /// <summary>
        /// How many sprites wide is the sheet.
        /// </summary>
        public int SheetWidth { get; private set; }

        /// <summary>
        /// How many sprites high is the sheet.
        /// </summary>
        public int SheetHeight { get; private set; }

        /// <summary>
        /// The width of each sprite in pixels.
        /// </summary>
        private int SpritePixelWidth { get; set; }

        /// <summary>
        /// The height of each sprite in pixels.
        /// </summary>
        private int SpritePixelHeight { get; set; }

        public SpriteSheet(int textureID, int sheetWidth, int sheetHeight, 
            int spritePixelWidth, int spritePixelHeight)
        {
            this.TextureID = textureID;
            this.SheetWidth = sheetWidth;
            this.SheetHeight = sheetHeight;
            this.SpritePixelWidth = spritePixelWidth;
            this.SpritePixelHeight = spritePixelHeight;
            this.VerifySheet();
        }

        /// <summary>
        /// Verifies that the dimensions/contents of the sprite sheet are okay.
        /// </summary>
        private void VerifySheet()
        {
            Rectangle sheetBounds = this.Sprites.Bounds;

            if (sheetBounds.Width != this.SheetWidth * this.SpritePixelWidth)
            {
                throw new InvalidTextureException("Invalid texture sheet width");
            }
            if (sheetBounds.Height != this.SheetHeight * this.SpritePixelHeight)
            {
                throw new InvalidTextureException("Invalid texture sheet height");
            }
        }
    }
}
