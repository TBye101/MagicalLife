using MagicalLifeAPI.Asset;
using MagicalLifeAPI.Entity;
using MagicalLifeGUIWindows.GUI.Reusable;
using MagicalLifeGUIWindows.GUI.Reusable.Premade;
using MagicalLifeGUIWindows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.GUI.Character_Menu
{
    public class CharacterContainer : GUIContainer
    {
        public WindowX X { get; set; }
        public MonoLabel CharacterName { get; set; }

        /// <summary>
        /// The creature that has information being displayed about it.
        /// </summary>
        public Living Creature { get; set; }

        /// <param name="creature">The creature that has information being displayed about it.</param>
        public CharacterContainer(Living creature) : base(TextureLoader.GUIMenuBackground, CharacterMenuLayout.GetMenuBounds(), true)
        {
            this.Creature = creature;

            this.X = new WindowX(new MagicalLifeAPI.DataTypes.Point2D(this.DrawingBounds.Width, this.DrawingBounds.Height));
            this.X.XClicked += this.X_XClicked;
            this.CharacterName = new MonoLabel(CharacterMenuLayout.GetNameBounds(), TextureLoader.GUIMenuBackground, true);

            this.Controls.Add(this.X);
            this.Controls.Add(this.CharacterName);
        }

        private void X_XClicked(object sender, EventArgs e)
        {
            BoundHandler.RemoveContainer(this);
        }

        public override string GetTextureName()
        {
            return TextureLoader.GUIMenuBackground;
        }
    }
}
