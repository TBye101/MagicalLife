using System;

namespace MagicalLifeAPI.World.Data.Disk.DataStorage
{
    /// <summary>
    /// Implementers of this handle what happens to the sections of serialized world data.
    /// </summary>
    public abstract class AbstractWorldSink
    {
        ///<summary></summary>
        /// <param name="data">The data to be handled. This must be Protobuf-net serializable, otherwise this will fail quite rapidly.</param>
        /// <param name="filePath">The filepath to where the data should be stored if saving to disk is the intent.</param>
        public abstract void Receive<T>(T data, string filePath, Guid dimensionID);
    }
}