using ProtoBuf.Meta;

namespace MagicalLifeAPI.Networking.External_Type_Serialization
{
    public class PointTeacher : ITeachSerialization
    {
        public void Teach(RuntimeTypeModel model)
        {
            MetaType meta = model.Add(typeof(Microsoft.Xna.Framework.Point), false);
            meta.Add(1, "X");
            meta.Add(2, "Y");
        }
    }
}