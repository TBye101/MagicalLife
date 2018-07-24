using FMOD;
using FMOD.Studio;
using MagicalLifeAPI.Filing;
using MagicalLifeAPI.Filing.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Sound
{
    /// <summary>
    /// Some FMOD related utilities.
    /// </summary>
    public static class FMODUtil
    {
        public static FMOD.Studio.System System;

        public static Bank MainBank;

        public static Bank MainBankStrings;

        public static EventDescription[] MainEvents;

        public static void Init()
        {
            FMOD.Studio.System.create(out System);
            System.getLowLevelSystem(out FMOD.System low);
            low.setSoftwareFormat(0, FMOD.SPEAKERMODE._7POINT1, 0);
            System.initialize(1, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out MainBank);
            System.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master_Bank.strings.bank", LOAD_BANK_FLAGS.NORMAL, out MainBankStrings);
            MainBank.getEventList(out MainEvents);
            DumpEventInformation();
        }

        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="eventPath">The path to the event in a bank file. Ex: event:/Footsteps</param>
        public static void RaiseEvent(string eventPath)
        {
            System.getEvent(eventPath, out EventDescription _event);
            _event.createInstance(out EventInstance instance);
            instance.start();
        }

        public static void Test()
        {
        }

        public static void DumpEventInformation()
        {
            MasterLog.DebugWriteLine("Dumping Sound Events");
            foreach (EventDescription item in MainEvents)
            {
                item.getPath(out string path);
                MasterLog.DebugWriteLine(path);
            }
            MasterLog.DebugWriteLine("End of Sound Events");
        }
    }
}
