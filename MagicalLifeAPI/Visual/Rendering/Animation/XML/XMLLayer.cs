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
    public class XMLLayer
    {
        [XmlElement]
        public List<XMLTile> Tiles { get; set; }
    }
}
