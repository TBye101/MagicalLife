using System;
using System.Windows.Forms;

namespace MagicalLifeGUI
{
    public partial class Form1 : Form
    {
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
    }
}