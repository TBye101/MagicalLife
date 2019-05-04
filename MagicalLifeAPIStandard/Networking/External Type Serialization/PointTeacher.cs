using MagicalLifeAPI.DataTypes;
using ProtoBuf.Meta;

namespace MagicalLifeAPI.Networking.External
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