using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Interfaces
{
    /// <summary>
    /// Used so we can detect story modules when doing reflection.
    /// </summary>
    public interface IStory
    {
        void Start();
    }
}
