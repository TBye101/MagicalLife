using System.Collections;

namespace MagicalLifeAPI.DataTypes
{
    /// <summary>
    /// An 2D array that should have the basic functions of a normal array, but must be compatible with Protobuf-net.
    /// </summary>
    [ProtoBuf.ProtoContract(IgnoreListHandling = true)]
    public class ProtoArray<T>
    {
        /// <summary>
        /// The width of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(1)]
        public int Width { get; private set; }

        /// <summary>
        /// The height of this array.
        /// </summary>
        [ProtoBuf.ProtoMember(2)]
        public int Height { get; private set; }

        /// <summary>
        /// The actual data this array holds.
        /// </summary>
        [ProtoBuf.ProtoMember(3)]
        public T[] Data { get; set; }

        public ProtoArray(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Data = new T[width * height];
        }

        public ProtoArray(int width, int height, T[] data) : this(width, height)
        {
            this.Data = data;
        }

        public ProtoArray()
        {
        }

        public T this[int x, int y]
        {
            get
            {
                int index = (x * this.Width) + y;
                return this.Data[index];
            }

            set
            {
                int index = (x * this.Width) + y;
                this.Data[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
    }
}