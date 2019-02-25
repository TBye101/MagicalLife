using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Load;
using MagicalLifeAPI.Networking.Serialization;
using MagicalLifeAPI.Sound;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util.Reusable;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.GUI.In;
using MagicalLifeGUIWindows.Input;
using MagicalLifeGUIWindows.Load;
using MagicalLifeGUIWindows.Rendering;
using MagicalLifeGUIWindows.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MagicalLifeGUIWindows
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; set; }
        public SpriteBatch GUIBatch { get; set; }
        public SpriteBatch MapSpriteBatch { get; set; }

        public static ContentManager AssetManager { get; set; }

        internal static List<LogoScreen> SplashScreens { get; set; }

        /// <summary>
        /// If true, then we are done displaying splash screens.
        /// </summary>
        internal static bool SplashDone { get; set; } = false;

        public static FrameCounter FPS { get; private set; } = new FrameCounter();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            Game1.AssetManager = this.Content;
            UniversalEvents.GameExit += this.UniversalEvents_GameExit;
            Graphics.HardwareModeSwitch = false;
            OutputDebugInfo();
        }

        private void InitializeSplashScreens()
        {
            WindowConfig winConfig = new WindowConfig();
            winConfig.ConfigureMainWindow(this);

            SplashScreens = new List<LogoScreen>()
            {
                new LogoScreen(TextureLoader.LogoMonoGame, 5F),
                new LogoScreen(TextureLoader.LogoFMOD, 5F, "\"FMOD\" and \"FMOD Studio\" are licensed by \"Firelight Technologies Pty Ltd\"")
            };
        }

        private void UniversalEvents_GameExit(object sender, System.EventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base. Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            SettingsManager.UniversalSettings.Settings.GameHasRunBefore = true;
            SettingsManager.UniversalSettings.Save();
            RenderInfo.Camera2D.ViewportHeight = Graphics.GraphicsDevice.Viewport.Height;
            RenderInfo.Camera2D.ViewportWidth = Graphics.GraphicsDevice.Viewport.Width;
            RenderInfo.Camera2D.CenterOn(new Vector2(8, 8));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.GUIBatch = new SpriteBatch(this.GraphicsDevice);
            this.MapSpriteBatch = new SpriteBatch(this.GraphicsDevice);

            Loader load = new Loader();
            string msg = string.Empty;

            load.LoadAll(ref msg, new List<IGameLoader>()
            {
                new ItemLoader(),
                new InputLoader(),
                new Initializer(),
                //new TextureLoader(),
                new TextureLoader(this.Content),
                new SpecificTextureLoader(),
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.DisplayInGame();
            FMODUtil.Update();

            //Used to render things to a buffer that will have a zoom multiplier applied before rendering.
            this.GraphicsDevice.Clear(Color.Black);

            if (Game1.SplashDone)
            {
                if (World.Dimensions.Count > 0)
                {
                    //Never set this to SpriteSortMode.Texture, as that causes bugs.
                    this.MapSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                        null, null, null, null, RenderInfo.Camera2D.TranslationMatrix);

                    RenderingPipe.DrawScreen(this.MapSpriteBatch);
                    this.MapSpriteBatch.End();
                }

                this.GUIBatch.Begin();
                RenderingPipe.DrawGUI(this.GUIBatch);
                this.GUIBatch.End();
            }
            else
            {
                int length = Game1.SplashScreens.Count;
                for (int i = 0; i < length; i++)
                {
                    LogoScreen item = Game1.SplashScreens[i];
                    if (!item.Done())
                    {
                        item.Draw(this.MapSpriteBatch);
                        break;
                    }

                    if (i == length - 1)
                    {
                        Game1.SplashDone = true;

                        //Initialize main menu
                        GUI.MainMenu.MainMenu.Initialize();
                        this.IsMouseVisible = true;
                    }
                }
            }
            base.Draw(gameTime);
        }

        private void DisplayInGame()
        {
            if (World.Dimensions.Count > 0)
            {
                if (!BoundHandler.GUIWindows.Contains(InGameGUI.InGame))
                {
                    InGameGUI.Initialize();
                }
            }
        }

        private static void OutputDebugInfo()
        {
            MasterLog.DebugWriteLine("Screens:");

            foreach (Screen screen in Screen.AllScreens)
            {
                MasterLog.DebugWriteLine("Device Name: " + screen.DeviceName);
                MasterLog.DebugWriteLine("Bounds: " + screen.Bounds.ToString());
                MasterLog.DebugWriteLine("Type: " + screen.GetType().ToString());
                MasterLog.DebugWriteLine("Working Area: " + screen.WorkingArea.ToString());
                MasterLog.DebugWriteLine("Bounds: " + screen.Bounds.ToString());
                MasterLog.DebugWriteLine("Primary Screen: " + screen.Primary.ToString());
            }

            MasterLog.DebugWriteLine("Screens end");

            System.Collections.ObjectModel.ReadOnlyCollection<GraphicsAdapter> gpus = GraphicsAdapter.Adapters;

            foreach (GraphicsAdapter item in gpus)
            {
                MasterLog.DebugWriteLine("Description: " + item.Description);
                MasterLog.DebugWriteLine("Device ID" + item.DeviceId.ToString());
                MasterLog.DebugWriteLine("Device Name: " + item.DeviceName);
                MasterLog.DebugWriteLine("Is Default: " + item.IsDefaultAdapter.ToString());
                MasterLog.DebugWriteLine("Revision: " + item.Revision.ToString());
                MasterLog.DebugWriteLine("Sub System ID: " + item.SubSystemId.ToString());
                MasterLog.DebugWriteLine("Vendor ID: " + item.VendorId.ToString());
            }
        }
    }
}