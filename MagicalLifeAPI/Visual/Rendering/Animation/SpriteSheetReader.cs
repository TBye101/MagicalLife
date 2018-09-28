using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            XDocument doc = XDocument.Load(path);

            XElement sheetWidth = doc.Element("tileswide");
            XElement sheetHeight = doc.Element("tileshigh");
            XElement tileWidth = doc.Element("tilewidth");
            XElement tileHeight = doc.Element("tileheight");

            int sheetWidthValue = Convert.ToInt32(sheetWidth.Value);
            int sheetHeightValue = Convert.ToInt32(sheetHeight.Value);
            int tileWidthValue = Convert.ToInt32(tileWidth.Value);
            int tileHeightValue = Convert.ToInt32(tileHeight.Value);

            SpriteSheet sheet = new SpriteSheet(textureID, sheetWidthValue, sheetHeightValue, tileWidthValue, tileHeightValue);

            return sheet;
        }
    }
}
