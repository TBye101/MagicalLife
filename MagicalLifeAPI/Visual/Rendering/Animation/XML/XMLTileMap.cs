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
    [XmlRoot("tilemap")]
    public class XMLTileMap
    {
        [XmlElement("layer")]
        public List<XMLLayer> Layers { get; set; }
    }
}
