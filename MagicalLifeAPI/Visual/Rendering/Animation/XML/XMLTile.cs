using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicalLifeAPI.Visual.Rendering.Animation.XML
{
    /// <summary>
    /// Used to deserialize spritesheet information.
    /// </summary>
    public class XMLTile
    {
        [XmlElement("x")]
        public int X { get; set; }

        [XmlElement("y")]
        public int Y { get; set; }

        [XmlElement("tile")]
        public int Tile { get; set; }

        [XmlElement("rot")]
        public int Rotation { get; set; }

        [XmlElement("flipX")]
        public bool FlippedX { get; set; }
    }
}
