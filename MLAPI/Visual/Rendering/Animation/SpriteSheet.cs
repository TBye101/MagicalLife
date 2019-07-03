using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Error.InternalExceptions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProtoBuf;

namespace MagicalLifeAPI.Visual.Animation
{
    /// <summary>
    /// Holds a sprite sheet texture, as well as the positioning data that goes along with it.
    /// </summary>
    [ProtoContract]
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

        [ProtoMember(1)]
        public int TextureID { get; private set; }

        /// <summary>
        /// How many sprites wide is the sheet.
        /// </summary>
        [ProtoMember(2)]
        public int SheetWidth { get; private set; }

        /// <summary>
        /// How many sprites high is the sheet.
        /// </summary>
        [ProtoMember(3)]
        public int SheetHeight { get; private set; }

        /// <summary>
        /// The width of each sprite in pixels.
        /// </summary>
        [ProtoMember(4)]
        private int SpritePixelWidth { get; set; }

        /// <summary>
        /// The height of each sprite in pixels.
        /// </summary>
        [ProtoMember(5)]
        private int SpritePixelHeight { get; set; }

        public SpriteSheet(int textureID, int sheetWidth, int sheetHeight,
            int spritePixelWidth, int spritePixelHeight)
        {
            this.TextureID = textureID;
            this.SheetWidth = sheetWidth;
            this.SheetHeight = sheetHeight;
            this.SpritePixelWidth = spritePixelWidth;
            this.SpritePixelHeight = spritePixelHeight;

            if (World.Data.World.Mode == Networking.EngineMode.ServerAndClient)
            {
                this.VerifySheet();
            }
        }

        private SpriteSheet()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// Calculates the correct rectangle section to render one frame of this sprite sheet.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public Rectangle GetSection(int frame)
        {
            int xPosition = frame % this.SheetWidth;
            int yPosition = frame / this.SheetWidth;

            int x = xPosition * this.SpritePixelWidth;
            int y = yPosition * this.SpritePixelHeight;

            return new Rectangle(x, y, this.SpritePixelWidth, this.SpritePixelHeight);
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