using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Registry.ItemRegistry;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.Entity.AI.Task.Qualifications
{
    /// <summary>
    /// Determines whether an item of the specified type is unreserved in the world.
    /// </summary>
    [ProtoContract]
    public class IsItemAvailibleQualification : Qualification
    {
        [ProtoMember(1)]
        protected int ItemID { get; set; }

        [ProtoMember(2)]
        protected Guid DimensionID { get; set; }

        protected Point3D SearchLocation { get; set; }

        public IsItemAvailibleQualification(int itemID, Guid dimensionID)
        {
            this.ItemID = itemID;
            this.DimensionID = dimensionID;
            this.SearchLocation = new Point3D(0, 0, dimensionID);
        }

        public override bool ArePreconditionsMet()
        {
            return ItemFinder.IsItemAvailible(this.ItemID, this.DimensionID, this.SearchLocation);
        }

        public override bool IsQualified(Living l)
        {
            return true;
        }
    }
}