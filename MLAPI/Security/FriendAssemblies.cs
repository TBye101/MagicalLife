using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MLAPITest")]
[assembly: InternalsVisibleTo("MLClient")]
[assembly: InternalsVisibleTo("MLDedicatedServer")]
[assembly: InternalsVisibleTo("MLGUIWindows")]
[assembly: InternalsVisibleTo("MLCoreMod")]
[assembly: InternalsVisibleTo("MLServer")]
[assembly: InternalsVisibleTo("MLSettings")]
[assembly: InternalsVisibleTo("MonoGUI")]

namespace MagicalLifeAPI.Security
{
    /// <summary>
    /// This class determines who can access classes and objects marked with "internal".
    /// </summary>
    internal class FriendAssemblies
    {
    }
}