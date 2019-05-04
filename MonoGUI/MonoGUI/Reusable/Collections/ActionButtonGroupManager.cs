using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MonoGUI.MonoGUI.Reusable.Collections
{
    public class ActionButtonGroupManager
    {
        public ActionButtonGroupManager()
        {
            ActionButtons = new List<ActionButton>();
        }

        private readonly List<ActionButton> ActionButtons;

        private int SelectedIndex { get; set; } = 0;

        public int Count => ActionButtons.Count;

        public ActionButton this[int index]
        {
            get
            {
                if(index >= 0 && index <= ActionButtons.Count - 1)
                {
                    return ActionButtons[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index <= Count - 1)
                {
                    ActionButtons[index] = value;
                }
            }
        }

        public void AddItem(ActionButton actionButton)
        {
            ActionButtons.Add(actionButton);
        }

        public void SetButtonActive(int index)
        {
            if(index >= 0 && index <= ActionButtons.Count - 1)
            {
                ActionButtons[SelectedIndex].IsSelected = false;
                SelectedIndex = index;
                ActionButtons[index].IsSelected = true;
            }
        }

    }
}
