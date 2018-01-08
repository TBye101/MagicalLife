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

            Form1 mainForm = new Form1();
            StartupForm formStartup = new StartupForm();
            formStartup.RunAll(mainForm);
            Application.Run(mainForm);
        }
    }
}