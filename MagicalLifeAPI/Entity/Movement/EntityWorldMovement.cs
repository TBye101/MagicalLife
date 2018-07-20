using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Util.Modifier_Remove_Conditions;
using MagicalLifeAPI.InternalExceptions;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World;
using System;

namespace MagicalLifeAPI.Entities.Movement
{
    /// <summary>
    /// Used to move entities.
    /// </summary>
    public static class EntityWorldMovement
    {
        /// <summary>
        /// Moves the entity as far along on its path as possible.
        /// </summary>
        /// <param name="entity"></param>
        public static void MoveEntity(ref Living entity)
        {
            ProtoQueue<PathLink> path = entity.QueuedMovement;

            while (entity.Movement.GetValue() > 0 && path.Count > 0)
            {
                PathLink section = path.Peek();

                Tile sourceTile = World.Data.World.Dimensions[entity.Dimension][section.Origin.X, section.Origin.Y];
                Tile destinationTile = World.Data.World.Dimensions[entity.Dimension][section.Destination.X, section.Destination.Y];
                Move(ref entity, sourceTile, destinationTile);
            }
        }

        /// <summary>
        /// Determines how many movement Point2Ds are deducted from the entity in motion for a given movement action.
        /// </summary>
        /// <param name="xMove"></param>
        /// <param name="yMove"></param>
        /// <returns></returns>
        private static double CalculateMovementReduction(double xMove, double yMove)
        {
            if (Math.Abs(xMove) == Math.Abs(yMove))
            {
                return xMove;
            }
            else
            {
                return xMove + yMove;
            }
        }

        /// <summary>
        /// Moves the entity in a direction.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void Move(ref Living entity, Tile source, Tile destination)
        {
            Direction direction = DetermineMovementDirection(source.Location, destination.Location);

            float xMove = 0;
            float yMove = 0;

            switch (direction)
            {
                case Direction.North:
                    yMove = -1;
                    break;

                case Direction.South:
                    yMove = 1;
                    break;

                case Direction.East:
                    xMove = 1;
                    break;

                case Direction.West:
                    xMove = -1;
                    break;

                case Direction.NorthWest:
                    xMove = -1;
                    yMove = -1;
                    break;

                case Direction.NorthEast:
                    xMove = 1;
                    yMove = -1;
                    break;

                case Direction.SouthWest:
                    xMove = -1;
                    yMove = 1;
                    break;

                case Direction.SouthEast:
                    xMove = 1;
                    yMove = 1;
                    break;

                default:
                    throw new UnexpectedEnumMemberException();
            }

            xMove *= entity.Movement.GetValue();
            yMove *= entity.Movement.GetValue();

            float movementPenalty = (float)Math.Abs(CalculateMovementReduction(xMove, yMove)) * -1;

            if (MathUtil.GetDistance(entity.ScreenLocation, destination.Location) > entity.Movement.GetValue())
            {
                entity.ScreenLocation = new DataTypes.Point2DFloat(entity.ScreenLocation.X + xMove, entity.ScreenLocation.Y + yMove);
            }
            else
            {
                entity.MapLocation = destination.Location;
                entity.ScreenLocation = new DataTypes.Point2DFloat(destination.Location.X, destination.Location.Y);
                entity.QueuedMovement.Dequeue();
                movementPenalty = MathUtil.GetDistance(entity.ScreenLocation, destination.Location);
            }

            entity.Movement.AddModifier(new Entity.Util.ModifierFloat(movementPenalty, new TimeRemoveCondition(1), "Normal Movement"));
        }

        /// <summary>
        /// Determines which way a creature is moving in terms of cardinal direction.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Direction DetermineMovementDirection(Point2D source, Point2D destination)
        {
            if (destination.Y < source.Y)
            {
                if (destination.X > source.X)
                {
                    return Direction.NorthEast;
                }

                if (destination.X < source.X)
                {
                    return Direction.NorthWest;
                }

                return Direction.North;
            }

            if (destination.Y > source.Y)
            {
                if (destination.X > source.X)
                {
                    return Direction.SouthEast;
                }

                if (destination.X < source.X)
                {
                    return Direction.SouthWest;
                }

                return Direction.South;
            }

            if (destination.Y == source.Y)
            {
                if (destination.X > source.X)
                {
                    return Direction.East;
                }

                if (destination.X < source.X)
                {
                    return Direction.West;
                }
            }

            throw new UnexpectedEnumMemberException();
        }
    }
}