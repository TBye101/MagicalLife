using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MLAPITest")]
[assembly: InternalsVisibleTo("MLAPI")]
[assembly: InternalsVisibleTo("MLDedicatedServer")]
[assembly: InternalsVisibleTo("MLGUIWindows")]
[assembly: InternalsVisibleTo("MLCoreMod")]
[assembly: InternalsVisibleTo("MLServer")]
[assembly: InternalsVisibleTo("MLSettings")]

namespace MLClient
{
    /// <summary>
    /// Used to control access to internal members of this assembly.
    /// </summary>
    public class FriendAssemblies
    {
    }
}