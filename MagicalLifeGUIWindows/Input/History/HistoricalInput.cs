using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Holds information about the actions of some user input.
    /// </summary>
    public class HistoricalInput
    {
        /// <summary>
        /// If this is true, the input detected deselects everything previously selected.
        /// </summary>
        public bool DeselectingAll { get; set; }

        /// <summary>
        /// If this is true, then instead of selecting and deselecting this input actually contains information about a order to a tile.
        /// </summary>
        public bool OrderedToTile { get; set; }

        public List<ISelectable> Selected { get; set; } = new List<ISelectable>();
        public List<ISelectable> DeselectSome { get; set; } = new List<ISelectable>();

        /// <summary>
        /// The location of the tile that the order was to.
        /// </summary>
        public Point3D OrderPoint { get; set; }

        public HistoricalInput(Point3D point)
        {
            this.OrderedToTile = true;
            this.OrderPoint = point;
            this.DeselectingAll = false;
        }

        public HistoricalInput(List<ISelectable> selected)
        {
            this.Selected = selected;
            this.OrderedToTile = false;
            this.DeselectingAll = false;
        }

        public HistoricalInput(bool deselectAll, List<ISelectable> deselectSome)
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
    }
}
