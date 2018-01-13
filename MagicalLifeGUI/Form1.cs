using MagicalLifeRenderEngine.Main;
using MagicalLifeAPI.World.World_Generation.Generators;
using MagicalLifeGUI.Storage;
using MagicalLifeAPI.World;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace MagicalLifeGUI
{
    public partial class Form1 : Form
    {
        private World world;
        private Pipe pipe = new Pipe();
        Bitmap screen; 

        public Form1()
        {
            InitializeComponent();
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
            this.world = new World(MainWindow.Default.ScreenSize.Height / Tile.GetTileSize().Height,
               MainWindow.Default.ScreenSize.Width / Tile.GetTileSize().Width, 2, new Dirtland());
            screen = pipe.GetTiles(0, this.world);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (this.screen != null)
            {
                //e.Graphics.DrawImage(this.screen, new Point(0, 0));
                e.Graphics.DrawImage(this.screen, new Rectangle(new Point(0, 0), MainWindow.Default.ScreenSize));
            }
        }
    }
}