using FMOD.Studio;
using MagicalLifeAPI.Filing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Sound
{
    /// <summary>
    /// Some FMOD related utilities.
    /// </summary>
    public static class FMODUtil
    {
        public static void Test()
        {
            FMOD.RESULT result7 = FMOD.Studio.System.create(out FMOD.Studio.System a);
            FMOD.RESULT result6 = a.initialize(1, INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);
            FMOD.RESULT result = a.loadBankFile(FileSystemManager.RootDirectory + "/Content/Banks/Master Bank.bank", FMOD.Studio.LOAD_BANK_FLAGS.NORMAL, out Bank testBank);
            FMOD.RESULT result5 = testBank.getEventList(out EventDescription[] someArray);
            FMOD.RESULT result8 = someArray[0].loadSampleData();
            FMOD.RESULT result4 = someArray[0].createInstance(out EventInstance instance);
            FMOD.RESULT result3 = instance.setVolume(1F);
            FMOD.RESULT result2 = instance.start();
        }
    }
}
