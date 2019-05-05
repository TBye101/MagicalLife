using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing;
using MagicalLifeGUIWindows.GUI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MagicalLifeGUIWindows.Load
{
    /// <summary>
    /// Handles configuring the main window.
    /// </summary>
    public class WindowConfig
    {
        /// <summary>
        /// Configures the main window.
        /// </summary>
        /// <param name="game"></param>
        public void ConfigureMainWindow(Game1 game)
        {
            SettingsManager.WindowSettings.Settings.ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            SettingsManager.WindowSettings.Settings.ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            SettingsManager.WindowSettings.Save();

            game.Graphics.PreferredBackBufferHeight = SettingsManager.WindowSettings.Settings.ScreenHeight;
            game.Graphics.PreferredBackBufferWidth = SettingsManager.WindowSettings.Settings.ScreenWidth;

            RenderInfo.FullScreenWindow = new Rectangle(new Point(0, 0), new Point(SettingsManager.WindowSettings.Settings.ScreenWidth, SettingsManager.WindowSettings.Settings.ScreenHeight));

            this.SetResolution();
            game.Graphics.ToggleFullScreen();
            game.Graphics.ApplyChanges();
        }

        private void SetResolution()
        {
            SettingsManager.WindowSettings.Settings.Resolution = this.DetermineClosestResolution();

            SettingsManager.WindowSettings.Save();
        }

        private int DetermineClosestResolution()
        {
            System.Drawing.Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Point2D currentScreen = new Point2D(bounds.Width, bounds.Height);

            Dictionary<Point2D, int> widthToResolutionEnum = new Dictionary<Point2D, int>
            {
                { new Point2D(1920, 1080), (int)Resolution._1920x1080 },
                { new Point2D(2560, 1440), (int)Resolution._2560x1440 }
            };

            while (widthToResolutionEnum.Count > 1)
            {
                decimal zero = this.CalculateApproximation(widthToResolutionEnum.ElementAt(0).Key, currentScreen);
                decimal one = this.CalculateApproximation(widthToResolutionEnum.ElementAt(1).Key, currentScreen);

                if (this.IsACloser(zero, one, 1))
                {
                    widthToResolutionEnum.Remove(widthToResolutionEnum.ElementAt(1).Key);
                }
                else
                {
                    widthToResolutionEnum.Remove(widthToResolutionEnum.ElementAt(0).Key);
                }
            }

            return widthToResolutionEnum.ElementAt(0).Value;
        }

        /// <summary>
        /// Determines if 'a' is closer or equal in proximity to 'c' than 'b' is.
        /// </summary>
        /// <returns></returns>
        private bool IsACloser(decimal a, decimal b, decimal c)
        {
            decimal aError = Math.Abs(a - c);
            decimal bError = Math.Abs(b - c);

            return (aError <= bError);
        }

        /// <summary>
        /// Determines how close 'a' is in value to 'b' in terms of percent.
        /// </summary>
        /// <returns></returns>
        private decimal CalculateApproximation(Point2D a, Point2D b)
        {
            decimal widthCloseness = decimal.Divide(a.X, b.X);
            decimal heightCloseness = decimal.Divide(a.Y, b.Y);

            return (widthCloseness + heightCloseness) / 2;
        }
    }
}