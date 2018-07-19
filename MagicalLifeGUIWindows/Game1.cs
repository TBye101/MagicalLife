using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Universal;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Load;
using MagicalLifeGUIWindows.Rendering;
using MagicalLifeGUIWindows.Splash;
using MagicalLifeSettings.Storage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; set; }
        public SpriteBatch SpriteBatch;

        public static ContentManager AssetManager { get; set; }

        internal static List<SplashScreen> SplashScreens { get; set; }

        /// <summary>
        /// If true, then we are done displaying splash screens.
        /// </summary>
        internal static bool SplashDone = false;

        public Game1()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            Game1.AssetManager = this.Content;
            UniversalEvents.GameExit += this.UniversalEvents_GameExit;
            this.Graphics.HardwareModeSwitch = false;
        }

        private void InitializeSplashScreens()
        {
            SplashScreens = new List<SplashScreen>()
            {
                new SplashScreen("Logo/MonoGameLogo", 3.5F),
                new SplashScreen("Logo/FMODLogo", 3.5F, "\"FMOD\" and \"FMOD Studio\" are licensed by \"Firelight Technologies Pty Ltd\"")
            };
        }

        private void UniversalEvents_GameExit(object sender, System.EventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            WindowConfig winConfig = new WindowConfig();
            winConfig.ConfigureMainWindow(this);

            Universal.Default.GameHasRunBefore = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

            Loader load = new Loader();
            string msg = string.Empty;

            load.LoadAll(ref msg, new List<IGameLoader>()
            {
                new ItemLoader(),
                new InputLoader(),
                new Initializer(),
                new TextureLoader(),
                new TextureLoader(this.Content),
                new ProtoTypeLoader()
            });
            this.InitializeSplashScreens();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                BoundHandler.UpdateMouseInput(gameTime);
                KeyboardHandler.UpdateKeyboardInput(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.SetRenderTarget(null);
            this.GraphicsDevice.Clear(Color.Black);
            this.SpriteBatch.Begin();

            if (Game1.SplashDone)
            {
                RenderingPipe.DrawScreen(ref this.SpriteBatch);
            }
            else
            {
                int length = Game1.SplashScreens.Count;
                for (int i = 0; i < length; i++)
                {
                    SplashScreen item = Game1.SplashScreens[i];
                    if (!item.Done())
                    {
                        item.Draw(ref this.SpriteBatch);
                        break;
                    }

                    if (i == length - 1)
                    {
                        Game1.SplashDone = true;
                    }
                }
            }

            this.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}