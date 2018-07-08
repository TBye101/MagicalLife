using ProtoBuf;

namespace MagicalLifeAPI.World.Data
{
    /// <summary>
    /// Holds a chunk and its access recorder.
    /// </summary>
    [ProtoContract]
    public class ChunkAccess
    {
        [ProtoMember(1)]
        public Chunk Chunk { get; set; }

        [ProtoMember(2)]
        public ChunkAccessRecorder Recorder { get; set; }

        public ChunkAccess()
        {
        }

        public ChunkAccess(Chunk chunk, ChunkAccessRecorder recorder)
        {
            this.Chunk = chunk;
            this.Recorder = recorder;
        }
    }
}