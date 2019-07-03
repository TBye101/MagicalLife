using ProtoBuf;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Holds an object and it's access recorder.
    /// Used to keep track of when and how often an object is accessed.
    /// The object must be serializable via protobuf-net.
    /// </summary>
    [ProtoContract]
    public class ObjectAccess<T>
    {
        [ProtoMember(1)]
        public T Object { get; set; }

        [ProtoMember(2)]
        public ObjectAccessRecorder Recorder { get; set; }

        public ObjectAccess()
        {
        }

        public ObjectAccess(T ob, ObjectAccessRecorder recorder)
        {
            this.Object = ob;
            this.Recorder = recorder;
        }
    }
}