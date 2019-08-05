using System.Collections.Generic;

namespace MonoGUI.MonoGUI.Reusable.Collections
{
    public class ActionButtonGroupManager
    {
        public ActionButtonGroupManager()
        {
            this.ActionButtons = new List<ActionButton>();
        }

        private readonly List<ActionButton> ActionButtons;

        private int SelectedIndex { get; set; }

        public int Count
        {
            get
            {
                return this.ActionButtons.Count;
            }
        }

        public ActionButton this[int index]
        {
            get
            {
                if (index >= 0 && index <= this.ActionButtons.Count - 1)
                {
                    return this.ActionButtons[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index <= this.Count - 1)
                {
                    this.ActionButtons[index] = value;
                }
            }
        }

        public void AddItem(ActionButton actionButton)
        {
            this.ActionButtons.Add(actionButton);
        }

        public void SetButtonActive(int index)
        {
            if (index >= 0 && index <= this.ActionButtons.Count - 1)
            {
                this.ActionButtons[this.SelectedIndex].IsSelected = false;
                this.SelectedIndex = index;
                this.ActionButtons[index].IsSelected = true;
            }
        }
    }
}