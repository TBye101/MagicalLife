using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MLAPITest")]
[assembly: InternalsVisibleTo("MLClient")]
[assembly: InternalsVisibleTo("MLAPI")]
[assembly: InternalsVisibleTo("MLGUIWindows")]
[assembly: InternalsVisibleTo("MLCoreMod")]
[assembly: InternalsVisibleTo("MLServer")]
[assembly: InternalsVisibleTo("MLSettings")]

namespace MagicalLifeDedicatedServer
{
    /// <summary>
    /// Used to control who has access to the internal members of this assembly.
    /// </summary>
    public class FriendAssemblies
    {
    }
}