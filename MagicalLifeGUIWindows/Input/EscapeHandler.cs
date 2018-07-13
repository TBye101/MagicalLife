using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Registry.ItemRegistry;
using MagicalLifeAPI.World.Data;
using MagicalLifeAPI.World.Items;
using MagicalLifeGUIWindows.GUI;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.Input
{
    /// <summary>
    /// Used to handle the escape key, and it's many uses.
    /// </summary>
    public class EscapeHandler
    {
        public EscapeHandler(KeyboardListener listener)
        {
            listener.KeyPressed += this.Listener_KeyPressed;
        }

        private void Listener_KeyPressed(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Microsoft.Xna.Framework.Input.Keys.Escape)
            {
                this.HandleEscapeKey();
            }
            if (e.Key == Microsoft.Xna.Framework.Input.Keys.R)
            {
                Point2D result = ItemFinder.FindNearestLocation(0, new MagicalLifeAPI.DataTypes.Point2D(0, 0), 0);
                ItemAdder.AddItem(new StoneChunk(0), result, 0);
                ItemAdder.AddItem(new StoneChunk(0), result, 0);
                ItemRemover.RemoveSome(result, 0, 1);
                ItemRemover.RemoveAllItems(result, 0);
            }
        }

        private void HandleEscapeKey()
        {
            //Show main menu.
            MasterLog.DebugWriteLine("Escape key pressed");

            if (World.Dimensions.Count > 0)
            {
                //Ingame: Open up in game menu
            }
            else
            {
                //Pregame:
                MenuHandler.Back();
            }

            MenuHandler.Back();
        }
    }
}