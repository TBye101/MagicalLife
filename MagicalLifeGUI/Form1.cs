using MagicalLifeAPI.World;
using MagicalLifeAPI.World.World_Generation.Generators;
using MagicalLifeRenderEngine.Main;
using MagicalLifeRenderEngine.Main.GUI.Click;
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
        private bool showCoordinateBox = false;

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
            World.Initialize(MainWindow.Default.ScreenSize.Height / Tile.GetTileSize().Y,
               MainWindow.Default.ScreenSize.Width / Tile.GetTileSize().X, 2, new Dirtland());
            this.screen = this.pipe.GetScreen(1);
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

        /// <summary>
        /// Shows and hides the coordinates box.
        /// </summary>
        private void ToggleCoordinateTestBox()
        {
            if (this.showCoordinateBox)
            {
                this.CoordinateTestBox.Visible = false;
                this.showCoordinateBox = false;
            }
            else
            {
                this.CoordinateTestBox.Visible = true;
                this.showCoordinateBox = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this.screen != null)
            {
                Bitmap scr = this.pipe.GetScreen(1);
                //e.Graphics.DrawImage(this.screen, new Point(0, 0));
                e.Graphics.DrawImage(scr, new Rectangle(new Point(0, 0), MainWindow.Default.ScreenSize));
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
            if (e.KeyCode == Keys.F1)
            {
                this.ToggleCoordinateTestBox();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ClickDistributor.Click(e);
        }
    }
}