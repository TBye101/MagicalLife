using System;
using System.Windows.Forms;

namespace MagicalLifeGUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartupForm formStartup = new StartupForm();
            Form1 form = new Form1();
            formStartup.RunAll(form);
            Application.Run(form);
        }
    }
}