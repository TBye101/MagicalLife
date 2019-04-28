using MagicalLifeAPI.Components;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity.AI.Task;
using System.Collections.Generic;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Holds information about the actions of some user input.
    /// </summary>
    public class HistoricalInput
    {
        /// <summary>
        /// If this is true, the input detected unselects everything previously selected.
        /// </summary>
        public bool DeselectingAll { get; set; }

        /// <summary>
        /// If this is true, then instead of selecting and deselecting this input actually contains information about a order to a tile.
        /// </summary>
        public bool OrderedToTile { get; set; } = false;

        public List<HasComponents> Selected { get; set; } = new List<HasComponents>();
        public List<HasComponents> DeselectSome { get; set; } = new List<HasComponents>();

        public ActionSelected ActionSelected { get; set; }

        /// <summary>
        /// The location of the tile that the order was to.
        /// </summary>
        public Point2D OrderPoint2D { get; set; }

        public HistoricalInput(ActionSelected selected)
        {
            this.ActionSelected = selected;
        }

        public HistoricalInput(Point2D Point2D, ActionSelected selected) : this(selected)
        {
            this.OrderedToTile = true;
            this.OrderPoint2D = Point2D;
            this.DeselectingAll = false;
        }

        public HistoricalInput(List<HasComponents> selected, ActionSelected selectedAction) : this(selectedAction)
        {
            this.Selected = selected;
            this.OrderedToTile = false;
            this.DeselectingAll = false;
        }

        public HistoricalInput(bool deselectAll, List<HasComponents> deselectSome, ActionSelected selected) : this(selected)
        {
            this.OrderedToTile = false;

            if (deselectAll)
            {
                this.DeselectingAll = true;
            }
            else
            {
                this.DeselectingAll = false;
                this.DeselectSome = deselectSome;
            }
        }

        public HistoricalInput(List<HasComponents> selectSome, bool deselectAll, ActionSelected selected) : this(selected)
        {
            this.OrderedToTile = false;
            this.DeselectingAll = deselectAll;
            this.Selected = selectSome;
        }
    }
}