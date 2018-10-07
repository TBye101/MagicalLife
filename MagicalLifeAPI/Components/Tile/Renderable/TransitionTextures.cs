using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Components.Tile.Renderable
{
    [ProtoContract]
    public class TransitionTextures : AbstractRenderable
    {
        /// <summary>
        /// The type of the tile at the location of where we are rendered.
        /// </summary>
        [ProtoMember(1)]
        protected Type RepresentedTile;

        [ProtoMember(2)]
        protected Type CompatibleTile;

        /// <summary>
        /// |0|1 |2|
        /// |3|Me|4|
        /// |5|6 |7|
        /// </summary>
        [ProtoMember(3)]
        protected TileState[] TileStates = new TileState[8];//Changing the size of this would break things

        [ProtoMember(4)]
        protected AbstractConnectedTexture Condition;

        /// <param name="compatibleTile">A second type of tile that should be blended with.</param>
        /// <param name="representedTile">The type of the tile that this transition texture is controlling.</param>
        public TransitionTextures(Type compatibleTile, Type representedTile, AbstractConnectedTexture conditions)
        {
            this.RepresentedTile = representedTile;
            this.CompatibleTile = compatibleTile;
            this.Condition = conditions;

            World.Base.Tile.TileCreated += this.Tile_TileCreated;
        }

        public TransitionTextures()
        {
        }

        /// <summary>
        /// Calculates the texture of the represented tile for the first time.
        /// </summary>
        public override void CalculateTexture(ProtoArray<World.Base.Tile> tiles, Point2D myLocation)
        {
            this.SetStates(myLocation, tiles);
            this.TextureID = this.Condition.GetTextureID(this.TileStates);
        }

        /// <summary>
        /// Sets the states of each neighboring tile in <see cref="TileStates"/>.
        /// </summary>
        /// <param name="myLocation"></param>
        private void SetStates(Point2D myLocation, ProtoArray<World.Base.Tile> tiles)
        {
            int x = myLocation.X;
            int y = myLocation.Y;

            //Set the states of each neighboring tile in our array
            this.TileStates[0] = this.SafeGetState(x - 1, y - 1, tiles);
            this.TileStates[1] = this.SafeGetState(x, y - 1, tiles);
            this.TileStates[2] = this.SafeGetState(x + 1, y - 1, tiles);
            this.TileStates[3] = this.SafeGetState(x - 1, y, tiles);
            this.TileStates[4] = this.SafeGetState(x + 1, y, tiles);
            this.TileStates[5] = this.SafeGetState(x - 1, y + 1, tiles);
            this.TileStates[6] = this.SafeGetState(x, y + 1, tiles);
            this.TileStates[7] = this.SafeGetState(x + 1, y + 1, tiles);
        }

        /// <summary>
        /// Safely gets the state of the neighboring tile at the specified location.
        /// </summary>
        /// <param name="tileStateIndex">The index in <see cref="TileStates"/> to modify.</param>
        private TileState SafeGetState(int x, int y, ProtoArray<World.Base.Tile> tiles)
        {
            if (x < tiles.Width && x >= 0 && y < tiles.Height && y >= 0)
            {
                World.Base.Tile neighbor = tiles[x, y];
                Type neighborType = neighbor.GetType();

                if (neighborType == this.CompatibleTile)
                {
                    return TileState.Compatible;
                }
                if (neighborType == this.RepresentedTile)
                {
                    return TileState.Identical;
                }

                return TileState.Incompatible;
            }
            else
            {
                return TileState.Compatible;
            }
        }

        private void Tile_TileCreated(object sender, World.TileEventArg e)
        {
        }
    }
}