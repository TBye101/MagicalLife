using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MagicalLifeAPI.Visual.Animation
{
    /// <summary>
    /// Reads a XML document which describes sprite information.
    /// </summary>
    public class SpriteSheetReader
    {
        private static readonly string XPathSheetWidth = "/tilemap/@tileswide";
        private static readonly string XPathSheetHeight = "/tilemap/@tileshigh";
        private static readonly string XPathTileWidth = "/tilemap/@tilewidth";
        private static readonly string XPathTileHeight = "/tilemap/@tileheight";

        /// <summary>
        /// Reads the XML file describing the spritesheet.
        /// </summary>
        /// <param name="path">The internal resource path to the XML file.</param>
        /// <param name="textureID">The textureID of the SpriteSheet.</param>
        public SpriteSheet Read(string path, int textureID, Assembly containingAssembly)
        {
            SpriteSheet sheet;

            using (Stream stream = containingAssembly.GetManifestResourceStream(path))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    XmlReader reader = XmlReader.Create(sr);
                    XmlDocument document = new XmlDocument();

                    document.Load(reader);
                    reader.Close();

                    XmlNode sheetWidth = document.SelectSingleNode(XPathSheetWidth);
                    XmlNode sheetHeight = document.SelectSingleNode(XPathSheetHeight);
                    XmlNode tileWidth = document.SelectSingleNode(XPathTileWidth);
                    XmlNode tileHeight = document.SelectSingleNode(XPathTileHeight);

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