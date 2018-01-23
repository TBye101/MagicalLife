using MagicalLifeSettings.Storage;
using System.Windows.Forms;

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

        private void InitializeForm(Form form)
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