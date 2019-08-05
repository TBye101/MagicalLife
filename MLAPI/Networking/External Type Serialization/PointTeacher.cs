using MLAPI.DataTypes;
using ProtoBuf.Meta;

namespace MLAPI.Networking.External_Type_Serialization
{
    public class Point2DTeacher : ITeachSerialization
    {
        public void Teach(RuntimeTypeModel model)
        {
            MetaType meta = model.Add(typeof(Point2D), false);
            meta.Add(1, "X");
            meta.Add(2, "Y");
        }
    }
}