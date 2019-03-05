using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalLifeAPI.Mod
{
    /// <summary>
    /// Holds some information about the mod.
    /// </summary>
    [ProtoContract]
    public class ModInformation
    {
        /// <summary>
        /// A unique ID for the mod. This must not conflict with any other mod's.
        /// It is recommend to generate a random id (GUID) once (hard code it) and use that. 
        /// </summary>
        public string ModID { get; private set; }

        /// <summary>
        /// The name of the mod that will be displayed to players.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// The name of the author that will be displayed to players.
        /// </summary>
        public string AuthorName { get; private set; }

        /// <summary>
        /// The description of the mod which will be shown to players.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The version of the mod. 
        /// </summary>
        public ProtoVersion Version { get; private set; }

        /// <param name="modID">A unique ID for the mod. This must not conflict with any other mod's. It is recommend to generate a random id (GUID) once (hard code it) and use that. </param>
        /// <param name="displayName">The name of the mod that will be displayed to players.</param>
        /// <param name="authorName">The name of the author that will be displayed to players.</param>
        /// <param name="description">The description of the mod which will be shown to players.</param>
        /// <param name="version">The version of the mod. </param>
        public ModInformation(string modID, string displayName, string authorName,
            string description, ProtoVersion version)
        {
            this.ModID = modID;
            this.DisplayName = displayName;
            this.AuthorName = authorName;
            this.Description = description;
            this.Version = version;
        }

        protected ModInformation()
        {
            //Protobuf-net constructor
        }
    }
}
