using ProtoBuf.Meta;

namespace MLAPI.Networking
{
    /// <summary>
    /// Any class that implements this teaches the serializer how to serialize some external type.
    /// </summary>
    public interface ITeachSerialization
    {
        void Teach(RuntimeTypeModel model);
    }
}