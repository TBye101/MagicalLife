using MagicalLifeAPI.Visual.Rendering.Animation.XML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MagicalLifeAPI.Visual.Animation
{
    /// <summary>
    /// Reads a XML document which describes sprite information.
    /// </summary>
    public class SpriteSheetReader
    {
        public SpriteSheetReader()
        {

        }

        /// <summary>
        /// Reads the XML file describing the spritesheet.
        /// </summary>
        /// <param name="path">The internal resource path to the XML file.</param>
        /// <param name="textureID">The textureID of the SpriteSheet.</param>
        public SpriteSheet Read(string path, int textureID)
        {
            SpriteSheet sheet;
            Assembly asm = Assembly.GetCallingAssembly();

            using (Stream stream = asm.GetManifestResourceStream(path))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XMLTileMap));
                    XMLTileMap result = (XMLTileMap)serializer.Deserialize(sr);

                    XDocument doc = XDocument.Load(stream);

                    XElement Descriptor = doc.Element("tilemap");
                    System.Xml.XmlReader reader = doc.CreateReader();

                    //dynamic annotations = doc.Ancestors();
                    IEnumerable<XElement> a = doc.Descendants();

                    IEnumerable<XAttribute> one = a.ElementAt(0).Attributes();
                    
                    //dynamic b = doc.Elements();
                    //dynamic c = doc.Nodes();
                    //dynamic d = doc.Parent;
                    //dynamic e = doc.Root;

                    XElement sheetWidth = Descriptor.Element("tileswide");
                    XElement sheetHeight = Descriptor.Element("tileshigh");
                    XElement tileWidth = Descriptor.Element("tilewidth");
                    XElement tileHeight = Descriptor.Element("tileheight");

                    int sheetWidthValue = Convert.ToInt32(sheetWidth.Value);
                    int sheetHeightValue = Convert.ToInt32(sheetHeight.Value);
                    int tileWidthValue = Convert.ToInt32(tileWidth.Value);
                    int tileHeightValue = Convert.ToInt32(tileHeight.Value);

                    sheet = new SpriteSheet(textureID, sheetWidthValue, sheetHeightValue, tileWidthValue, tileHeightValue);
                }
            }

            return sheet;
        }
    }
}
