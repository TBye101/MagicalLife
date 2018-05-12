using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.Rendering.Text;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Join_Game_Menu.Input_Boxes
{
    public class PortInputBox : MonoInputBox
    {
        public PortInputBox() : base(image, CarrotTexture, drawingBounds, priority, font, isLocked, textAlignment)
        {
        }
    }
}
