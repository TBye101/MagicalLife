﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Input.InputListeners;

namespace MagicalLifeGUIWindows.GUI.Reusable
{
    /// <summary>
    /// Used to display a list of strings.
    /// </summary>
    public class ListBox : GUIElement
    {
        /// <summary>
        /// The items that are displayed in this <see cref="ListBox"/>.
        /// </summary>
        public List<string> Items { get; set; }

        public ListBox(List<string> items)
        {
            this.Items = items;
        }

        public ListBox(string image, Rectangle drawingBounds, int priority, bool isContained, string font) : base(image, drawingBounds, priority, isContained, font)
        {
        }

        public override void Click(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void DoubleClick(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Render(SpriteBatch spBatch, Rectangle containerBounds)
        {
            throw new NotImplementedException();
        }
    }
}
