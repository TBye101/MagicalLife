using MLAPI.Mod;

namespace MLCoreMod.Core
{
    /// <summary>
    /// Holds some information about the core game mod.
    /// </summary>
    public static class DescriptionValues
    {
        /// <summary>
        /// The ID of this mod.
        /// </summary>
        internal static readonly string ModID = "BD541FE2-D5D3-471E-963F-1A7AA5A14AF9";

        /// <summary>
        /// The display name of this mod.
        /// </summary>
        internal static readonly string DisplayName = "Magical Life Core";

        /// <summary>
        /// The displayable author name.
        /// </summary>
        internal static readonly string AuthorName = "Magical Life Team";

        /// <summary>
        /// A description of this mod.
        /// </summary>
        internal static readonly string Description = "The core vanilla content for Magical Life";

        /// <summary>
        /// The version of this mod.S
        /// </summary>
        internal static readonly ProtoVersion Version = new ProtoVersion(0, 1, 2, 0);
    }
}