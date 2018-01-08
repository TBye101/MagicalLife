using MagicalLifeGUI.Storage;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MagicalLifeGUI
{
    /// <summary>
    /// Used to do various startup tasks.
    /// </summary>
    public class StartupForm
    {
        /// <summary>
        /// Runs all startup work.
        /// </summary>
        public void RunAll(Form1 form)
        {
            this.InitializeForm(form);
        }

        private void InitializeForm(Form1 form)
        {
            if (!Universal.Default.GameHasRunBefore)
            {
                MainWindow.Default.ScreenSize = Screen.PrimaryScreen.Bounds.Size;
            }

            form.Size = MainWindow.Default.ScreenSize;
            form.WindowState = MainWindow.Default.WindowState;
            form.FormBorderStyle = MainWindow.Default.Boarder;
        }
    }
}
