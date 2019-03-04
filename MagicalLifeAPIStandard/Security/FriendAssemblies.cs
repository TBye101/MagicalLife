using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("MagicalLifeAPITest")]
[assembly: InternalsVisibleTo("MagicalLifeClientStandard")]
[assembly: InternalsVisibleTo("MagicalLifeDedicatedServerCore")]
[assembly: InternalsVisibleTo("MagicalLifeGUIWindows")]
[assembly: InternalsVisibleTo("MagicalLifeModdingAPI")]
[assembly: InternalsVisibleTo("MagicalLifeServerStandard")]
[assembly: InternalsVisibleTo("MagicalLifeSettingsStandard")]

namespace MagicalLifeAPI.Security
{
    /// <summary>
    /// This class determines who can access classes and objects marked with "internal".
    /// </summary>
    internal class FriendAssemblies
    {
    }
}
