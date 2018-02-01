using MagicalLifeAPI.Universal;
using MagicalLifeRenderEngine.Main.GUI.Click;
using MagicalLifeAPI.World;
using MagicalLifeAPI.World.World_Generation.Generators;
using MagicalLifeRenderEngine.Main;
using MagicalLifeSettings.Storage;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagicalLifeGUI
{
    public partial class Form1 : Form
    {
        private Pipe pipe = new Pipe();
        private Bitmap screen;

        private bool showMainMenu = true;

        public Form1()
        {
            InitializeComponent();
            World.TurnStart += this.World_TurnStart;
            World.TurnEnd += this.World_TurnEnd;
        }

        private void World_TurnEnd(object sender, WorldEventArgs e)
        {
            this.Refresh();
        }

        private void World_TurnStart(object sender, WorldEventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            this.ToggleMainMenu();
            World.Initialize(MainWindow.Default.ScreenSize.Height / Tile.GetTileSize().Height,
               MainWindow.Default.ScreenSize.Width / Tile.GetTileSize().Width, 2, new Dirtland());
            screen = pipe.GetScreen(1);
        }

        /// <summary>
        /// Shows the main menu.
        /// </summary>
        private void ToggleMainMenu()
        {
            if (this.showMainMenu)
            {
                this.NewGameButton.Visible = false;
                this.QuitButton.Visible = false;
                this.showMainMenu = false;
            }
            else
            {
                this.NewGameButton.Visible = true;
                this.QuitButton.Visible = true;
                this.showMainMenu = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this.screen != null)
            {
                //e.Graphics.DrawImage(this.screen, new Point(0, 0));
                e.Graphics.DrawImage(this.pipe.GetScreen(1), new Rectangle(new Point(0, 0), MainWindow.Default.ScreenSize));
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.ToggleMainMenu();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ClickDistributor.Click(e);
        }
    }
}