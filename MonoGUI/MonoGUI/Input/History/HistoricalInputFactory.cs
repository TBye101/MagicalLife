using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using MagicalLifeGUIWindows.Map;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicalLifeGUIWindows.Input.History
{
    /// <summary>
    /// Used to generate <see cref="HistoricalInput"/>.
    /// </summary>
    public class HistoricalInputFactory
    {
        public HistoricalInput Generate(InputEventArgs e)
        {
            //HistoricalInput history = new HistoricalInput()
            switch (e.MouseEventArgs.Button)
            {
                case MonoGame.Extended.Input.InputListeners.MouseButton.Left:
                    return this.SingleSelect(e);

                case MonoGame.Extended.Input.InputListeners.MouseButton.Right:
                    return this.Order(e, RenderingData.CurrentlySelected);

                default:
                    return null;
            }
        }

        private HistoricalInput SingleSelect(InputEventArgs e)
        {
            switch (RenderingData.CurrentlySelected)
            {
                case ActionSelected.None:
                    return this.NoAction(e);

                case ActionSelected.Mine:
                    return this.GenericAction(e, ActionSelected.Mine);

                case ActionSelected.Till:
                    return this.TillAction(e);

                case ActionSelected.Chop:
                    return this.GenericAction(e, ActionSelected.Chop);

                default:
                    throw new InvalidOperationException("Unexpected value for selected action = " + RenderingData.CurrentlySelected);
            }
        }

        /// <summary>
        /// Generates a <see cref="HistoricalInput"/> for when there is a mining action selected by the player.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private HistoricalInput TillAction(InputEventArgs e)
        {
            return this.GenericAction(e, ActionSelected.Till);
        }

        /// <summary>
        /// Generates a <see cref="HistoricalInput"/> for when there is a generic action selected by the player.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private HistoricalInput GenericAction(InputEventArgs e, ActionSelected action)
        {
            Point2D mapSpot = Util.GetMapLocation(e.MouseEventArgs.Position.X, e.MouseEventArgs.Position.Y, RenderInfo.DimensionID, out bool success);

            if (success)
            {
                Tile tile = World.GetTile(RenderInfo.DimensionID, mapSpot.X, mapSpot.Y);

                if (tile != null)
                {
                    List<HasComponents> selected = new List<HasComponents>
                    {
                        tile
                    };

                    if (e.ShiftDown)
                    {
                        if (this.IsSelectableSelected(tile))
                        {
                            return new HistoricalInput(false, selected, action);
                        }
                        else
                        {
                            return new HistoricalInput(selected, action);
                        }
                    }
                    else
                    {
                        return new HistoricalInput(selected, true, action);
                    }
                }
            }

            return new HistoricalInput(true, InputHistory.Selected, action);
        }

        /// <summary>
        /// Generates a <see cref="HistoricalInput"/> for when there is no action selected by the player.
        /// </summary>
        /// <returns></returns>
        private HistoricalInput NoAction(InputEventArgs e)
        {
            Point2D mapSpot = Util.GetMapLocation(e.MouseEventArgs.Position.X, e.MouseEventArgs.Position.Y, RenderInfo.DimensionID, out bool success);

            if (success)
            {
                Living select = null;

                Chunk chunk = World.Dimensions[RenderInfo.DimensionID].GetChunkForLocation(mapSpot.X, mapSpot.Y);
                KeyValuePair<System.Guid, Living> result = chunk.Creatures.FirstOrDefault
                    (x => mapSpot.Equals(x.Value.GetExactComponent<ComponentSelectable>().MapLocation));

                select = result.Value;

                if (select != null)
                {
                    //Null check select, as it is null when an entity is not found
                    List<HasComponents> selected = new List<HasComponents>
                    {
                        select
                    };

                    if (e.ShiftDown)
                    {
                        if (this.IsSelectableSelected(select))
                        {
                            return new HistoricalInput(false, selected, ActionSelected.None);
                        }
                        else
                        {
                            return new HistoricalInput(selected, ActionSelected.None);
                        }
                    }
                    else
                    {
                        return new HistoricalInput(selected, true, ActionSelected.None);
                    }
                }
            }

            return new HistoricalInput(true, InputHistory.Selected, ActionSelected.None);
        }

        /// <summary>
        /// Returns true if the <see cref="ComponentSelectable"/> is already selected.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        private bool IsSelectableSelected(HasComponents selectable)
        {
            foreach (HasComponents item in InputHistory.Selected)
            {
                if (selectable.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private HistoricalInput Order(InputEventArgs e, ActionSelected action)
        {
            Point2D screenLocation = e.MouseEventArgs.Position;

            Point3D mapLocation = Util.GetMapLocation(screenLocation.X, screenLocation.Y, RenderInfo.DimensionID, out bool success);

            if (success)
            {
                return new HistoricalInput(mapLocation, action);
            }
            else
            {
                return null;
            }
        }
    }
}