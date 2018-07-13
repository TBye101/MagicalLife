using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
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

        public List<Selectable> Selected { get; set; } = new List<Selectable>();
        public List<Selectable> DeselectSome { get; set; } = new List<Selectable>();

        /// <summary>
        /// The location of the tile that the order was to.
        /// </summary>
        public Point2D OrderPoint2D { get; set; }

        public HistoricalInput(Point2D Point2D)
        {
            this.OrderedToTile = true;
            this.OrderPoint2D = Point2D;
            this.DeselectingAll = false;
        }

        public HistoricalInput(List<Selectable> selected)
        {
            this.Selected = selected;
            this.OrderedToTile = false;
            this.DeselectingAll = false;
        }

        public HistoricalInput(bool deselectAll, List<Selectable> deselectSome)
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

        public HistoricalInput(List<Selectable> selectSome, bool deselectAll)
        {
            this.OrderedToTile = false;
            this.DeselectingAll = deselectAll;
            this.Selected = selectSome;
        }
    }
}