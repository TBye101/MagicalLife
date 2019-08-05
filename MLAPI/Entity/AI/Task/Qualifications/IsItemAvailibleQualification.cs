using System;
using MLAPI.DataTypes;
using MLAPI.GameRegistry.Items;
using ProtoBuf;

namespace MLAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Determines whether an item of the specified type is unreserved in the world.
    /// </summary>
    [ProtoContract]
    public class IsItemAvailibleQualification : Qualification
    {
        [ProtoMember(1)]
        protected int ItemId { get; set; }

        [ProtoMember(2)]
        protected Guid DimensionId { get; set; }

        protected Point3D SearchLocation { get; set; }

        public IsItemAvailibleQualification(int itemId, Guid dimensionId)
        {
            this.ItemId = itemId;
            this.DimensionId = dimensionId;
            this.SearchLocation = new Point3D(0, 0, dimensionId);
        }

        public override bool ArePreconditionsMet()
        {
            return ItemFinder.IsItemAvailible(this.ItemId, this.DimensionId, this.SearchLocation);
        }

        public override bool IsQualified(Living l)
        {
            return true;
        }
    }
}